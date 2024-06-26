﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewsPortal.WebAppApi.Models
{
	public class News
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string CategoryID { get; set; }
        public string Content { get; set; }
        public bool IsTrending { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
		public string ImageId { get; set; }
        public NewsCategory Category { get; set; }
        public Image Image { get; set; }
	}
}
