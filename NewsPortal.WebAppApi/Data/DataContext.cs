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
		public DbSet<Image> Images { get; set; }

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

			modelBuilder.Entity<Image>()
				.Property(i => i.Id)
				.ValueGeneratedOnAdd();


			modelBuilder.Entity<News>()
				.Navigation(x => x.Category)
				.UsePropertyAccessMode(PropertyAccessMode.Property);

			modelBuilder.Entity<News>()
				.Navigation(x => x.Image)
				.UsePropertyAccessMode(PropertyAccessMode.Property);


			modelBuilder.Entity<User>().HasData(
				new User { Id = "1", UserName = "gipszjakab", EmailAddress = "admin@kft.hu", Password = "1234", IsAdmin = true },
				new User { Id = "2", UserName = "shrek", EmailAddress = "onion@nasa.gov", Password = "1234", IsAdmin = false }
			);

			modelBuilder.Entity<News>().HasData(
				new News { Id = "1", Title = "Earthquake Shakes California", Subtitle = "Residents Urged to Stay Safe", CategoryID="1", Content= "A magnitude 5.5 earthquake rattled Southern California, causing minor damage to some buildings. Authorities are urging residents to remain cautious and prepared for potential aftershocks.", IsTrending=false },
				new News { Id = "2", Title = "New COVID-19 Variant Detected", Subtitle = "Health Officials Monitor Situation", CategoryID = "2", Content = "A new variant of the COVID-19 virus has been identified in several countries. Health officials are closely monitoring the situation and advising continued vaccination efforts.", IsTrending=false },
				new News { Id = "3", Title = "Tech Giant Launches New Smartphone", Subtitle = "Features High-Resolution Camera", CategoryID = "3", Content = "Tech enthusiasts rejoice as the leading tech company unveils its latest smartphone model, featuring a high-resolution camera and advanced AI capabilities.", IsTrending = true},
				new News { Id = "4", Title = "Apple Unveils the Latest iPhone 14 Pro Max", Subtitle = "A Game-Changer in Smartphone Technology", CategoryID = "3", Content = "Apple has just announced the iPhone 14 Pro Max, featuring a revolutionary foldable display and an AI-powered camera system. This device promises to redefine the smartphone landscape with its innovative features and sleek design.", IsTrending = true },
				new News { Id = "5", Title = "Google's Quantum Computing Breakthrough", Subtitle = "A Leap Toward Solving Complex Problems", CategoryID = "3", Content = "Google's quantum computing team has achieved a major milestone, demonstrating a quantum computer capable of solving complex problems faster than ever before. This breakthrough has the potential to impact fields such as cryptography, drug discovery, and climate modeling.", IsTrending = true },
				new News { Id = "6", Title = "Tesla's Self-Driving Cars Now Legal on U.S. Highways", Subtitle = "A New Era for Autonomous Vehicle", CategoryID = "3", Content = "In a historic move, the U.S. government has officially granted Tesla permission to deploy fully autonomous vehicles on public highways. Tesla's Autopilot system has reached a level of reliability and safety that is paving the way for a future with self-driving cars.", IsTrending = true }
				);

			modelBuilder.Entity<NewsCategory>().HasData(
				new NewsCategory { Id = "1", Name = "Nature" },
				new NewsCategory { Id = "2", Name = "Health" },
				new NewsCategory { Id = "3", Name = "Technology" }
			);
		}

	}
}
