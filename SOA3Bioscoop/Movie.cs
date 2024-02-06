namespace SOA3Bioscoop;

public class Movie
{
    private string Title { get; set; }
    
    public List<MovieScreening> Screenings { get; set; } = new();
    
    public Movie(string title)
    {
        this.Title = title;
    }
    
    public void AddScreening(MovieScreening screening)
    {
        
    }
    
    public override string ToString()
    {
        return this.Title;
    }
}