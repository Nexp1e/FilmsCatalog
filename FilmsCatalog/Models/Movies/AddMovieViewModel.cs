using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FilmsCatalog.Models.Movies
{
    public class AddMovieViewModel
    {
        [Required]
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Required]
        [Range(1800, 2050)]
        [Display(Name = "Год выпуска")]
        public int ReleaseYear { get; set; }
        [Required]
        [Display(Name = "Режиссер")]
        public string Director { get; set; }
        public IFormFile File { get; set; }
    }
}
