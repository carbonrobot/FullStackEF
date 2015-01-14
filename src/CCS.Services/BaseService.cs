namespace CCS.Services
{
    using System;
    using FluentValidation;
    using Logging;

    public abstract class BaseService
    {
        /// <summary>
        /// Authorizes the specified user for changes to the entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="userName">Name of the user.</param>
        protected void Authorize<TEntity>(TEntity entity, string userName)
        {
            // throw exception if not authn
        }

        /// <summary>
        /// Executes a function with the given return type. Internally handles exceptions and logs them.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="func">The method to execute</param>
        /// <returns>ServiceResponse&lt;TResult&gt;.</returns>
        protected ServiceResponse<TResult> Execute<TResult>(Func<TResult> func)
        {
            var response = new ServiceResponse<TResult>();
            try
            {
                response.Result = func.Invoke();
                response.HasError = false;
                response.Exception = null;
            }
            catch (Exception ex)
            {
                this.Log().Error(() => ex.ToString());

                response.Result = default(TResult);
                response.HasError = true;
                response.Exception = ex;
            }
            return response;
        }

        /// <summary>
        /// Executes a function with no return type. Internally handles exceptions and logs them.
        /// </summary>
        /// <param name="action">The method to execute</param>
        protected ServiceResponse Execute(Action action)
        {
            var response = new ServiceResponse();
            try
            {
                action.Invoke();
                response.HasError = false;
                response.Exception = null;
            }
            catch (Exception ex)
            {
                this.Log().Error(() => ex.ToString());

                response.HasError = true;
                response.Exception = ex;
            }
            return response;
        }

        /// <summary>
        /// Validates the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="validator">The validator.</param>
        /// <exception cref="FluentValidation.ValidationException"></exception>
        protected void Validate<TEntity>(TEntity entity, AbstractValidator<TEntity> validator)
        {
            var validationResult = validator.Validate(entity);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
        }
    }
}