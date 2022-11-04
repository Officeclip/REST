using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeClip.OpenSource.Integration.Rest.Library.Twilio.Voice
{
    public class Exception
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string MoreInfo { get; set; }
        public int Status { get; set; }
    }
}
