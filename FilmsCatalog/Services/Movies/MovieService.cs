using FilmsCatalog.Models.Movies;
using System.Threading.Tasks;

namespace FilmsCatalog.Services.Movies
{
    public class MovieService : IMovieService
    {
        public Task AddMovie(AddMovieViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task EditMovie(EditMovieViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task<MoviesIndexViewModel> GetAllMovies()
        {
            throw new System.NotImplementedException();
        }

        public Task<MovieDetailsViewModel> GetMovieDetails(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
