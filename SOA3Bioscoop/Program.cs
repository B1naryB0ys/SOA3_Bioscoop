using SOA3Bioscoop;

// Movie and screening
Movie movie = new("The Matrix");
MovieScreening screening = new(movie, DateTime.Now, 10);

// Create tickets for the screening
MovieTicket ticket = new(screening, 1, 1, true);
MovieTicket ticket2 = new(screening, 1, 2, true);
MovieTicket ticket3 = new(screening, 1, 3, true);
MovieTicket ticket4 = new(screening, 1, 4, true);
MovieTicket ticket5 = new(screening, 1, 5, true);
MovieTicket ticket6 = new(screening, 1, 6, true);

// Create order
Order order = new(1, true);
order.AddTicket(ticket);
order.AddTicket(ticket2);
order.AddTicket(ticket3);
order.AddTicket(ticket4);
order.AddTicket(ticket5);
order.AddTicket(ticket6);

Console.WriteLine(order.CalculatePrice());
order.Export(TicketExportFormat.PLAINTEXT);


