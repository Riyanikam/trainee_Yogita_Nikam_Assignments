using Newtonsoft.Json;

namespace VisitorSecuritySys.DTO
{
    public class ManagerDTO
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "phoneNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "department", NullValueHandling = NullValueHandling.Ignore)]
        public string Department { get; set; }

        [JsonProperty(PropertyName = "location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }
    }
}
