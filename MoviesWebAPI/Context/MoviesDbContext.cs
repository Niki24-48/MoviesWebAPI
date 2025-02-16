using Microsoft.EntityFrameworkCore;
using MoviesWebAPI.Models;

namespace MoviesWebAPI.Context
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genere> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Movie_cast> Movies_Casts { get; set; }

        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie_cast>().HasNoKey();

        }



    }
}
