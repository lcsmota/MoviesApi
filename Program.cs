using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MoviesApi.Context;
using MoviesApi.Contracts;
using MoviesApi.Repository;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<MovieContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(sw =>
        sw.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "MovieCRUD",
            Version = "v1",
            Description = "Simple CRUD using Entity Framework 6"
        }));
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