using Microsoft.EntityFrameworkCore;
using NewsPortal.WebAppApi.Models;

namespace NewsPortal.WebAppApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NewsDb;Trusted_Connection=True;");// Server=server name Database=db name 

        }
        public DbSet<News> News { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
