namespace SOA3Bioscoop.Strategies;

public class PremiumDiscountStrategy : IDiscountStrategy
{
    private const decimal PREMIUM_STUDENT = 2;
    private const decimal PREMIUM_REGULAR = 3;
    public decimal CalculatePriceAfterDiscount(decimal currentPrice, int ticketNumber, MovieTicket ticket, Order order)
    {
        if(ticket.IsPremiumTicket()) { 
            return currentPrice + (order.StudentOrder() ? PREMIUM_STUDENT : PREMIUM_REGULAR);
        }
        return currentPrice;
    }
}