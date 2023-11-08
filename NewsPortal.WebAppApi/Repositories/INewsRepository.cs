using NewsPortal.WebAppApi.Models;

namespace NewsPortal.WebAppApi.Repositories
{
    public interface INewsRepository
    {
		public Task<IEnumerable<News>> ListNews(NewsRequestParams param);
		public Task<News> GetNews(string id);
		public Task<IEnumerable<News>> GetRandomNewsByCategory(string categoryName, int amount);
		public Task<News> AddNews(News news);
		public Task<News> UpdateNews(News news);
		public Task<bool> DeleteNews(string id);
	}
}
