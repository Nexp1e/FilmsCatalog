using System.Collections.Generic;

namespace FilmsCatalog.Models.Movies
{
    public class MoviesIndexViewModel
    {
        public List<MoviePreviewViewModel> Movies { get; set; } = new List<MoviePreviewViewModel>();
    }
}
