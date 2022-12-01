using Microsoft.EntityFrameworkCore;
using MoviesApi.Context;
using MoviesApi.Contracts;
using MoviesApi.Models;

namespace MoviesApi.Repository;

public class MovieRepository : Repository<Movie>, IMovieRepository
{
    public MovieRepository(MovieContext context)
        : base(context)
    {

    }
}
