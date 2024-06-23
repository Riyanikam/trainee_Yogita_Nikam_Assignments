﻿using Assignmentfifth.CosmosDB;
using Assignmentfifth.DTO;
using Assignmentfifth.Entity;
using static Assignmentfifth.Interface.IEmployeeAdditonalDetail;
using System.Net;
using Assignmentfifth.Overall;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace Assignmentfifth.Services
{
    public class EmployeeAdditonalDetailService
    {
        public class EmployeeAdditionalDetailsService : IEmployeeAdditionalDetails
        {
            public readonly ICosmosDBService _cosmosDBService;

            public EmployeeAdditionalDetailsService(ICosmosDBService cosmosDBService)
            {
                _cosmosDBService = cosmosDBService;
            }

            public async Task<EmployeeAdditionalDetailsDTO> Add_AdditionalData(EmployeeAdditionalDetailsDTO employeeAdditionalDetailsDTO)
            {
                EmployeeAdditionalDetailsEntity employee = new EmployeeAdditionalDetailsEntity();
                employee.UId = employeeAdditionalDetailsDTO.UId;
                employee.AlternateEmail = employeeAdditionalDetailsDTO.AlternateEmail;
                employee.AlternateMobile = employeeAdditionalDetailsDTO.AlternateMobile;
                employee.WorkInformation = employeeAdditionalDetailsDTO.WorkInformation;
                employee.PersonalDetails = employeeAdditionalDetailsDTO.PersonalDetails;
                employee.IdentityInformation = employeeAdditionalDetailsDTO.IdentityInformation;

                employee.Intialize(true, Main.EmployeeDocumentType, "Yogita", "Yogita");

                var response = await _cosmosDBService.Add_AdditionalData(employee);


                var responseModel = new EmployeeAdditionalDetailsDTO();
                responseModel.UId = response.UId;
                responseModel.AlternateEmail = response.AlternateEmail;
                responseModel.AlternateMobile = response.AlternateMobile;
                responseModel.WorkInformation = response.WorkInformation;
                responseModel.PersonalDetails = response.PersonalDetails;
                responseModel.IdentityInformation = response.IdentityInformation;
                return responseModel;
            }


            public async Task<List<EmployeeAdditionalDetailsDTO>> GetAllEmployeeAdditionalData()
            {
                var employees = await _cosmosDBService.GetAllEmployeeAdditionalData();

                var employeeAdditionalDetailsDTOs = new List<EmployeeAdditionalDetailsDTO>();
                foreach (var employee in employees)
                {
                    var employeeAdditionalDetailsDTO = new EmployeeAdditionalDetailsDTO();
                    employeeAdditionalDetailsDTO.UId = employee.UId;
                    employeeAdditionalDetailsDTO.AlternateEmail = employee.AlternateEmail;
                    employeeAdditionalDetailsDTO.AlternateMobile = employee.AlternateMobile;
                    employeeAdditionalDetailsDTO.WorkInformation = employee.WorkInformation;
                    employeeAdditionalDetailsDTO.PersonalDetails = employee.PersonalDetails;
                    employeeAdditionalDetailsDTO.IdentityInformation = employee.IdentityInformation;


                    employeeAdditionalDetailsDTOs.Add(employeeAdditionalDetailsDTO);
                }
                return employeeAdditionalDetailsDTOs;
            }



            public async Task<EmployeeAdditionalDetailsDTO> GetEmployeeAdditionalDataByUId(string UId)
            {
                var response = await _cosmosDBService.GetEmployeeAdditionalDataByUId(UId);

                if (response != null)
                {
                    var employeeAdditionalDetailsDTO = new EmployeeAdditionalDetailsDTO();

                    employeeAdditionalDetailsDTO.UId = response.UId;
                    employeeAdditionalDetailsDTO.AlternateEmail = response.AlternateEmail;
                    employeeAdditionalDetailsDTO.AlternateMobile = response.AlternateMobile;
                    employeeAdditionalDetailsDTO.WorkInformation = response.WorkInformation;
                    employeeAdditionalDetailsDTO.PersonalDetails = response.PersonalDetails;
                    employeeAdditionalDetailsDTO.IdentityInformation = response.IdentityInformation;

                    return employeeAdditionalDetailsDTO;
                }
                else
                {
                    throw new Exception("Response object is null.");

                }
            }


            public async Task<EmployeeAdditionalDetailsDTO> UpdateAdditionalData(EmployeeAdditionalDetailsDTO employeeAdditionalDetailsDTO)
            {
                var existingEmployee = await _cosmosDBService.GetEmployeeAdditionalDataByUId(employeeAdditionalDetailsDTO.UId);
                existingEmployee.Active = false;
                existingEmployee.Archived = true;
                await _cosmosDBService.ReplaceAsync(existingEmployee);

                existingEmployee.Intialize(false, Main.EmployeeDocumentType, "Yogita", "Yogita");




                existingEmployee.UId = employeeAdditionalDetailsDTO.UId;
                existingEmployee.AlternateEmail = employeeAdditionalDetailsDTO.AlternateEmail;
                existingEmployee.AlternateMobile = employeeAdditionalDetailsDTO.AlternateMobile;
                existingEmployee.WorkInformation = employeeAdditionalDetailsDTO.WorkInformation;
                existingEmployee.PersonalDetails = employeeAdditionalDetailsDTO.PersonalDetails;
                existingEmployee.IdentityInformation = employeeAdditionalDetailsDTO.IdentityInformation;


                var response = await _cosmosDBService.Add_AdditionalData(existingEmployee);

                var responseModel = new EmployeeAdditionalDetailsDTO
                {
                    UId = response.UId,
                    AlternateEmail = response.AlternateEmail,
                    AlternateMobile = response.AlternateMobile,
                    WorkInformation = response.WorkInformation,
                    PersonalDetails = response.PersonalDetails,
                    IdentityInformation = response.IdentityInformation,



                };
                return responseModel;


            }
            public async Task<string> DeleteEmployeeAdditional(string employeeBasicDetailsUId)
            {

                var employee = await _cosmosDBService.GetEmployeeAdditionalDataByUId(employeeBasicDetailsUId);
                employee.Active = false;
                employee.Archived = true;
                await _cosmosDBService.ReplaceAsync(employee);

                employee.Intialize(false, Main.EmployeeDocumentType, "Yogita", "Yogita");
                employee.Archived = true;



                var response = await _cosmosDBService.Add_AdditionalData(employee);

                return "Record Deleted Successfully";
            }
            //For the PostRequest 
            public async Task<EmployeeAdditionalDetailsDTO>AddEmployeeByMakePostRequest(EmployeeAdditionalDetailsDTO employeeAdditionalDetailsDTO)
            {
                var serializable=JsonConvert.SerializeObject(employee);
                var requestObj = await httpsClientHelper.MakePostRequest(Credentials.Emplyeurl, ICredentials.AddEmployeeEndPoint, serializable);
                var model=JsonConvert.DeserializeObject<EmployeeAdditionalDetailsDTO>(requestObj);
                return model;
            }
            //For the GetRequest 
            public async Task<EmployeeAdditionalDetailsDTO> GetEmployeeByMakeGetRequest(int employeeId)
            {
                var serializable = JsonConvert.SerializeObject(employee);
                var responseObj = await httpsClientHelper.MakeGetRequest(url);
                var model = JsonConvert.DeserializeObject<EmployeeAdditionalDetailsDTO>(responseObj);
                return model;
            }
        }
    }
}
