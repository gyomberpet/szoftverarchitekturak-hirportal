using NewsPortal.WebAppApi.Models;

namespace NewsPortal.WebAppApi.Repositories
{
	public interface ICategoriesRepository
	{
		public Task<IEnumerable<NewsCategory>> GetCategories();

		public Task<NewsCategory> GetCategoryByName(string name);
	}
}
