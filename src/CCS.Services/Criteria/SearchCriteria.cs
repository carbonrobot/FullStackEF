namespace CCS.Services.Criteria
{
    using System.Linq;

    public abstract class SearchCriteria<T>
    {
        public abstract IQueryable<T> ApplyTo(IQueryable<T> query);
    }
}