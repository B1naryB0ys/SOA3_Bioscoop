namespace SOA3Bioscoop.Strategies;

public interface IDiscountStrategy
{
    public decimal CalculatePriceAfterDiscount(decimal currentPrice, int ticketNumber, MovieTicket ticket, Order order);
}