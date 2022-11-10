using System.Net;

namespace EventScheduler.Services.Exceptions
{
    public class ExternalDependencyException : Exception
    {
        public ExternalDependencyException(HttpStatusCode statusCode, object? value = null)
        {
            StatusCode = statusCode;
            Value = value;
        }


        public HttpStatusCode StatusCode { get; }

        public object? Value { get; }
    }
}
