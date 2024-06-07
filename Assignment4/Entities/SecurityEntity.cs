using Newtonsoft.Json;
namespace VisitorSecuritySys.Entities
{
    public class SecurityEntity
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "shift")]
        public string Shift { get; set; }

        [JsonProperty(PropertyName = "assignedLocation")]
        public string AssignedLocation { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }


    }
}
