namespace SOA3Bioscoop.Strategies;

public class FreeTicketStrategy : IDiscountStrategy
{
    public decimal CalculatePriceAfterDiscount(decimal currentPrice, int ticketNumber, MovieTicket ticket, Order order)
    {
        throw new NotImplementedException();
    }
}