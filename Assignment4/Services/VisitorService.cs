using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VisitorSecuritySys.CosmosDB;
using VisitorSecuritySys.DTO;
using VisitorSecuritySys.Entities;
using VisitorSecuritySys.Interface;

namespace VisitorSecuritySys.Service
{
    public class VisitorService : IVisitorService
    {
        private readonly ICosmosDBService cosmosDBService;

        public VisitorService(ICosmosDBService cosmosDBService)
        {
            cosmosDBService = cosmosDBService;
        }

        public async Task<VisitorDTO> AddVisitor(VisitorDTO visitorDto)
        {
            if (visitorDto == null)
            {
                throw new ArgumentNullException(nameof(visitorDto), "Visitor DTO cannot be null.");
            }

            var visitorEntity = new VisitorEntity
            {
                Id = visitorDto.Id,
                Name = visitorDto.Name,
                Email = visitorDto.Email,
                Phone = visitorDto.PhoneNumber,
                Department = "Department", 
                Location = "Location"
            };

            var response = await cosmosDBService.AddVisitor(visitorEntity);

            var responseModel = new VisitorDTO
            {
                Id = response.Id,
                Name = response.Name,
                Email = response.Email,
                PhoneNumber = response.Phone,
            };

            return responseModel;
        }

        public async Task<VisitorDTO> GetVisitorById(string id)
        {
            var visitor = await cosmosDBService.GetVisitorById(id);

            if (visitor == null)
            {
                return null;
            }

            var visitorDto = new VisitorDTO
            {
                Id = visitor.Id,
                Name = visitor.Name,
                Email = visitor.Email,
                PhoneNumber = visitor.Phone,
            };

            return visitorDto;
        }

        public async Task<IEnumerable<VisitorDTO>> GetAllVisitor()
        {
            var visitors = await cosmosDBService.GetAllVisitors();

            var visitorDtos = new List<VisitorDTO>();
            foreach (var visitor in visitors)
            {
                var visitorDto = new VisitorDTO
                {
                    Id = visitor.Id,
                    Name = visitor.Name,
                    Email = visitor.Email,
                    PhoneNumber = visitor.Phone,
                };
                visitorDtos.Add(visitorDto);
            }

            return visitorDtos;
        }

        public async Task<VisitorDTO> UpdateVisitor(VisitorDTO visitorDto)
        {
            if (visitorDto == null)
            {
                throw new ArgumentNullException(nameof(visitorDto), "Visitor DTO cannot be null.");
            }

            var visitorEntity = new VisitorEntity
            {
                Id = visitorDto.Id,
                Name = visitorDto.Name,
                Email = visitorDto.Email,
                Phone = visitorDto.PhoneNumber,
                Department = "Department", 
                Location = "Location"
            };

            var response = await cosmosDBService.UpdateVisitor(visitorEntity);

            var responseModel = new VisitorDTO
            {
                Id = response.Id,
                Name = response.Name,
                Email = response.Email,
                PhoneNumber = response.Phone,
            };

            return responseModel;
        }

        public async Task DeleteVisitor(string id)
        {
            await cosmosDBService.DeleteVisitor(id);
        }
    }
}
