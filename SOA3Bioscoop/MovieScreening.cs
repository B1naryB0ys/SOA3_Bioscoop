using System.Xml.Linq;

namespace SOA3Bioscoop;

public class MovieScreening
{
    private DateTime DateAndTimeScreening { get; set; }
    private decimal PricePerSeat { get; set; }
    public Movie Movie { get; set; }
    public List<MovieTicket> Tickets { get; set; } = new();
    
    public MovieScreening(Movie movie, DateTime dateAndTime, decimal pricePerSeat)
    {
        this.DateAndTimeScreening = dateAndTime;
        this.PricePerSeat = pricePerSeat;
        this.Movie = movie;
    }
    
    public decimal GetPricePerSeat()
    {
        return PricePerSeat;
    }

    public DateTime getScreeningData()
    {
        return DateAndTimeScreening;
    }

    public override string ToString()
    {
        return $"{Movie.ToString} draait om {DateAndTimeScreening}, een standaard kaartje kost {PricePerSeat} euro.";

    }
}