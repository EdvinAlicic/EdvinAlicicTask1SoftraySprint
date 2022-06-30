using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdvinAlicicTask1SoftraySprint.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Song> Songs { get; set; } = new List<Song>();
        public Category(string Name)
        {
            this.Name = Name;
        }
    }
}
