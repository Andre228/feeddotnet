using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface INewsRepository
    {
        Task<List<NewsItem>> GetAllAsync();
        Task<NewsItem?> GetByIdAsync(Guid id);
        Task<NewsItem> CreateAsync(NewsItem newsItem);
        Task<NewsItem?> UpdateAsync(NewsItem newsItem, bool partialUpdate = false);
        Task<bool> DeleteAsync(Guid id);
    }
}
