namespace Poc.Pagination;

public sealed class Paginator<T>
{
    private IQueryable<T> Query { get; }
    
    internal Paginator(
            IQueryable<T> query,
            int page,
            int pageSize)
    {
        this.Query = query.NonNull();
        this.Page = page.NonNegativeOrZero();
        this.PageSize = pageSize.NonNegativeOrZero();
        this.Total = query.Count();
    }

    public int Total { get; }

    public int Page { get; }

    public int OffSet => (this.Page - 1) * this.PageSize;

    public int PageSize { get; }

    public int PagesCount => (int)Math.Ceiling((double)Total / PageSize);

    public IReadOnlyList<T> Items => this.Query.Skip(this.OffSet).Take(this.PageSize).ToList().AsReadOnly();
}

internal static class PaginatorExtensions
{
    public static Paginator<T> Paginate<T>(this IQueryable<T> query,
            int page,
            int pageSize) => new(query, page, pageSize);
}

