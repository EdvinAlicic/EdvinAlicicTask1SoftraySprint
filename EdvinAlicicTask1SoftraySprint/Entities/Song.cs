namespace EdvinAlicicTask1SoftraySprint.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string songName { get; set; }
        public string authorName { get; set; }
        public string songUrl { get; set; }
        public int rating { get; set; }
        public bool isFavorite { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public Song(string songName, string authorName)
        {
            this.songName = songName;
            this.authorName = authorName;
        }
    }
}
