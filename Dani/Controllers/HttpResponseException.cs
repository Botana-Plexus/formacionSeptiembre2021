using System;
using System.Runtime.Serialization;

namespace API_Botanapoly.Controllers
{
    [Serializable]
    internal class HttpResponseException : Exception
    {
        private object notFound;

        public HttpResponseException()
        {
        }

        public HttpResponseException(object notFound)
        {
            this.notFound = notFound;
        }

        public HttpResponseException(string message) : base(message)
        {
        }

        public HttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HttpResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}