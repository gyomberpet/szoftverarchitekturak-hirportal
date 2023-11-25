using NewsPortal.WebAppApi.Models;

namespace NewsPortal.WebAppApi.Repositories
{
    public interface INewsCategoriesRepository
    {
        public Task<IEnumerable<NewsCategory>> ListCategories();
        public Task<NewsCategory> AddNewsCategory(NewsCategory category);
        
    }
}
