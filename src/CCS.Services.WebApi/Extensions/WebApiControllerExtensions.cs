// ReSharper disable once CheckNamespace
namespace CCS.Services.WebApi
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    /// <summary>
    /// Runtime checking
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
}