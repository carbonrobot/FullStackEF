namespace CCS.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Core;

    public interface IDataContext : IDisposable
    {
        /// <summary>
        /// Returns a queryable interface for an entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="includes">The includes.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        IQueryable<T> AsQueryable<T>(params Expression<Func<T, object>>[] includes) where T : class, IEntity;

        /// <summary>
        /// Deletes a single entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <returns>True if successful</returns>
        bool Delete<T>(int id) where T : class, IEntity;

        /// <summary>
        /// Deletes a single entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        /// <returns>True if successful</returns>
        /// <exception cref="ArgumentNullException" />
        bool Delete<T>(T entity) where T : class, IEntity;

        /// <summary>
        /// Deletes a single entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <returns>True if successful</returns>
        Task<bool> DeleteAsync<T>(int id) where T : class, IEntity;

        /// <summary>
        /// Deletes a single entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        /// <returns>True if successful</returns>
        /// <exception cref="ArgumentNullException" />
        Task<bool> DeleteAsync<T>(T entity) where T : class, IEntity;

        /// <summary>
        /// Returns a single entity or null if not found.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <param name="includes">The includes.</param>
        /// <returns>T.</returns>
        T Find<T>(int id, params Expression<Func<T, object>>[] includes) where T : class, IEntity;

        /// <summary>
        /// Returns a single entity or null if not found.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <param name="includes">The includes.</param>
        /// <returns>T.</returns>
        Task<T> FindAsync<T>(int id, params Expression<Func<T, object>>[] includes) where T : class, IEntity;

        /// <summary>
        /// Returns a single entity. Throws an exception if none or more than one found.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <param name="includes">The includes.</param>
        /// <returns>T.</returns>
        T Get<T>(int id, params Expression<Func<T, object>>[] includes) where T : class, IEntity;

        /// <summary>
        /// Returns a single entity. Throws an exception if none or more than one found.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <param name="includes">The includes.</param>
        /// <returns>T.</returns>
        Task<T> GetAsync<T>(int id, params Expression<Func<T, object>>[] includes) where T : class, IEntity;

        /// <summary>
        /// Persists changes to the data store
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns>The updated entity</returns>
        T Save<T>(T entity, string userName) where T : class, IEntity;

        /// <summary>
        /// Persists changes to the data store
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns>The updated entity</returns>
        Task<T> SaveAsync<T>(T entity, string userName) where T : class, IEntity;

        /// <summary>
        /// Shortcut method for the IQueryable interface method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        List<T> Where<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class, IEntity;

        /// <summary>
        /// Shortcut method for the IQueryable interface method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        Task<List<T>> WhereAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class, IEntity;
    }
}