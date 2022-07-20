using System.Net;

namespace Client.Domain.SharedContext
{
    public class ReturnBase
    {
        public object Data { get; private set; }
        public string Message { get; private set; }
        public HttpStatusCode ResponseCode { get; private set; }

        public ReturnBase(HttpStatusCode responseCode, object data, string message = null)
        {
            ResponseCode = responseCode;
            Data = data;
            Message = message;
        }
    }
}
