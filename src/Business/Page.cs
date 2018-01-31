using System.Linq;

namespace BeerApp.Business
{
    public static class IOrderedQueryableExtensions
    {
        public static IQueryable<T> Page<T>(
            this IOrderedQueryable<T> query,
            int pageNumber,
            int pageLength
        ) where T : class =>
            query.Skip(pageNumber * pageLength).Take(pageLength);
    }
}
