using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using LibManagementSystem.Entities;
using LibManagementSystem.Models;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IssueController:ControllerBase//It's a Controlller
    {
        //Parameter that are taken while making connection with the Database
        private readonly string URI="https://localhost:8081";
        private readonly string PrimaryKey="C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private readonly string DatabaseName="batch4";
        private readonly string ContainerName="student";

        private readonly Microsoft.Azure.Cosmos.Container container;
        //Making a constructor of container
        public IssueController()
        {
            container=GetContainer();
        }

        private Microsoft.Azure.Cosmos.Container GetContainer()
        {
            CosmosClient cosmosClient=new CosmosClient(URI,PrimaryKey);
            Database database=cosmosClient.GetDatabase(DatabaseName);
            return database.GetContainer(ContainerName);
        }

        [HttpPost]
        //mapping all the field from model to entity
        public async Task<IActionResult>AddIssue(IssueModel issueModel)
        {
            IssuesEntity issue=new IssuesEntity
            {
                //Assign values
                Id=Guid.NewGuid().ToString(),
                UId=issueModel.UId,
                BookId=issueModel.BookId,
                MemberId=issueModel.MemberId,
                IssueDate=issueModel.IssueDate,
                ReturnDate=issueModel.ReturnDate,
                IsReturned=issueModel.IsReturned,
                DocumentType="issue",
                CreatedBy="Admin",
                CreatedOn=DateTime.Now,
                UpdatedBy="",
                UpdatedOn=DateTime.Now,
                Active=true,
                Archived=false
            };
            //Adding value to Database
            ItemResponse<IssuesEntity>response=await container.CreateItemAsync(issue);
            return Ok(new IssueModel
            {
                //Return from the Model
                UId=response.Resource.UId,
                BookId=response.Resource.BookId,
                MemberId=response.Resource.MemberId,
                IssueDate=response.Resource.IssueDate,
                ReturnDate=response.Resource.ReturnDate,
                IsReturned=response.Resource.IsReturned
            });
        }

        [HttpGet]
        public async Task<IActionResult>GetIssueByUId(string uId)
        {
            //here we take the records from database
            var query=container.GetItemLinqQueryable<IssuesEntity>(true)
                                 .Where(i=>i.UId==uId && i.Active && !i.Archived)
                                 .AsQueryable();
            IssuesEntity issue=query.FirstOrDefault();

            if (issue==null)
            {
                return NotFound();
            }

            return Ok(new IssueModel
            {
                UId=issue.UId,
                BookId=issue.BookId,
                MemberId=issue.MemberId,
                IssueDate=issue.IssueDate,
                ReturnDate=issue.ReturnDate,
                IsReturned=issue.IsReturned
            });
        }

        [HttpGet]
        public async Task<IActionResult>GetAllIssues()
        {
            //here we take the records from database
            var query = container.GetItemLinqQueryable<IssuesEntity>(true).Where(i => i.Active && !i.Archived).AsQueryable();
            List<IssueModel>issues=query.Select(issue=> new IssueModel
            {
                UId=issue.UId,
                BookId=issue.BookId,
                MemberId=issue.MemberId,
                IssueDate=issue.IssueDate,
                ReturnDate=issue.ReturnDate,
                IsReturned=issue.IsReturned
            }).ToList();

            return Ok(issues);
        }

        [HttpPut]
        public async Task<IActionResult>UpdateIssue(IssueModel issueModel)
        {
            //here we take the records from database
            var query =container.GetItemLinqQueryable<IssuesEntity>(true)
                                 .Where(i=>i.UId==issueModel.UId && i.Active && !i.Archived).AsQueryable();
            IssuesEntity existingIssue =query.FirstOrDefault();

            if (existingIssue==null)
            {
                return NotFound();
            }

            existingIssue.Archived=true;
            existingIssue.Active=false;
            await container.ReplaceItemAsync(existingIssue,existingIssue.Id);

            existingIssue.Id=Guid.NewGuid().ToString();
            existingIssue.UpdatedBy="Admin";
            existingIssue.UpdatedOn=DateTime.Now;
            existingIssue.Version+=1;
            existingIssue.Active=true;
            existingIssue.Archived=false;
            existingIssue.BookId=issueModel.BookId;
            existingIssue.MemberId=issueModel.MemberId;
            existingIssue.IssueDate=issueModel.IssueDate;
            existingIssue.ReturnDate=issueModel.ReturnDate;
            existingIssue.IsReturned=issueModel.IsReturned;

            await container.CreateItemAsync(existingIssue);

            return Ok(new IssueModel
            {
                UId=existingIssue.UId,
                BookId=existingIssue.BookId,
                MemberId=existingIssue.MemberId,
                IssueDate=existingIssue.IssueDate,
                ReturnDate=existingIssue.ReturnDate,
                IsReturned=existingIssue.IsReturned
            });
        }
    }
}