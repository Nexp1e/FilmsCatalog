using FilmsCatalog.Services.Movies;
using Microsoft.Extensions.DependencyInjection;

namespace FilmsCatalog.Extensions
{
    public static class RegisterServicesExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
        }
    }
}
