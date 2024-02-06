namespace SOA3Bioscoop;

public class MovieTicket
{
    private int RowNr { get; set; }
    private int SeatNr { get; set; }
    private bool IsPremium { get; set; }
    public MovieScreening MovieScreening { get; set; }
    
    public MovieTicket(MovieScreening movieScreening, int rowNr, int seatNr, bool isPremium)
    {
        this.RowNr = rowNr;
        this.SeatNr = seatNr;
        this.IsPremium = isPremium;
        this.MovieScreening = movieScreening;
    }
    
    public bool IsPremiumTicket()
    {
        return IsPremium;
    }
    
    public decimal GetPrice()
    {
        return MovieScreening.GetPricePerSeat();
    }

    public DateTime getScreeningData()
    {
        return MovieScreening.getScreeningData();
    }

    public override string ToString()
    {
        return $"Ticket voor rij {RowNr}, stoel {SeatNr} (prijs kaartje: {GetPrice()}, Premium: { IsPremiumTicket()})";
    }
}