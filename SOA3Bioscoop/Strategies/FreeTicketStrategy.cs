namespace SOA3Bioscoop.Strategies;

public class FreeTicketStrategy : IDiscountStrategy
{
    public decimal CalculatePriceAfterDiscount(decimal currentPrice, int ticketNumber, MovieTicket ticket, Order order)
    {
        if(order.StudentOrder() || !ticket.IsDateWeekend())
        {
            if(ticketNumber % 2 == 0)
            {
                return 0;
            }
        }
        return currentPrice;
    }
}