namespace MovieRestApi.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public List<Movie>? Movies { get; set; }

    }
}
