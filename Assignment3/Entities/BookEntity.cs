using Newtonsoft.Json;

namespace LibManagementSystem.Entities
{
    public class BookEntity
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "uId")]
        public string UId { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }

        [JsonProperty(PropertyName = "publishedDate")]
        public DateTime PublishedDate { get; set; }

        [JsonProperty(PropertyName = "isbn")]
        public string ISBN { get; set; }

        [JsonProperty(PropertyName = "isIssued")]
        public bool IsIssued { get; set; }

        [JsonProperty(PropertyName = "documentType")]
        public string DocumentType { get; set; }

        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "updatedBy")]
        public string UpdatedBy { get; set; }

        [JsonProperty(PropertyName = "updatedOn")]
        public DateTime UpdatedOn { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "archived")]
        public bool Archived { get; set; }
        public int Version { get; set; }

    }
}
