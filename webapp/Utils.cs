using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace webapp
{
    public class Utils
    {
        public static string TwilioAccountSid
        {
            get
            {
                object obj = WebConfigurationManager.AppSettings["Twilio_Account_Sid"];
                return obj.ToString();
            }
        }

        public static string TwilioAccountAuth
        {
            get
            {
                object obj = WebConfigurationManager.AppSettings["Twilio_Auth_Token"];
                return obj.ToString();
            }
        }
        public static string TwilioPhone
        {
            get
            {
                object obj = WebConfigurationManager.AppSettings["Twilio_Phone"];
                return obj.ToString();
            }
        }
    }
}