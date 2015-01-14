namespace CCS.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Core;
    using Services.Data;

    /// <summary>
    /// Provides common data operations for entities
    /// </summary>
    public abstract class DataContext : DbContext, IDataContext
    {
        /// <summary>
        /// Returns a queryable interface for an entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="includes">The includes.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public IQueryable<T> AsQueryable<T>(params Expression<Func<T, object>>[] includes) where T : class, IEntity
        {
            return this.Set<T>().Include(includes).AsQueryable();
        }

        /// <summary>
        /// Deletes a single entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <returns>True if successful</returns>
        public bool Delete<T>(int id) where T : class, IEntity
        {
            var entity = this.Set<T>().Find(id);
            return this.Delete(entity);
        }

        /// <summary>
        /// Deletes a single entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        /// <returns>True if successful</returns>
        /// <exception cref="ArgumentNullException" />
        public bool Delete<T>(T entity) where T : class, IEntity
        {
            if (entity == null)
                throw new ArgumentNullException("entity", "Entity can not be null when calling delete(entity)");

            this.Set<T>().Remove(entity);
            return this.SaveChanges() > 0;
        }

        /// <summary>
        /// Deletes a single entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>True if successful</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task<bool> DeleteAsync<T>(int id) where T : class, IEntity
        {
            var entity = this.Set<T>().Find(id);
            return this.DeleteAsync(entity);
        }

        /// <summary>
        /// Deletes a single entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        /// <returns>True if successful</returns>
        /// <exception cref="ArgumentNullException" />
        public async Task<bool> DeleteAsync<T>(T entity) where T : class, IEntity
        {
            if (entity == null)
                throw new ArgumentNullException("entity", "Entity can not be null when calling delete(entity)");

            this.Set<T>().Remove(entity);
            var rowsChanged = await this.SaveChangesAsync();
            return rowsChanged > 0;
        }

        /// <summary>
        /// Returns a single entity or null if not found.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <param name="includes">The includes.</param>
        /// <returns>T.</returns>
        public T Find<T>(int id, params Expression<Func<T, object>>[] includes) where T : class, IEntity
        {
            return this.Set<T>().Include(includes).Find(id);
        }

        /// <summary>
        /// Returns a single entity or null if not found.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <param name="includes">The includes.</param>
        /// <returns>T.</returns>
        public Task<T> FindAsync<T>(int id, params Expression<Func<T, object>>[] includes) where T : class, IEntity
        {
            return this.Set<T>().Include(includes).FindAsync(id);
        }

        /// <summary>
        /// Returns a single entity. Throws an exception if none or more than one found.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <param name="includes">The includes.</param>
        /// <returns>T.</returns>
        public T Get<T>(int id, params Expression<Func<T, object>>[] includes) where T : class, IEntity
        {
            return this.Set<T>().Include(includes).Find(id);
        }

        /// <summary>
        /// Returns a single entity. Throws an exception if none or more than one found.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <param name="includes">The includes.</param>
        /// <returns>T.</returns>
        public Task<T> GetAsync<T>(int id, params Expression<Func<T, object>>[] includes) where T : class, IEntity
        {
            return this.Set<T>().Include(includes).SingleAsync(x => x.Id == id);
        }

        /// <summary>
        /// Persists changes to the data store
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns>The updated entity</returns>
        public T Save<T>(T entity, string userName) where T : class, IEntity
        {
            UpdateAuditableEntity(entity, userName);
            this.Attach(entity);
            this.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Persists changes to the data store
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns>The updated entity</returns>
        public async Task<T> SaveAsync<T>(T entity, string userName) where T : class, IEntity
        {
            UpdateAuditableEntity(entity, userName);
            this.Attach(entity);
            await this.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Shortcut method for the IQueryable interface method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public List<T> Where<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class, IEntity
        {
            return this.AsQueryable(includes).Where(predicate).ToList();
        }

        /// <summary>
        /// Shortcut method for the IQueryable interface method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public Task<List<T>> WhereAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class, IEntity
        {
            return this.Set<T>().Include(includes).Where(predicate).ToListAsync();
        }

        /// <summary>
        /// Updates timestamps on an entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="userName">Name of the user.</param>
        private static void UpdateAuditableEntity<T>(T entity, string userName) where T : class, IEntity
        {
            var auditableEntity = entity as IAuditableEntity;
            if (auditableEntity != null)
            {
                if (entity.Id == 0)
                    auditableEntity.DateCreated = DateTime.Now;

                auditableEntity.LastModifiedDate = DateTime.Now;
                auditableEntity.LastModifiedUser = userName;
            }
        }
    }
}