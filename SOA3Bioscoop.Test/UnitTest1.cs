namespace SOA3Bioscoop.Test;

public class OrderTest
{
    private Movie movieToTest = new Movie("The Matrix");
    
    [Fact]
    // 1. Test a order with 3 tickets (10 euro each), ordered by a student, on a weekend
    public void CalculatePrice_ShouldApplyStudentDiscount_ForStudentOrderInWeekendForThreeTickets()
    {
        // Arrange
        Order order = CreateFakeOrder(false, true, true, 10, 3);
        
        // Act
        decimal price = order.CalculatePrice();
        
        // Assert
        Assert.Equal(20, price);
    }
    
    [Fact]
    // 2. Test a order with 3 tickets (10 euro each), ordered by a student, on a weekday
    public void CalculatePrice_ShouldApplyStudentDiscount_ForStudentOrderInWeekdayForThreeTickets()
    {
        // Arrange
        Order order = CreateFakeOrder(false, true, false, 10, 3);
        
        // Act
        decimal price = order.CalculatePrice();
        
        // Assert
        Assert.Equal(20, price);
    }
    
    [Fact]
    // 3. Test a order with 3 tickets (10 euro each), ordered by a student, on a weekend
    public void CalculatePrice_ShouldApplyStudentDiscountAndGroupDiscount_ForStudentOrderInWeekendForSixTickets()
    {
        // Arrange
        Order order = CreateFakeOrder(false, true, true, 10, 6);
        
        // Act
        decimal price = order.CalculatePrice();
        
        // Assert
        Assert.Equal(27, price);
    }
    
    [Fact]
    // 4. Test a order with 3 PREMIUM tickets (10 euro each), ordered by a student, on a weekend
    public void CalculatePrice_ShouldApplyStudentDiscountAndPremiumDiscount_ForStudentOrderInWeekendForThreePremiumTickets()
    {
        // Arrange
        Order order = CreateFakeOrder(true, true, true, 10, 3);
        
        // Act
        decimal price = order.CalculatePrice();
        
        // Assert
        Assert.Equal(24, price);
    }
    
    [Fact]
    // 5. Test a order with 3 tickets (10 euro each), not ordered by a student, on a weekday
    public void CalculatePrice_ShouldApplyStudentDiscount_ForNonStudentOrderInWeekdayForThreeTickets()
    {
        // Arrange
        Order order = CreateFakeOrder(false, false, false, 10, 3);
        
        // Act
        decimal price = order.CalculatePrice();
        
        // Assert
        Assert.Equal(20, price);
    }
    
    [Fact]
    // 6. Test a order with 3 tickets (10 euro each), not ordered by a student, on a weekend
    public void CalculatePrice_ShouldNotApplyWeekendDiscount_ForNonStudentOrderInWeekendForThreeTickets()
    {
        // Arrange
        Order order = CreateFakeOrder(false, false, true, 10, 3);
        
        // Act
        decimal price = order.CalculatePrice();
        
        // Assert
        Assert.Equal(30, price);
    }

    private Order CreateFakeOrder(bool premiumSeat, bool isStudent, bool isWeekend, decimal ticketPrice, int ticketAmount)
    {
        DateTime date = isWeekend ? new DateTime(2024, 2, 3) : new DateTime(2024, 2, 6);
        MovieScreening movieScreening = new(movieToTest, date, ticketPrice);
        Order order = new(1, isStudent);
        for (int i = 0; i < ticketAmount; i++)
        {
            order.AddTicket(new MovieTicket(movieScreening, 1, 1, premiumSeat));
        }
        
        return order;
    }
}