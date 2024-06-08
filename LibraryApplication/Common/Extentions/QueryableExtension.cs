using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.Common.Extentions
{
    public static class QueryableExtensions
    {
        public static async Task<List<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize, CancellationToken cancellationToken) where T : class
        {
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            return await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        }
    }

}
