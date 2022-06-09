using Microsoft.EntityFrameworkCore;
using Movie.Core.Model;

namespace Movie.Core.Repository
{
    public class MovieDbContext : DbContext
    {
        public DbSet<MovieEntity> Movie { get; set; }

        public MovieDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MovieEntity>().HasKey(m => m.Id);
            modelBuilder.Entity<MovieEntity>().Property(m => m.Id).HasColumnName("ID").HasColumnType("int").IsRequired();
            modelBuilder.Entity<MovieEntity>().Property(m => m.Title).HasColumnName("TITLE").HasColumnType("varchar").IsRequired();
        }
    }
}
