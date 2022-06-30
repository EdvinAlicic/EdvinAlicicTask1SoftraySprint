using EdvinAlicicTask1SoftraySprint.DbContexts;
using EdvinAlicicTask1SoftraySprint.Entities;
using Microsoft.EntityFrameworkCore;

namespace EdvinAlicicTask1SoftraySprint.Services
{
    public class SongInfoRepository : ISongInfoRepository
    {

        private readonly SongInfoContext _context;

        public SongInfoRepository(SongInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddSongForCategoryAsync(int categoryId, Song song)
        {
            var category = await GetCategoryAsync(categoryId);
            if(category != null)
            {
                category.Songs.Add(song);
            }
        }

        public async Task<bool> CategoryExitsAsync(int categoryId)
        {
            return await _context.Categories.AnyAsync(c => c.Id == categoryId);
        }

        public void DeleteSongForCategoryAsync(Song song)
        {
            _context.Songs.Remove(song);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Category?> GetCategoryAsync(int categoryId)
        {
            return await _context.Categories.Where(c => c.Id == categoryId).FirstOrDefaultAsync();
        }

        public async Task<Song?> GetSongForCategory(int categoryId, int songId)
        {
            return await _context.Songs.Where(s => s.CategoryId == categoryId && s.Id == songId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Song>> GetSongsForCategory(int categoryId)
        {
            return await _context.Songs.Where(s => s.CategoryId == categoryId).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
