namespace SOA3Bioscoop;

public class Order
{
    private int OrderNr { get; set; }
    private bool IsStudentOrder { get; set; }
    public List<MovieTicket> Tickets { get; set; } = new();
    
    public Order(int orderNr, bool isStudentOrder)
    {
        this.OrderNr = orderNr;
        this.IsStudentOrder = isStudentOrder;
    }
    public int GetOrderNr()
    {
        return OrderNr;
    }

    public void AddSeatReservation(MovieTicket ticket)
    {

    }

    public void AddTicket(MovieTicket ticket)
    {
        Tickets.Add(ticket);
    }
    
    public List<MovieTicket> GetTickets()
    {
        return Tickets;
    }
    
    public decimal CalculatePrice()
    {   
        decimal totalPrice = 0;
           for(int i = 0; i < Tickets.Count; i++)
            {
                MovieTicket currentTicket = Tickets[i];
                DateTime screeningDate = currentTicket.getScreeningData();

                bool isWeekend = IsDateWeekend(currentTicket.getScreeningData());
                int ticketNumber = i + 1;

                decimal ticketPrice = currentTicket.GetPrice();

                if (currentTicket.IsPremiumTicket())
                {
                    ticketPrice += IsStudentOrder ? 2 : 3;
                }

                if(IsStudentOrder || !isWeekend)
                {
                    if(ticketNumber % 2 == 0)
                    {
                        ticketPrice = 0;
                    }
                }

                if(isWeekend && !IsStudentOrder && Tickets.Count >= 6)
                {
                    ticketPrice *= 0.9m;
                }

                totalPrice += ticketPrice;
            }
        return totalPrice;
    }

    public void Export(TicketExportFormat format)
    {
        switch (format)
        {
            case TicketExportFormat.PLAINTEXT:
                // Write to plain text file
                string directory = Directory.GetCurrentDirectory() + "/export.txt";
                File.WriteAllText($"{Directory.GetCurrentDirectory()}/export.txt", this.ToString());
                break;
            case TicketExportFormat.JSON:
                break;
        }
    }
    
    private bool IsDateWeekend(DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday; ;
    }
    
    public override string ToString()
    {
        string orderString = "";
        orderString += $"OrderNr: {OrderNr}, IsStudentOrder: {IsStudentOrder} Tickets: {Tickets.Count}";

        foreach (var ticket in Tickets)
        {
            orderString += $"\nTicket: {ticket.ToString()}";
        }

        return orderString;
    }
}