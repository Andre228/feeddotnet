using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class NewsRepository : INewsRepository
    {

        private readonly ApplicationDbContext _context;

        public NewsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<NewsItem>> GetAllAsync()
        {
            return await _context.NewsItems.ToListAsync();
        }

        public async Task<NewsItem> CreateAsync(NewsItem newsItem)
        {
            if (newsItem == null)
                throw new ArgumentNullException(nameof(newsItem));

            await _context.NewsItems.AddAsync(newsItem);
            await _context.SaveChangesAsync();

            return newsItem;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var affectedRows = await _context.NewsItems
                                            .Where(n => n.Id == id)
                                            .ExecuteDeleteAsync();

            return affectedRows > 0;
        }

        public async Task<NewsItem?> GetByIdAsync(Guid id)
        {
            return await _context.NewsItems
                                .AsNoTracking()
                                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<NewsItem> UpdateAsync(NewsItem item, bool partialUpdate = false)
        {

            if (partialUpdate == true)
            {
                //var stub = new NewsItem();

                var affectedRows = await _context.NewsItems
                    .Where(n => n.Id == item.Id)
                    .ExecuteUpdateAsync(setters => setters
                        .SetProperty(n => n.Title, n => !string.IsNullOrEmpty(item.Title) ? item.Title : n.Title)
                        .SetProperty(n => n.Description, n => !string.IsNullOrEmpty(item.Description) ? item.Description : n.Description)
                        .SetProperty(n => n.ImageUrl, n => !string.IsNullOrEmpty(item.ImageUrl) ? item.ImageUrl : n.ImageUrl)
                        //.SetProperty(n => n.UpdatedAt, DateTime.UtcNow)
                    );

                return affectedRows > 0
                    ? await _context.NewsItems.FindAsync(item.Id)
                    : null;
            }
            else
            {
                var existingItem = await _context.NewsItems.FindAsync(item.Id);
                if (existingItem == null)
                    throw new Exception("This item is not exist");

                _context.Entry(existingItem).CurrentValues.SetValues(item);
                //existingItem.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return existingItem;
            }
        }
    }
}
