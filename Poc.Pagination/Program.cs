using Poc.Pagination;

Console.WriteLine("Functional pagination PoC");

IQueryable<Trip> trips = TripGenerator.Generate();

Paginator<Trip> paginator = trips.Paginate(5, 10);

Console.WriteLine("Total trips: {0}", paginator.Total);

