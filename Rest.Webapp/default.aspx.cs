using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeClip.OpenSource.Integration.Rest.Library;
using OfficeClip.OpenSource.Integration.Rest.Library.Twilio.Voice;
using OcRest = OfficeClip.OpenSource.Integration.Rest.Library.Twilio.Voice.Rest;

namespace Rest.Webapp
{
    public partial class _default : System.Web.UI.Page
    {
        string twilioSid;
        string twilioAuthToken;
        string twilioNumber;
        string publicUrl;

        protected void Page_Load(object sender, EventArgs e)
        {
            twilioSid = ConfigurationManager.AppSettings["TwilioAccountSID"];
            twilioAuthToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
            twilioNumber = ConfigurationManager.AppSettings["TwilioNumber"];
            publicUrl = ConfigurationManager.AppSettings["PublicUrl"];
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var twiMl = GetTwiML();
            var returnMessage = OcRest.PostCommand(
                                            twilioSid,
                                            twilioAuthToken,
                                            twilioNumber,
                                            txtPhone.Text.Trim(),
                                            twiMl).Result;
        }

        private string GetTwiML()
        {
            StreamReader sr = File.OpenText(Server.MapPath(@"Twilio\twiml.xml"));
            string strContents = sr.ReadToEnd();
            strContents = string.Format(strContents, txtPhone1.Text.Trim());
            return strContents;
        }
    }
}