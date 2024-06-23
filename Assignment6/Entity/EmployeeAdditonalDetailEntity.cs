using Assignmentfifth.Overall;
using Newtonsoft.Json;

namespace Assignmentfifth.Entity
{
    public class EmployeeAdditionalDetailsEntity : BaseEntity
    {

        [JsonProperty(PropertyName = "alternateEmail", NullValueHandling = NullValueHandling.Ignore)]
        public string AlternateEmail { get; set; }


        [JsonProperty(PropertyName = "alternateMobile", NullValueHandling = NullValueHandling.Ignore)]
        public string AlternateMobile { get; set; }


        [JsonProperty(PropertyName = "workInformation", NullValueHandling = NullValueHandling.Ignore)]
        public WorkInfo WorkInformation { get; set; }


        [JsonProperty(PropertyName = "personalDetails", NullValueHandling = NullValueHandling.Ignore)]
        public PersonalDetail PersonalDetails { get; set; }


        [JsonProperty(PropertyName = "identityInformation", NullValueHandling = NullValueHandling.Ignore)]
        public IdentifyInfo IdentityInformation { get; set; }
    }
}
