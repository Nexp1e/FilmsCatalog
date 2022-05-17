using FilmsCatalog.Data;
using FilmsCatalog.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Repositories.Movies
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _db;

        public MovieRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddMovie(Movie movie)
        {
            await _db.Movies.AddAsync(movie);
            await _db.SaveChangesAsync();
        }

        public async Task EditMovie(Movie movie)
        {
            _db.Entry(movie).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            return await _db.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _db.Movies.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> GetMovieCount()
        {
            return await _db.Movies.CountAsync();
        }

        public async Task<List<Movie>> GetMoviePage(int pageNumber, int moviesPerPage)
        {
            return await _db.Movies.Skip((pageNumber - 1) * moviesPerPage).Take(moviesPerPage).ToListAsync();
        }
    }
}
