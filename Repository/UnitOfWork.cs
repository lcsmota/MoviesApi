using MoviesApi.Context;
using MoviesApi.Contracts;

namespace MoviesApi.Repository;

public class UnitOfWork : IUnitOfWork
{
    private IMovieRepository movieRepo;
    private IStarRepository starRepo;
    private readonly MovieContext context;
    public UnitOfWork(MovieContext context)
    {
        this.context = context;
    }

    public IMovieRepository MoviesRepository =>
        movieRepo ??= new MovieRepository(context);

    public IStarRepository StarsRepository =>
        starRepo ??= new StarRepository(context);

    public async Task Commit()
        => await context.SaveChangesAsync();

    public void Dispose()
        => context.Dispose();
}
