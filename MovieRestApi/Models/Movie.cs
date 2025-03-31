namespace MovieRestApi.Models
{
    public class Movie:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid DirectorId { get; set; }

        public List<Category>? Categories { get; set; }
        public List<Actor>? Actors { get; set; }
        public Director? Director { get; set; }

    }
}

