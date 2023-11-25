using Microsoft.EntityFrameworkCore;
using NewsPortal.WebAppApi.Data;
using NewsPortal.WebAppApi.Models;
using System;
using System.Collections.Generic;

namespace NewsPortal.WebAppApi.Repositories
{
    public class NewsRepository : INewsRepository
    {
		private readonly DataContext context;

		public NewsRepository(DataContext context)
		{
			this.context = context ?? throw new ArgumentNullException(nameof(context));
		}
		public async Task<IEnumerable<News>> ListNews(NewsRequestParams param)
		{
			var query = context.News.AsQueryable();

			if (!string.IsNullOrWhiteSpace(param.CategoryName))
				query = query.Where(n => n.Category.Name == param.CategoryName);

			if (!string.IsNullOrWhiteSpace(param.SearchText))
				query = query.Where(n => 
					n.Title.Contains(param.SearchText) ||
					n.Subtitle.Contains(param.SearchText) ||
					n.Category.Name.Contains(param.SearchText));

			if (param.IncludeImage)
				query = query.Include(n => n.Image);

			var news = await query
				.Include(n => n.Category)
				.Skip(param.PageIndex * param.PageSize)
				.Take(param.PageSize)
				.ToListAsync();

			return news;
		}
		public async Task<News> GetNews(string id)
		{
			var news = await context.News
				.Include(n => n.Category)
				.Include(n => n.Image)
				.FirstOrDefaultAsync(n => n.Id == id);

			return news;
		}

		public async Task<IEnumerable<News>> GetRandomNewsByCategory(string categoryName, int amount)
		{
			var newsByCategory = await context.News
				.Where(n => n.Category.Name == categoryName)
				.OrderBy(x => Guid.NewGuid()) // Random order
				.Take(amount)
				.Include(n => n.Category)
				.Include(n => n.Image)
				.ToListAsync();

			return newsByCategory;
		}

		public async Task<News> AddNews(News news)
		{
			context.News.Add(news);
			await context.SaveChangesAsync();

			return news;
		}

		public async Task<News> UpdateNews(News news)
		{
			if (news == null) return news;

			context.News.Update(news);
			await context.SaveChangesAsync();

			return news;
		}

		public async Task<bool> DeleteNews(string id)
		{
			var news = await context.News.FindAsync(id);

			if (news == null)
			{
				return false;
			}

			context.News.Remove(news);
			await context.SaveChangesAsync();

			return true;
		}
	}
}
