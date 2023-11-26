using NewsPortal.WebAppApi.Models;

namespace NewsPortal.WebAppApi.Repositories
{
    public interface INewsCategoriesRepository
    {
        public Task<IEnumerable<NewsCategory>> ListCategories();

        public Task<NewsCategory> GetCategoryByName(string name);

		public Task<NewsCategory> AddNewsCategory(NewsCategory category);
        
    }
}
