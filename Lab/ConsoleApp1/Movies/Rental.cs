namespace ConsoleApp1.Movies;

public class Rental
{
    public Movie Movie { get; set; }
    private int _daysRented;

    public Rental(Movie movie, int daysRented)
    {
        Movie = movie;
        _daysRented = daysRented;
    }

    public string GetTitle()
    {
        return Movie.Title;
    }

    public double GetCharge()
    {
        return Movie.GetCharge(_daysRented);
    }

    public int GetFrequentRenterPoints()
    {
        return Movie.GetFrequentRenterPoints(_daysRented);
    }
}