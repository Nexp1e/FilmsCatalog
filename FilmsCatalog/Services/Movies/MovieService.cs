using FilmsCatalog.Models;
using FilmsCatalog.Models.Movies;
using FilmsCatalog.Repositories.Movies;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _rep;
        private readonly IWebHostEnvironment _environment;

        private static string[] AllowedPosterFileExtensions { get; set; } = { "jpg", "jpeg", "png" };

        public MovieService(IMovieRepository rep, IWebHostEnvironment environment)
        {
            _rep = rep;
            _environment = environment;
        }

        public async Task AddMovie(AddMovieViewModel model, string userId)
        {
            var isFileAttached = model.File != null;
            var fileNameWithPath = string.Empty;

            if (isFileAttached)
            {
                var extension = Path.GetExtension(model.File.FileName).Replace(".", "");
                if (!AllowedPosterFileExtensions.Contains(extension))
                {
                    throw new ArgumentException("Attached file's extention is not supported");
                }
                fileNameWithPath = $"files/{Guid.NewGuid()}-{model.File.FileName}";
                using (var fs = new FileStream(Path.Combine(_environment.WebRootPath, fileNameWithPath), FileMode.Create))
                {
                    await model.File.CopyToAsync(fs);
                }
            }

            var newMovie = new Movie
            {
                Title = model.Title,
                Description = model.Description,
                ReleaseYear = model.ReleaseYear,
                Director = model.Director,
                PosterPath = fileNameWithPath,
                UserId = userId
            };

            await _rep.AddMovie(newMovie);
        }

        public async Task EditMovie(EditMovieViewModel model, string userId)
        {
            var movie = await _rep.GetMovieById(model.MovieId);

            if (movie.UserId != userId)
            {
                return;
            }

            movie.Title = model.Title;
            movie.Description = model.Description;
            movie.ReleaseYear = model.ReleaseYear;
            movie.Director = model.Director;


            await _rep.EditMovie(movie);
        }

        public async Task<MoviesIndexViewModel> GetAllMovies(string userId)
        {
            var movies = await _rep.GetAllMovies();

            var VM = new MoviesIndexViewModel();

            foreach (var movie in movies)
            {
                VM.Movies.Add(new MoviePreviewViewModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    ReleaseYear = movie.ReleaseYear,
                    Director = movie.Director,
                    IsEditable = (userId == movie.UserId)
                });
            }

            return VM;
        }

        public async Task<MovieDetailsViewModel> GetMovieDetails(int id, string userId)
        {
            var movie = await _rep.GetMovieById(id);

            if (movie == null)
            {
                return null;
            }

            var VM = new MovieDetailsViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                ReleaseYear = movie.ReleaseYear,
                Director = movie.Director,
                PosterPath = movie.PosterPath,
                IsEditable = (userId == movie.UserId)
            };

            return VM;
        }

        public async Task<EditMovieViewModel> GetMovieEditModel(int id, string userId)
        {
            var movie = await _rep.GetMovieById(id);

            if (movie == null)
            {
                return null;
            }

            var model = new EditMovieViewModel
            {
                MovieId = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                ReleaseYear = movie.ReleaseYear,
                Director = movie.Director,
                IsEditable = (userId == movie.UserId)
            };

            return model;
        }
    }
}
