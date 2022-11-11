using Newtonsoft.Json;
using System.Net;

namespace EventScheduler.Common.Exceptions
{
    public class DefaultEventSchedulerExceptionTwo : Exception, IEventSchedulerException
    {
        public HttpStatusCode? HttpStatusCode { get; set; }
        public int ErrorCode { get; set; }
        public string Message { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(new
            {
                StatusCode = HttpStatusCode,
                 ErrorCode = HttpStatusCode,
                 Message = Message,
                 Errors=new List<string>
                 {
                     "Error One", "Error Two"
                 }
            });
        }
    }
}
