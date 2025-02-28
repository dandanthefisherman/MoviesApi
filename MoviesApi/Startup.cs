using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;
using MoviesApi.Repositories;
using MoviesApi.Services;

namespace MoviesApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddDbContext<MoviesDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MoviesDbConnection")));
        services.AddSwaggerGen();
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IMovieRepository, MovieRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies API v1"));

        // Seed the database here after configuring the app
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<MoviesDbContext>();
            dbContext.Database.Migrate();  // Ensure any pending migrations are applied
            SeedData.Initialize(scope.ServiceProvider, dbContext).Wait(); // Seed data
        }
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}