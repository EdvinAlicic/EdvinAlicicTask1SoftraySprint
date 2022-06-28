namespace EdvinAlicicTask1SoftraySprint.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Song> Songs { get; set; } = new List<Song>();
        public Category(string Name)
        {
            this.Name = Name;
        }
    }
}
