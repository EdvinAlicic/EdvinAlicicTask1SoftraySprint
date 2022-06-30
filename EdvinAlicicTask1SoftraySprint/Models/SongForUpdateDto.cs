using System.ComponentModel.DataAnnotations;

namespace EdvinAlicicTask1SoftraySprint.Models
{
    public class SongForUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string songName { get; set; }
        [Required]
        [MaxLength(50)]
        public string authorName { get; set; }
        [Required]
        public string songUrl { get; set; }
        [Required]
        [Range(1, 5)]
        public int rating { get; set; }
        public bool isFavorite { get; set; }
    }
}
