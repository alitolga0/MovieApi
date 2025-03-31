using Microsoft.EntityFrameworkCore;
using MovieRestApi.Models;

namespace MovieRestApi.Repository
{
    public class MainDbContext: DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) {
        
        }

        protected override  void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movie>()
                .Property(x => x.Name).IsRequired(true);
            
            builder.Entity<Movie>()
              .HasOne(d => d.Director)
              .WithMany(m => m.Movies)
              .HasForeignKey(d => d.DirectorId);

            builder.Entity<Movie>()
                .HasMany(c => c.Categories)
                .WithMany(m => m.Movies);

            builder.Entity<Movie>()
               .HasMany(a => a.Actors)
               .WithMany(m => m.Movies);


            builder.Entity<Category>()
               .Property(x => x.Name).IsRequired(true);

            builder.Entity<Director>()
                .Property(x => x.FirstName).IsRequired(true);
            builder.Entity<Director>()
                .Property(x => x.LastName).IsRequired(true);

            builder.Entity<Actor>()
           .Property(x => x.FirstName).IsRequired(true);
            builder.Entity<Actor>()
                .Property(x => x.LastName).IsRequired(true);


        }
    }
}
