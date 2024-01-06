namespace ConsoleApp1.Movies;

public class Movie
{
    public string Title { get; set; }
    public MovieType Type { get; set; }

    public Movie(string title, MovieType type)
    {
        Title = title;
        Type = type;
    }

    public enum MovieType
    {
        Children,
        Regular,
        NewRelease,
    }
}