using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewsPortal.WebAppApi.Models
{
	public class News
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string CategoryID { get; set; }
        public string Content { get; set; }
        public bool IsTrending { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
		public string ImageUrl { get; set; }
	}
}
