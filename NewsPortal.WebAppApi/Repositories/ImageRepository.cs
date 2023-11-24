using Microsoft.EntityFrameworkCore;
using NewsPortal.WebAppApi.Data;
using NewsPortal.WebAppApi.Models;

namespace NewsPortal.WebAppApi.Repositories
{
	public class ImageRepository: IImageRepository
	{
		private readonly DataContext context;
		public ImageRepository(DataContext context)
		{
			this.context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public async Task<Image> UploadImage(Image image) 
		{
			context.Images.Add(image);
			await context.SaveChangesAsync();

			return image;
		}

		public async Task<Image> GetImage(string id)
		{
			var image = await context.Images.FindAsync(id);

			return image;
		}

		public async Task<bool> DeleteImage(string id)
		{
			var image = await context.News.FindAsync(id);

			if (image == null)
			{
				return false;
			}

			context.News.Remove(image);
			await context.SaveChangesAsync();

			return true;
		}
	}
}
