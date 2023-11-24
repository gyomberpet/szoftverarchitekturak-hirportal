using Microsoft.EntityFrameworkCore;
using NewsPortal.WebAppApi.Data;
using NewsPortal.WebAppApi.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NewsPortal.WebAppApi.Repositories
{
	public class CategoriesRepository : ICategoriesRepository
	{
		private readonly DataContext context;
		public CategoriesRepository(DataContext context)
		{
			this.context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public async Task<IEnumerable<NewsCategory>> GetCategories()
		{
			var categories = await context.NewsCategories
				.ToListAsync();

			return categories;
		}

		public async Task<NewsCategory> GetCategoryByName(string name)
		{
			var category = await context.NewsCategories
				.FirstOrDefaultAsync(c => c.Name == name);

			return category;
		}
	}
}
