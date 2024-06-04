using LibManagementSystem.Entities;
using LibManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace LibManagementSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemberController : ControllerBase//It's a Controlller

    {
        //Parameter that are taken while making connection with the Database
        private string URI="https://localhost:8081";
        private string PrimaryKey="C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private string DatabaseName="batch4";
        private string ContainerName="student";

        private Microsoft.Azure.Cosmos.Container container;
        //Making a constructor of container
        public MemberController()
        {
            container=GetContainer();
        }

        private Microsoft.Azure.Cosmos.Container GetContainer()
        {
            CosmosClient cosmosClient=new CosmosClient(URI, PrimaryKey);
            Database database=cosmosClient.GetDatabase(DatabaseName);
            Microsoft.Azure.Cosmos.Container container = database.GetContainer(ContainerName);
            return container;
        }

        [HttpPost]
        public async Task<IActionResult>AddMember(MemberModel memberModel)
        {
            //mapping all the field from model to entity
            MemberEntity member =new MemberEntity
            {
                //Assign values
                Id = Guid.NewGuid().ToString(),
                UId=memberModel.UId,
                Name=memberModel.Name,
                DateOfBirth=memberModel.DateOfBirth,
                Email=memberModel.Email,
                DocumentType="member",
                CreatedBy="Admin",
                CreatedOn=DateTime.Now,
                UpdatedBy="",
                UpdatedOn=DateTime.Now,
                Active=true,
                Archived=false
            };
            //Adding value to Database
            ItemResponse<MemberEntity>response=await container.CreateItemAsync(member);
            return Ok(new MemberModel
            {
                //Return from the Model
                UId = response.Resource.UId,
                Name=response.Resource.Name,
                DateOfBirth=response.Resource.DateOfBirth,
                Email=response.Resource.Email
            });
        }

        [HttpGet]
        public IActionResult GetMemberByUId(string uId)
        {
            //Fetch the Records
            var query =container.GetItemLinqQueryable<MemberEntity>(true).Where(m => m.UId == uId && m.Active && !m.Archived).AsQueryable();
            MemberEntity member=query.FirstOrDefault();

            if (member==null)
            {
                return NotFound();
            }

            return Ok(new MemberModel
            {
                UId=member.UId,
                Name=member.Name,
                DateOfBirth=member.DateOfBirth,
                Email=member.Email
            });
        }

        [HttpGet]
        public IActionResult GetAllMembers()
        {
            //Fetch the Records
            var query =container.GetItemLinqQueryable<MemberEntity>(true).Where(m=>m.Active && !m.Archived).AsQueryable();
            List<MemberModel> members=query.Select(member => new MemberModel
            {
                UId=member.UId,
                Name=member.Name,
                DateOfBirth=member.DateOfBirth,
                Email=member.Email
            }).ToList();

            return Ok(members);//Return the values

        }

        [HttpPut]
        public async Task<IActionResult>UpdateMember(MemberModel memberModel)
        {
            //Fetch the Records
            var query = container.GetItemLinqQueryable<MemberEntity>(true).Where(m => m.UId == memberModel.UId && m.Active && !m.Archived).AsQueryable();
            MemberEntity existingMember=query.FirstOrDefault();

            if (existingMember==null)
            {
                return NotFound();
            }

            existingMember.Archived=true;
            existingMember.Active=false;
            await container.ReplaceItemAsync(existingMember,existingMember.Id);

            existingMember.Id=Guid.NewGuid().ToString();
            existingMember.UpdatedBy="Admin";
            existingMember.UpdatedOn=DateTime.Now;
            existingMember.Version+=1;
            existingMember.Active=true;
            existingMember.Archived=false;
            existingMember.Name=memberModel.Name;
            existingMember.DateOfBirth=memberModel.DateOfBirth;
            existingMember.Email=memberModel.Email;

            await container.CreateItemAsync(existingMember);

            return Ok(new MemberModel
            {
                UId=existingMember.UId,
                Name=existingMember.Name,
                DateOfBirth=existingMember.DateOfBirth,
                Email=existingMember.Email
            });
        }
    }
}
