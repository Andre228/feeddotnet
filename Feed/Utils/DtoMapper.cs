using DataAccess.Entities;
using Feed.Dto;

namespace Feed.Utils
{
    public static class DtoMapper
    {
        public static NewsItem MapToNewsItem(INewsItemDto item, Guid id)
        {

            var updatedItem = new NewsItem
            {
                Id = id,
                Title = item.Title?.Trim() ?? "Untitled",
                Description = item.Description?.Trim() ?? "",
                ImageUrl = string.IsNullOrWhiteSpace(item.ImageUrl) ? "" : item.ImageUrl,
                UpdatedAt = DateTime.UtcNow
            };

            return updatedItem;
        }

    }
}
