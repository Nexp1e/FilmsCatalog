using System.ComponentModel.DataAnnotations;

namespace FilmsCatalog.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1800, 2050)]
        public int ReleaseYear { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string PosterPath { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}