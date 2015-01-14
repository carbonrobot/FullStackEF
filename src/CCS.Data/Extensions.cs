namespace CCS.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq.Expressions;
    using Core;

    internal static class Extensions
    {
        /// <summary>
        /// Updates the entity.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <typeparam name="TContext">The type of the context.</typeparam>
        /// <param name="context">The data context.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>TContext.</returns>
        public static TContext Attach<T, TContext>(this TContext context, T entity)
            where T : class, IEntity
            where TContext : DataContext
        {
            if (entity.Id == 0)
            {
                context.Set<T>().Add(entity);
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            return context;
        }

        /// <summary>
        /// Provides a statically typed interface for db includes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="set">The set.</param>
        /// <param name="includes">The includes.</param>
        /// <returns>DbSet&lt;T&gt;.</returns>
        public static DbSet<T> Include<T>(this DbSet<T> set, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
            {
                foreach (var expression in includes)
                {
                    set.Include(expression);
                }
            }
            return set;
        }
    }
}