namespace ConsoleApp1.Movies;

public class Rental
{
    public Movie Movie { get; set; }
    public int DaysRented { get; set; }

    public Rental(Movie movie, int daysRented)
    {
        Movie = movie;
        DaysRented = daysRented;
    }
}