namespace Poc.Pagination;

internal class Paginator<T>
{
    private readonly IQueryable<T> query;

    public Paginator(IQueryable<T> query,
            int page,
            int pageSize)
    {
        this.query = query.NonNull();
        this.Page = page.NonNegativeOrZero();
        this.PageSize = pageSize.NonNegativeOrZero();
        this.Total = query.Count();
    }

    public int Total { get; }

    public int Page { get; }

    public int OffSet => (this.Page - 1) * this.PageSize;

    public int PageSize { get; }

    public int PagesCount => (int)Math.Ceiling((double)Total / PageSize);

    public IReadOnlyList<T> Items => this.query.Skip(this.OffSet).Take(this.PageSize).ToList().AsReadOnly();
}
