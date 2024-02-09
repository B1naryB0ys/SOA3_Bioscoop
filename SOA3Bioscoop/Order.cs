using SOA3Bioscoop.Strategies;

namespace SOA3Bioscoop;

public class Order
{
    private int OrderNr { get; set; }
    private bool IsStudentOrder { get; set; }
    public List<MovieTicket> Tickets { get; set; } = new();
    private readonly IEnumerable<IDiscountStrategy> discountStrategies = new List<IDiscountStrategy>();


    public Order(int orderNr, bool isStudentOrder, IEnumerable<IDiscountStrategy> discountStrategies)
    {
        this.OrderNr = orderNr;
        this.IsStudentOrder = isStudentOrder;
        this.discountStrategies= discountStrategies;
    }
    public int GetOrderNr()
    {
        return OrderNr;
    }

    public void AddSeatReservation(MovieTicket ticket)
    {

    }

    public bool StudentOrder()
    {
        return this.IsStudentOrder;
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
        decimal total = decimal.Zero;

        for (int i = 0; i < Tickets.Count; i++)
        {
            var ticket = Tickets[i];
            var ticketPrice = ticket.GetPrice();

            foreach (var discountStrategy in this.discountStrategies)
                if (ticketPrice > decimal.Zero)
                    ticketPrice = discountStrategy.CalculatePriceAfterDiscount(ticketPrice, i + 1, ticket, this);

            total += ticketPrice;
        }

        return total;
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