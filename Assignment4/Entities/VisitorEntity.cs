namespace VisitorSecuritySys.Entities;
using Newtonsoft.Json;


public class VisitorEntity
{
    public string Id { get; set; }

    public string Name { get; set; }

    [JsonProperty(PropertyName = "email")]
    public string Email { get; set; }

    [JsonProperty(PropertyName = "phone")]
    public string Phone { get; set; }

    [JsonProperty(PropertyName = "department")]
    public string Department { get; set; }

    [JsonProperty(PropertyName = "location")]
    public string Location { get; set; }

    [JsonProperty(PropertyName = "active")]
    public bool Active { get; set; }


}
