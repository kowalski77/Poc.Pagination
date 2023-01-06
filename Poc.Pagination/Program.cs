using System.Linq.Expressions;
using Poc.Pagination;

Console.WriteLine("Functional pagination PoC");

IQueryable<Trip> trips = TripGenerator.Generate();

Expression<Func<Trip, object>> expression1 = t => t.Name;
Expression<Func<Trip, object>> expression2 = t => t.Distance;
Expression<Func<Trip, bool>> expression3 = t => t.Credits > 5;

IQueryable<Trip> filteredAndOrderedQuery = trips.OrderBy(expression1).ThenBy(expression2).Where(expression3);

Paginator<Trip> paginator = filteredAndOrderedQuery.Paginate(2, 10);

Console.WriteLine("Total trips: {0}", paginator.Total);

