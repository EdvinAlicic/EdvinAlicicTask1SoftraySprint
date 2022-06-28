namespace EdvinAlicicTask1SoftraySprint.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SongDto> Songs { get; set; } = new List<SongDto>();
    }
}
