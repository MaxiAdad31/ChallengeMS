using Microsoft.EntityFrameworkCore;

namespace MakingSense.DataContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
        {
        }
        public DbSet<Model.User> Users { get; set; }
        public DbSet<Model.Post> Posts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Blogging");
            //DataGenerator.DataGenerator.Initialize(this);
        }
    }
}
