namespace FilmsCatalog.Models.Movies
{
    public class MovieDetailsViewModel : MoviePreviewViewModel
    {
        public string Description { get; set; }
        public string PosterPath { get; set; }
        public string AddedByInfo { get; set; }
    }
}
