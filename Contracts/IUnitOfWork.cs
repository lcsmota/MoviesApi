namespace MoviesApi.Contracts;

public interface IUnitOfWork
{
    public IMovieRepository MoviesRepository { get; }
    public IStarRepository StarsRepository { get; }
    Task Commit();
}
