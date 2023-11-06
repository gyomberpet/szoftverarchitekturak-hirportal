using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NewsPortal.WebAppApi.Models;
using System.Reflection.Metadata;

namespace NewsPortal.WebAppApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
                
        }

        public DbSet<News> News { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<News>()
				.Property(n => n.Id)
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<NewsCategory>()
				.Property(n => n.Id)
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<User>()
				.Property(u => u.Id)
				.ValueGeneratedOnAdd();


			modelBuilder.Entity<News>()
				.Navigation(x => x.Category)
				.UsePropertyAccessMode(PropertyAccessMode.Property);


			modelBuilder.Entity<User>().HasData(
				new User { Id = "1", UserName = "gipszjakab", EmailAddress = "admin@kft.hu", Password = "1234", IsAdmin = true },
				new User { Id = "2", UserName = "shrek", EmailAddress = "onion@nasa.gov", Password = "1234", IsAdmin = false }
			);

			modelBuilder.Entity<News>().HasData(
				new News { Id = "1", Title = "Earthquake Shakes California", Subtitle = "Residents Urged to Stay Safe", CategoryID="1", Content= "A magnitude 5.5 earthquake rattled Southern California, causing minor damage to some buildings. Authorities are urging residents to remain cautious and prepared for potential aftershocks.", IsTrending=false },
				new News { Id = "2", Title = "New COVID-19 Variant Detected", Subtitle = "Health Officials Monitor Situation", CategoryID = "2", Content = "A new variant of the COVID-19 virus has been identified in several countries. Health officials are closely monitoring the situation and advising continued vaccination efforts.", IsTrending=false },
				new News { Id = "3", Title = "Tech Giant Launches New Smartphone", Subtitle = "Features High-Resolution Camera", CategoryID = "3", Content = "Tech enthusiasts rejoice as the leading tech company unveils its latest smartphone model, featuring a high-resolution camera and advanced AI capabilities.", IsTrending = true}
			);

			modelBuilder.Entity<NewsCategory>().HasData(
				new NewsCategory { Id = "1", Name = "Nature" },
				new NewsCategory { Id = "2", Name = "Health" },
				new NewsCategory { Id = "3", Name = "Technology" }
			);
		}

	}
}
