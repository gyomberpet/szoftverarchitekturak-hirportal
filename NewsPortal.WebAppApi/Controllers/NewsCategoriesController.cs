using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.WebAppApi.Models;
using NewsPortal.WebAppApi.Repositories;

namespace NewsPortal.WebAppApi.Controllers
{
    [Route("api/v1/newscategories")]
    [ApiController]
    //[Authorize]
    public class NewsCategoriesController : ControllerBase
    {
        private readonly INewsCategoriesRepository newsCategoriesRepository;
        private readonly IConfiguration configuration;

        public NewsCategoriesController(IConfiguration configuration, INewsCategoriesRepository newsCategoriesRepository)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.newsCategoriesRepository = newsCategoriesRepository ?? throw new ArgumentNullException(nameof(newsCategoriesRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsCategory>>> GetCategories()
        {
            var categories = await newsCategoriesRepository.ListCategories();

            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<NewsCategory>> AddNewsCategory([FromBody] NewsCategory newsCategory)
        {
            if (newsCategory == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await newsCategoriesRepository.AddNewsCategory(newsCategory);

            return Ok(created);
        }


    }
}
