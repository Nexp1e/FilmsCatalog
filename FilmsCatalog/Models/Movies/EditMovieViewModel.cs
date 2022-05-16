using System.ComponentModel.DataAnnotations;

namespace FilmsCatalog.Models.Movies
{
    public class EditMovieViewModel
    {
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название*")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Описание*")]
        public string Description { get; set; }
        [Required]
        [Range(1800, 2050, ErrorMessage = "Обязательное поле")]
        [Display(Name = "Год выпуска*")]
        public int ReleaseYear { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Режиссер*")]
        public string Director { get; set; }
        public bool IsEditable { get; set; }
    }
}
