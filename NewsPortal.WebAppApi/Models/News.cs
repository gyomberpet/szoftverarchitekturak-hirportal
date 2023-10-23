namespace NewsPortal.WebAppApi.Models
{
	public class News
	{
		public string? Id { get; set; }

		public string? Title { get; set; }

		public string? Subtitle { get; set; }
		
		public string? Category { get; set; }
		
		public string? Description { get; set; }

		public string? ImageUrl { get; set; }

		public bool IsTrending { get; set; }
	}
}
