using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdvinAlicicTask1SoftraySprint.Entities
{
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string songName { get; set; }
        [Required]
        [MaxLength(50)]
        public string authorName { get; set; }
        public string songUrl { get; set; }
        [Range(1, 5)]
        public int rating { get; set; }
        public bool isFavorite { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public Song(string songName, string authorName)
        {
            this.songName = songName;
            this.authorName = authorName;
        }
    }
}
