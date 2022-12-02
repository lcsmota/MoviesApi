namespace MoviesApi.Models;

public class Star
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string? Nationality { get; set; }
    public DateTime BirthDate { get; set; }
    public bool WonOscar { get; set; }
}
