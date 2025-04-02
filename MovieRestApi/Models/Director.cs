using System.Text.Json.Serialization;

namespace MovieRestApi.Models
{
    public class Director:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonIgnore]
        public List<Movie>? Movies { get; set; }

    }
}
