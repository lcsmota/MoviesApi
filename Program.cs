using Microsoft.EntityFrameworkCore;
using MoviesApi.Context;
using MoviesApi.Contracts;
using MoviesApi.Repository;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<MovieContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
    builder.Services.AddScoped<IMovieRepository, MovieRepository>();

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}