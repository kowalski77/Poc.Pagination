namespace Poc.Pagination;

internal static class PaginatorExtensions
{
    public static Paginator<T> Paginate<T>(this IQueryable<T> query,
            int page,
            int pageSize) => new(query, page, pageSize);
}
