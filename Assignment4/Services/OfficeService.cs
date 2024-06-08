using VisitorSecuritySys.CosmosDB;
using VisitorSecuritySys.DTO;
using VisitorSecuritySys.Entities;
using VisitorSecuritySys.Interface;

namespace VisitorSecuritySys.Service
{
    public class OfficeService : IOfficeService
    {
        private readonly ICosmosDBService cosmosDBService;

        public OfficeService(ICosmosDBService cosmosDBService)
        {
            cosmosDBService = cosmosDBService;
        }

        public async Task<OfficeDTO> AddOffice(OfficeDTO officeDto)
        {
            if (officeDto == null)
            {
                throw new ArgumentNullException(nameof(officeDto), "Office DTO cannot be null.");
            }

            var officeEntity = new OfficeEntity
            {
                Id = officeDto.Id,
                Name = officeDto.Name,
                Location = officeDto.Location
            };

            var response = await cosmosDBService.AddOffice(officeEntity);

            var responseModel = new OfficeDTO
            {
                Id = response.Id,
                Name = response.Name,
                Location = response.Location
            };

            return responseModel;
        }

        public async Task<OfficeDTO> GetOfficeById(string id)
        {
            var office = await cosmosDBService.GetOfficeById(id);

            if (office == null)
            {
                return null;
            }

            var officeDto = new OfficeDTO
            {
                Id = office.Id,
                Name = office.Name,
                Location = office.Location
            };

            return officeDto;
        }

        public async Task<IEnumerable<OfficeDTO>> GetAllOffices()
        {
            var offices = await cosmosDBService.GetAllOffices();

            var officeDtos = new List<OfficeDTO>();
            foreach (var office in offices)
            {
                var officeDto = new OfficeDTO
                {
                    Id = office.Id,
                    Name = office.Name,
                    Location = office.Location
                };
                officeDtos.Add(officeDto);
            }

            return officeDtos;
        }

        public async Task<OfficeDTO> UpdateOffice(OfficeDTO officeDto)
        {
            if (officeDto == null)
            {
                throw new ArgumentNullException(nameof(officeDto), "Office DTO cannot be null.");
            }

            var officeEntity = new OfficeEntity
            {
                Id = officeDto.Id,
                Name = officeDto.Name,
                Location = officeDto.Location
            };

            var response = await cosmosDBService.UpdateOffice(officeEntity);

            var responseModel = new OfficeDTO
            {
                Id = response.Id,
                Name = response.Name,
                Location = response.Location
            };

            return responseModel;
        }

        public async Task DeleteOffice(string id)
        {
            await cosmosDBService.DeleteOffice(id);
        }
    }
}
