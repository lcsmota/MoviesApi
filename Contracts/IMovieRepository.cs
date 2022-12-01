using MoviesApi.Models;

namespace MoviesApi.Contracts;
public interface IMovieRepository
{
    Task<List<Movie>> GetMoviesAsync();
    Task<Movie> GetMovieByIdAsync(int id);
    Task<Movie> CreateMovieAsync(Movie movie);
    Task UpdateMovieAsync(int id, Movie movie);
    Task DeleteMovieAsync(int id);

}