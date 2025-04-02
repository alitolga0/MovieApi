using System.Text.Json.Serialization;

namespace MovieRestApi.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public List<Movie>? Movies { get; set; }

    }
}
