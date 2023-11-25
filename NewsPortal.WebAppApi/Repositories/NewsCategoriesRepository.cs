using Microsoft.EntityFrameworkCore;
using NewsPortal.WebAppApi.Data;
using NewsPortal.WebAppApi.Models;

namespace NewsPortal.WebAppApi.Repositories
{
    public class NewsCategoriesRepository : INewsCategoriesRepository
    {
        private readonly DataContext context;

        public NewsCategoriesRepository(DataContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<NewsCategory>> ListCategories()
        {
            var categories = await context.NewsCategories.ToListAsync();

            return categories;
        }

        public async Task<NewsCategory> AddNewsCategory(NewsCategory category)
        {
            context.NewsCategories.Add(category);
            await context.SaveChangesAsync();

            return category;
        }
    }
}
