namespace MoviesApi.Contracts;

public interface IUnitOfWork
{
    public IMovieRepository MoviesRepository { get; }
    Task Commit();
}
