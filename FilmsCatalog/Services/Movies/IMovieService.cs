using System.Threading.Tasks;
using FilmsCatalog.Models.Movies;

namespace FilmsCatalog.Services.Movies
{
    public interface IMovieService
    {
        public Task<MoviesIndexViewModel> GetAllMovies(string userId);
        public Task<MovieDetailsViewModel> GetMovieDetails(int id, string userId);
        public Task AddMovie(AddMovieViewModel model, string userId);
        public Task EditMovie(EditMovieViewModel model, string userId);
    }
}
