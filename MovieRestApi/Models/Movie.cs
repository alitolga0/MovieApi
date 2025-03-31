namespace MovieRestApi.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Director Director { get; set; }
        public Guid DirectorId { get; set; }
        public List<Category>Categories { get; set; }
        public Guid CategoryId { get; set; }
        public List<Actor> Actors { get; set; }
        public Guid ActorId { get; set; }


    }
 }

