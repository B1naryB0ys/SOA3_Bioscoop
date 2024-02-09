namespace SOA3Bioscoop.Strategies;

public class GroupDiscountStrategy : IDiscountStrategy
{
    private const decimal DISCOUNT_PERCENTAGE = 0.9m;
    private const decimal DISCOUNT_BARRIER = 6;
    public decimal CalculatePriceAfterDiscount(decimal currentPrice, int ticketNumber, MovieTicket ticket, Order order)
    {
        if(ticket.IsDateWeekend() && !order.StudentOrder() && order.Tickets.Count >= DISCOUNT_BARRIER)
        {
            currentPrice *= DISCOUNT_PERCENTAGE;
        }

        return currentPrice;
    }
}