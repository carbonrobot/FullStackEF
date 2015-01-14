namespace CCS.Services.WebApi.Exceptions
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentValidation;

    public class HttpValidationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpValidationException"/> class.
        /// </summary>
        /// <param name="validationException">The fluent validation exception.</param>
        public HttpValidationException(ValidationException validationException)
        {
            this.Errors = validationException.Errors.Select(x => x.ErrorMessage).ToList();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpValidationException"/> class.
        /// </summary>
        /// <param name="message">A single error message.</param>
        public HttpValidationException(string message)
        {
            this.Errors = new List<string>()
            {
                message
            };
        }

        /// <summary>
        /// Gets or sets the list of validation errors.
        /// </summary>
        public IList<string> Errors { get; set; }
    }
}