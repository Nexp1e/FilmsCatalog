using FilmsCatalog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.Repositories.Movies
{
    public interface IMovieRepository
    {
        public Task<List<Movie>> GetAllMovies();
        public Task<Movie> GetMovieById(int id);
        public Task AddMovie(Movie movie);
        public Task EditMovie(Movie movie);
    }
}
