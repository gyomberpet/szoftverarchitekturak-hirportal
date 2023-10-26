using System;

namespace NewsPortal.WebAppApi.Models
{
	public class News
	{
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public string? CategoryID { get; set; }
        public string? Content { get; set; }
        public bool? IsTrending { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
