using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface INewsRepository
    {
        Task<List<NewsItem>> GetAllAsync();
        Task<NewsItem?> GetByIdAsync(Guid id);
        Task<NewsItem> CreateAsync(NewsItem newsItem);
        Task<NewsItem?> UpdateAsync(NewsItem newsItem, Action<NewsItem>? partialUpdate = null);
        Task<bool> DeleteAsync(Guid id);
    }
}
