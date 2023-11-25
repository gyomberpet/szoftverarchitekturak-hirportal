namespace NewsPortal.WebAppApi.Models
{
	public class NewsRequestParams
	{
		public bool IncludeImage { get; set; }
		public string CategoryName { get; set; }
		public string SearchText { get; set; }
		public int PageSize { get; set; } = 10;
		public int PageIndex { get; set; } = 0;
	}
}
