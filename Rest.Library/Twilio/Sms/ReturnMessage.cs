using System;
using System.Configuration;
using System.Web;

namespace OfficeClip.OpenSource.Integration.Rest.Library.Twilio.Sms
{
    public class ReturnMessage
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Message { get; set; }
        public string ReturnSid { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Sent { get; set; }
        public string Direction { get; set; }
        public int NumberOfSms { get; set; }
        public Exception RestException { get; set; }
        public string ToMessageString()
        {
            return
                 string.Format(
                         "To={0}&From={1}&Body={2}",
                         HttpUtility.UrlEncode(To),
                         HttpUtility.UrlEncode(From),
                         HttpUtility.UrlEncode(Message));
        }

        public void ReadFromConfiguration()
        {
            From = ConfigurationManager.AppSettings["FromPhone"];
            To = ConfigurationManager.AppSettings["ToPhone"];
        }

    }
}
