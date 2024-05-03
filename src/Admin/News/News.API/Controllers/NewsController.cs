using MediatR;
using Microsoft.AspNetCore.Mvc;
using News.Application.UseCases.NewsCases.Commands;
using News.Application.UseCases.NewsCases.Queries;
using News.Domain.Entities;

namespace News.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IMediator mediator;

        public NewsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateNews(CreateNewsCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<NewsModel>>> GetAllNews()
        {
            var result = await mediator.Send(new GetAllNewsQuery());

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetNewsByCategory(string category)
        {
            try
            {
                var query = new GetByCategoryNewsQuery { Category = category };
                var news = await mediator.Send(query);

                return Ok(news);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var query = new GetAllCategoriesQuery();
            var categories = await mediator.Send(query);
            return Ok(categories);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateNews(UpdateNewsCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteNews(DeleteNewsCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }
        
        [HttpPut]
        public async Task<ResponseModel> AddAttachment(CreateNewsCommand request)
        {
            var res = await mediator.Send(request);
            return res;
        }
    }
}
