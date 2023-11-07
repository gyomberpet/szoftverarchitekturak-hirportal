using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using NewsPortal.WebAppApi.Models;
using NewsPortal.WebAppApi.Repositories;

namespace NewsPortal.WebAppApi.Controllers
{
	[ApiController]
	[Route("api/v1/news")]
	[Authorize]
	public class NewsController : ControllerBase
	{

		private readonly ILogger<NewsController> logger;
		private readonly INewsRepository newsRepository;

		public NewsController(ILogger<NewsController> logger, INewsRepository newsRepository)
		{
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
			this.newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
		}

		[Route("{id}")]
		[HttpGet]
		[AllowAnonymous]
		public async Task<ActionResult<News>> GetNews(string id)
		{
			var news = await newsRepository.GetNews(id);

			if (news == null)
				return NotFound();

			return Ok(news);
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<ActionResult<IEnumerable<News>>> GetAllNews()
		{
			var newsList = await newsRepository.ListNews();

			return Ok(newsList);
		}

		[HttpGet]
		[Route("random/{category}/{amount}")]
		[AllowAnonymous]
		public async Task<ActionResult<IEnumerable<News>>> GetRandomNewsByCategory(string category, int amount)
		{
			var newsList = await newsRepository.GetRandomNewsByCategory(category, amount);

			return Ok(newsList);
		}


		[Route("category/{category}")]
		[AllowAnonymous]
		[HttpGet]
		public async Task<ActionResult<IEnumerable<News>>> GetNewsByCategory(string category)
		{
			var newsList = await newsRepository.ListNewsByCategory(category);

			return Ok(newsList);
		}

		[HttpPost]
		public async Task<ActionResult<News>> AddNews([FromBody] News news)
		{
			if (news == null) return BadRequest();

			var created = await newsRepository.AddNews(news);

			return Ok(created);
		}

		[HttpPut]
		public async Task<ActionResult<News>> UpdateNews([FromBody] News news)
		{
			if (news == null) return BadRequest();

			var updated = await newsRepository.UpdateNews(news);

			return Ok(updated);
		}

		[Route("{id}")]
		[HttpDelete]
		public async Task<ActionResult<bool>> DeleteNews(string id)
		{
			var news = newsRepository.GetNews(id);

			if (news == null)
			{
				return NotFound();
			}

			var isSuccess = await newsRepository.DeleteNews(id);

			if (!isSuccess)
			{
				return NotFound();
			}

			return NoContent();
		}
	}
}