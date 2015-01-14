// ReSharper disable once CheckNamespace
namespace CCS.Services.WebApi
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Newtonsoft.Json;

    /// <summary>
    /// Http parameter checking
    /// </summary>
    public static class HttpRequires
    {
        /// <summary>
        /// Throws an HTTP 400 response with the given message if the value is null or empty
        /// </summary>
        public static void IsNotNull(string value, string msg)
        {
            if (string.IsNullOrEmpty(value))
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(msg) });
        }

        /// <summary>
        /// Throws an HTTP 400 response with the given message if the value is null or empty
        /// </summary>
        public static void IsNotNull(object value, string msg)
        {
            if (value == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(msg) });
        }
        
        /// <summary>
        /// Throws an HTTP 400 response with the given message if the value false
        /// </summary>
        public static void IsTrue(bool op, string msg)
        {
            if (!op)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(msg) });
        }
        
    }

    /// <summary>
    /// Http assertions
    /// </summary>
    public static class HttpAssert
    {
        /// <summary>
        /// Handles the service response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response">The response.</param>
        /// <exception cref="System.Web.Http.HttpResponseException"></exception>
        public static void Success<T>(ServiceResponse<T> response)
        {
            if (response.HasError)
            {
                var message = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(response.Exception))
                };
                throw new HttpResponseException(message);
            }
        }

        /// <summary>
        /// Throws an HTTP 404 when the value is null
        /// </summary>
        public static void IsNotNull<T>(ServiceResponse<T> response)
        {
            if (response.Result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}