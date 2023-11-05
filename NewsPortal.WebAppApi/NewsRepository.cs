using NewsPortal.WebAppApi.Models;
using System.Collections.Generic;

namespace NewsPortal.WebAppApi
{
    public class NewsRepository
    {
        private List<News> NewsList = new List<News>();
        public NewsRepository() 
        { 
            
        }

        public void Add(News n) 
        {
            NewsList.Add(n);
        }
        public News Get(string NewsId) 
        {
            return NewsList.FirstOrDefault(p => p.Id.Equals(NewsId));
        }

        public List<News> GetAll()
        {
            return NewsList;
        }

        public void Update(News updatedNews)
        {
            var existingNews = Get(updatedNews.Id);
            if (existingNews != null)
            {
                existingNews.Title = updatedNews.Title;
                existingNews.Subtitle = updatedNews.Subtitle;
                existingNews.CategoryID = updatedNews.CategoryID;
                existingNews.Content = updatedNews.Content;
                existingNews.IsTrending = updatedNews.IsTrending;
                existingNews.StartDate = updatedNews.StartDate;
                existingNews.EndDate = updatedNews.EndDate;
            }
        }

        // Delete a product.
        public void Delete(string NewsId)
        {
            // You can add data access logic here to delete the product.
            var newsToDelete = Get(NewsId);
            if (newsToDelete != null)
            {
                NewsList.Remove(newsToDelete);
            }
        }
    }
}
