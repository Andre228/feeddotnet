using DataAccess.Entities;
using DataAccess.Repositories;
using Feed.Dto;
using Feed.Utils;
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
        public async Task<ActionResult<NewsItem>> CreateNews([FromBody] NewsItemPostDto newsItemDto)
        {
            var newsItem = DtoMapper.MapToNewsItem(newsItemDto, Guid.NewGuid());
            var createdItem = await _newsRepository.CreateAsync(newsItem);
            return createdItem;
        }

        [HttpGet]
        public async Task<ActionResult<List<NewsItem>>> GetNews()
        {
            return await _newsRepository.GetAllAsync();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<List<NewsItem>>> UpdateNews(Guid id, [FromBody] NewsItemPutDto newsItem)
        {
            var updatedItem = DtoMapper.MapToNewsItem(newsItem, id);
            var result = await _newsRepository.UpdateAsync(updatedItem);
            return Ok(result);
        }

        [HttpPatch("{id:guid}")]
        public async Task<ActionResult<List<NewsItem>>> UpdateNewsPartial(Guid id, [FromBody] NewsItemPatchDto newsItem)
        {
            var updatedItem = DtoMapper.MapToNewsItem(newsItem, id);
            var result = await _newsRepository.UpdateAsync(updatedItem, true);

            if (result == null)
            {
                return StatusCode(500, "Failed to update news item");
            }

            return Ok(result);
        }
    }
}
