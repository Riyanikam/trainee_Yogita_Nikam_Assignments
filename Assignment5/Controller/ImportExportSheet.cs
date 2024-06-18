using Assignmentfifth.DTO;
using Assignmentfifth.Interface;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Drawing;

namespace Assignmentfifth.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImportExportSheetController : Controller
    {
        private readonly IEmployeeBasicDetails _employeeBasicDetails;

        // Constructor to inject the IEmployeeBasicDetails service
        public ImportExportSheetController(IEmployeeBasicDetails employeeBasicDetails)
        {
            _employeeBasicDetails = employeeBasicDetails;
        }

        // API endpoint to add a new employee
        [HttpPost]
        public async Task<EmployeeBasicDetailsDTO> AddEmployee(EmployeeBasicDetailsDTO employeeBasicDetailsDTO)
        {
            var response = await _employeeBasicDetails.AddEmployee(employeeBasicDetailsDTO);
            return response;
        }

        // Helper method to get a string value from an Excel cell
        private string GetStringFromCell(ExcelWorksheet worksheet, int row, int column)
        {
            var cellValue = worksheet.Cells[row, column].Value;
            return cellValue?.ToString()?.Trim();
        }

        // API endpoint to import employees from an Excel file
        [HttpPost]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is empty.");

            var employees = new List<EmployeeBasicDetailsDTO>();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream); // Use asynchronous copy
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    
                    // Start from the second row to skip the header
                    for (int row = 2; row <= rowCount; row++)
                    {
                        DateTime dateOfBirth = DateTime.Parse(GetStringFromCell(worksheet, row, 6));
                        DateTime dateOfJoining = DateTime.Parse(GetStringFromCell(worksheet, row, 7));

                        var employee = new EmployeeBasicDetailsDTO
                        {
                            FirstName = GetStringFromCell(worksheet, row, 1),
                            LastName = GetStringFromCell(worksheet, row, 2),
                            Email = GetStringFromCell(worksheet, row, 3),
                            Mobile = GetStringFromCell(worksheet, row, 4),
                            ReportingManagerName = GetStringFromCell(worksheet, row, 5),
                            DateOfBirth = dateOfBirth,
                            DateOfJoining = dateOfJoining,
                        };

                        await AddEmployee(employee);
                        employees.Add(employee);
                    }
                }
            }
            return Ok(employees);
        }

        // API endpoint to export employees to an Excel file
        [HttpGet]
        public async Task<IActionResult> Export()
        {
            var employees = await _employeeBasicDetails.GetAllEmployee();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Employees");

                // Add header row
                worksheet.Cells[1, 1].Value = "FirstName";
                worksheet.Cells[1, 2].Value = "LastName";
                worksheet.Cells[1, 3].Value = "Email";
                worksheet.Cells[1, 4].Value = "Mobile";
                worksheet.Cells[1, 5].Value = "ReportingManagerName";
                worksheet.Cells[1, 6].Value = "DateOfBirth";
                worksheet.Cells[1, 7].Value = "DateOfJoining";

                // Style the header row
                using (var range = worksheet.Cells[1, 1, 1, 7])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                }

                // Add the  data rows
                for (int i = 0; i < employees.Count; i++)
                {
                    var employee = employees[i];
                    worksheet.Cells[i + 2, 1].Value = employee.FirstName;
                    worksheet.Cells[i + 2, 2].Value = employee.LastName;
                    worksheet.Cells[i + 2, 3].Value = employee.Email;
                    worksheet.Cells[i + 2, 4].Value = employee.Mobile;
                    worksheet.Cells[i + 2, 5].Value = employee.ReportingManagerName;
                    worksheet.Cells[i + 2, 6].Value = employee.DateOfBirth;
                    worksheet.Cells[i + 2, 7].Value = employee.DateOfJoining;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var fileName = "Employees.xlsx";//file that will get
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }
    }
}
