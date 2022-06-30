using EdvinAlicicTask1SoftraySprint.Entities;
using Microsoft.EntityFrameworkCore;

namespace EdvinAlicicTask1SoftraySprint.DbContexts
{
    public class SongInfoContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<User> Users { get; set; }

        public SongInfoContext(DbContextOptions<SongInfoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category("Rock")
                {
                    Id = 1
                },
                new Category("Pop")
                {
                    Id = 2
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
