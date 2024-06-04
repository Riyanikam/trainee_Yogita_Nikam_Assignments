using Newtonsoft.Json;

namespace LibManagementSystem.Models
{
    public class BookModel
    {
        [JsonProperty(PropertyName="uId")]
        public string UId {get ; set ;}

        [JsonProperty(PropertyName="title")]
        public string Title { get ; set  ;}

        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }

        [JsonProperty(PropertyName = "publishedDate")]
        public DateTime PublishedDate { get; set; }

        [JsonProperty(PropertyName = "isbn")]
        public string ISBN { get; set; }

        [JsonProperty(PropertyName = "isIssued")]
        public bool IsIssued { get; set; }

    }
}
