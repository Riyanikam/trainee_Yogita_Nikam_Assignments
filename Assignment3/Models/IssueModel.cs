using Newtonsoft.Json;

namespace LibManagementSystem.Models
{
    public class IssueModel
    {
        [JsonProperty(PropertyName = "uId")]
        public string UId { get; set; }

        [JsonProperty(PropertyName = "bookId")]
        public string BookId { get; set; }

        [JsonProperty(PropertyName = "memberId")]
        public string MemberId { get; set; }

        [JsonProperty(PropertyName = "issueDate")]
        public DateTime IssueDate { get; set; }

        [JsonProperty(PropertyName = "returnDate")]
        public DateTime? ReturnDate { get; set; }

        [JsonProperty(PropertyName = "isReturned")]
        public bool IsReturned { get; set; }


    }
}
