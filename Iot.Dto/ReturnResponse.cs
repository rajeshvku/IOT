using System.Net;

namespace Iot.Dto
{
    public class ReturnResponse<T>
    {
        public HttpStatusCode Status { get; set; }
        public T Response { get; set; }
    }
    public class ResponseDetail
    {
        public string Message { get; set; }
        public bool Status { get; set; }
    }
    public class ResponseDetail<T>
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public T Data { get; set; }
    }
}
