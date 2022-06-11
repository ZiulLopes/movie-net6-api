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
            modelBuilder.Entity<MovieEntity>().Property(m => m.Title).HasColumnName("TITLE").HasColumnType("varchar");
            modelBuilder.Entity<MovieEntity>().Property(m => m.DateAdd).HasColumnName("DATEADD").HasColumnType("varchar");
            modelBuilder.Entity<MovieEntity>().Property(m => m.Year).HasColumnName("YEAR").HasColumnType("int");
            modelBuilder.Entity<MovieEntity>().Property(m => m.Duration).HasColumnName("DURATION").HasColumnType("varchar");
            modelBuilder.Entity<MovieEntity>().Property(m => m.Description).HasColumnName("DESCRIPTION").HasColumnType("varchar");
            modelBuilder.Entity<MovieEntity>().Property(m => m.Rate).HasColumnName("RATE").HasColumnType("varchar");
        }
    }
}
