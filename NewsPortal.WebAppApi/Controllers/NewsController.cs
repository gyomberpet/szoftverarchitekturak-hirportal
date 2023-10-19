using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using NewsPortal.WebAppApi.Models;

namespace NewsPortal.WebAppApi.Controllers
{
	[ApiController]
	public class NewsController : ControllerBase
	{

		private readonly ILogger<NewsController> logger;

		public NewsController(ILogger<NewsController> logger)
		{
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		[Route("api/v1/news/{id}")]
		[HttpGet]
		public async Task<ActionResult<News>> GetNewsById(string id)
		{
			var news = new News();

			return new OkObjectResult(news);
		}
	}
}