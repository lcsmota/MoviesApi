using MoviesApi.Context;
using MoviesApi.Contracts;
using MoviesApi.Models;

namespace MoviesApi.Repository;

public class StarRepository : Repository<Star>, IStarRepository
{
    public StarRepository(MovieContext context)
        : base(context) { }
}
