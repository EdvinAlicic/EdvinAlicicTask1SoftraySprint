namespace EdvinAlicicTask1SoftraySprint.Models
{
    public class SongDto
    {
        public int Id { get; set; }
        public string songName { get; set; }
        public string authorName { get; set; }
        public string songUrl { get; set; }
        public int rating { get; set; }
        public bool isFavorite { get; set; }
    }
}
