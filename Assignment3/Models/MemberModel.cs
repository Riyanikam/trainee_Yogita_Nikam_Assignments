using Newtonsoft.Json;

namespace LibManagementSystem.Models
{
    public class MemberModel
    {
        [JsonProperty(PropertyName = "uId")]
        public string UId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

    }
}
