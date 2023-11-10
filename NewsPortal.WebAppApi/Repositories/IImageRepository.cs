using NewsPortal.WebAppApi.Models;

namespace NewsPortal.WebAppApi.Repositories
{
	public interface IImageRepository
	{
		public Task<Image> UploadImage(Image image);

		public Task<Image> GetImage(string id);
	}
}
