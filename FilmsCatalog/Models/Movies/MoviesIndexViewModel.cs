using System.Collections.Generic;

namespace FilmsCatalog.Models.Movies
{
    public class MoviesIndexViewModel
    {
        public List<MoviePreviewViewModel> Movies { get; set; } = new List<MoviePreviewViewModel>();
        public int CurrentPageNumber { get; set; }
        public int LastPageNumber { get; set; }
        public List<int> DisplayedPageNumbers { get; set; } = new List<int>();
    }
}
