using FilmsCatalog.Repositories.Movies;
using Microsoft.Extensions.DependencyInjection;

namespace FilmsCatalog.Extensions
{
    public static class RegisterRepositoriesExtension
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
        }
    }
}
