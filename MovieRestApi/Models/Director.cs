namespace MovieRestApi.Models
{
    public class Director:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Movie>? Movies { get; set; }

    }
}
