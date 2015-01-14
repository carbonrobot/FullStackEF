namespace CCS.Services.Criteria
{
    using System.Linq;

    internal static class Extensions
    {
        public static IQueryable<T> Apply<T>(this IQueryable<T> query, SearchCriteria<T> criteria)
        {
            return criteria.ApplyTo(query);
        }
    }
}
