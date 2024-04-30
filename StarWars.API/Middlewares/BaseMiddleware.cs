using StarWars.API.Middleares.Json;
using StarWars.API.Middleares.Security;
using StarWars.API.Middleares.Swagger;
using StarWars.API.Middleares.Versioning;

namespace StarWars.API.Middlewares
{
    public static class BaseMiddleware
	{
		public static IServiceCollection AddMiddlewares(
			this IServiceCollection services)
		{
            services.AddCors();
            services.AddLogging();
            services.AddSecurity();
            services.AddJsonConfig();
            services.AddSwaggerDocs();
            services.AddApiVersioningConfig();

            // Aplicação de cache para todos endpoints
            services.AddOutputCache(options =>
            {
                options.AddBasePolicy(builder => builder.Expire(TimeSpan.FromMinutes(5)));
            });

            return services;
		}

		public static WebApplication UseMiddlewares(this WebApplication app)
		{
			app.UseSecurity();
			app.UseSwaggerDocs();

            return app;
		}
    }
}

