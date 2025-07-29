using DataAccess.Entities;
using DataAccess.Repositories;
using Feed.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Feed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpPost]
        public async Task<ActionResult<NewsItem>> CreateNews([FromBody] NewsItemDto newsItemDto)
        {
            var newsItem = new NewsItem
            {
                Id = Guid.NewGuid(),
                Title = newsItemDto.Title,
                Description = newsItemDto.Description,
                ImageUrl = newsItemDto.ImageUrl,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var createdItem = await _newsRepository.CreateAsync(newsItem);
            return createdItem;
        }
    }
}
