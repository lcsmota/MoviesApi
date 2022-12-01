using Microsoft.EntityFrameworkCore;
using MoviesApi.Context;
using MoviesApi.Contracts;
using MoviesApi.Models;

namespace MoviesApi.Repository;

public class MovieRepository : IMovieRepository
{
    private readonly MovieContext context;
    public MovieRepository(MovieContext context)
    {
        this.context = context;
    }

    public async Task<Movie> CreateMovieAsync(Movie movie)
    {
        context.Add(movie);
        await context.SaveChangesAsync();

        return movie;
    }

    public async Task<Movie> DeleteMovieAsync(int id)
    {
        var movie = await context.FindAsync<Movie>(id);

        if (movie is null) return movie;

        context.Remove(movie);
        await context.SaveChangesAsync();

        return movie;
    }

    public async Task<Movie> GetMovieByIdAsync(int id)
    {
        return await context.FindAsync<Movie>(id);
    }

    public async Task<List<Movie>> GetMoviesAsync()
    {
        return await context.Set<Movie>().AsNoTracking().ToListAsync();
    }

    public async Task<Movie> UpdateMovieAsync(int id, Movie movie)
    {
        context.Entry(movie).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return movie;
    }
}
