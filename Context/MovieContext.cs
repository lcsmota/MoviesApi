using Microsoft.EntityFrameworkCore;
using MoviesApi.Models;

namespace MoviesApi.Context;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options)
        : base(options) { }

    DbSet<Movie> Movies { get; set; } = null!;
    DbSet<Star> Stars { get; set; } = null!;
}
