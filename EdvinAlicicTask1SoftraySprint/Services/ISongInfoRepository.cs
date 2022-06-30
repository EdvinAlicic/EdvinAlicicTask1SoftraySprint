using EdvinAlicicTask1SoftraySprint.Entities;

namespace EdvinAlicicTask1SoftraySprint.Services
{
    public interface ISongInfoRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryAsync(int categoryId);
        Task<bool> CategoryExitsAsync(int categoryId);
        Task<IEnumerable<Song>> GetSongsForCategory(int categoryId);
        Task<Song?> GetSongForCategory(int categoryId, int songId);
        Task AddSongForCategoryAsync(int categoryId, Song song);
        void DeleteSongForCategoryAsync(Song song);
        Task<bool> SaveChangesAsync();
    }
}
