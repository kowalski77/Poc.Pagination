using Bogus;

namespace Poc.Pagination;

internal static class TripGenerator
{
    public static IQueryable<Trip> Generate() => new Faker<Trip>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.Name, f => f.Address.City())
            .RuleFor(x => x.Description, f => f.Address.Direction())
            .RuleFor(x => x.Location, f => f.Address.Locale)
            .RuleFor(x => x.Credits, f => f.Random.Number(1, 10))
            .RuleFor(x => x.Distance, f => f.Random.Number(1, 50))
            .Generate(100)
            .AsQueryable();
}
