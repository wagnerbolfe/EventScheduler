using System.Net;

namespace EventScheduler.Common.Exceptions
{
    public interface IEventSchedulerException
    {
        public HttpStatusCode? HttpStatusCode { get; set; }
        public int ErrorCode { get; set; }
        public string Message { get; set; }


        public string ToJson();
    }
}
