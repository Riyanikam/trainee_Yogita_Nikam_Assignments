using VisitorSecuritySys.CosmosDB;
using VisitorSecuritySys.DTO;
using VisitorSecuritySys.Entities;
using VisitorSecuritySys.Interface;

namespace VisitorSecuritySys.Service
{
    public class SecurityService : ISecurityService
    {
        private readonly ICosmosDBService _cosmosDBService;

        public SecurityService(ICosmosDBService cosmosDBService)
        {
            _cosmosDBService = cosmosDBService ?? throw new ArgumentNullException(nameof(cosmosDBService));
        }

        public async Task<SecurityDTO> AddSecurity(SecurityDTO securityDto)
        {
            if (securityDto == null)
            {
                throw new ArgumentNullException(nameof(securityDto), "Security DTO cannot be null.");
            }

            var securityEntity = new SecurityEntity
            {
                Id = securityDto.Id,
                Name = securityDto.Name,
                Email = securityDto.Email,
                Phone = securityDto.PhoneNumber,
                Shift = "Default Shift", 
                AssignedLocation = "Default Location"
            };

            var response = await _cosmosDBService.AddSecurity(securityEntity);

            var responseModel = new SecurityDTO
            {
                Id = response.Id,
                Name = response.Name,
                Email = response.Email,
                PhoneNumber = response.Phone
            };

            return responseModel;
        }

        public async Task<SecurityDTO> GetSecurityById(string id)
        {
            var security = await _cosmosDBService.GetSecurityById(id);

            if (security == null)
            {
                return null;
            }

            var securityDto = new SecurityDTO
            {
                Id = security.Id,
                Name = security.Name,
                Email = security.Email,
                PhoneNumber = security.Phone
            };

            return securityDto;
        }

        public async Task<IEnumerable<SecurityDTO>> GetAllSecurity()
        {
            var securities = await _cosmosDBService.GetAllSecurities();

            var securityDtos = new List<SecurityDTO>();
            foreach (var security in securities)
            {
                var securityDto = new SecurityDTO
                {
                    Id = security.Id,
                    Name = security.Name,
                    Email = security.Email,
                    PhoneNumber = security.Phone
                };
                securityDtos.Add(securityDto);
            }

            return securityDtos;
        }

        public async Task<SecurityDTO> UpdateSecurity(SecurityDTO securityDto)
        {
            if (securityDto == null)
            {
                throw new ArgumentNullException(nameof(securityDto), "Security DTO cannot be null.");
            }

            var securityEntity = new SecurityEntity
            {
                Id = securityDto.Id,
                Name = securityDto.Name,
                Email = securityDto.Email,
                Phone = securityDto.PhoneNumber,
                Shift = "Updated Shift", // Update properties as needed
                AssignedLocation = "Updated Location"
            };

            var response = await _cosmosDBService.UpdateSecurity(securityEntity);

            var responseModel = new SecurityDTO
            {
                Id = response.Id,
                Name = response.Name,
                Email = response.Email,
                PhoneNumber = response.Phone
            };

            return responseModel;
        }

        public async Task DeleteSecurity(string id)
        {
            await _cosmosDBService.DeleteSecurity(id);
        }
    }
}
