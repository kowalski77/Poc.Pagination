namespace Poc.Pagination;

internal class Trip
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public required string Location { get; set; }

    public int Credits { get; set; }

    public double Distance { get; set; }
}
