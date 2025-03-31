namespace MovieRestApi.Models
{
    public class Director
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Movie> Movies { get; set; }



    }
}
