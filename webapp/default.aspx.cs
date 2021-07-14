using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace webapp
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string accountSid = Utils.TwilioAccountSid;
            string authToken = Utils.TwilioAccountAuth;

            TwilioClient.Init(accountSid, authToken);

            var call = CallResource.Create(
                url: new Uri("http://demo.twilio.com/docs/voice.xml"),
                to: new Twilio.Types.PhoneNumber("+14044927564"),
                from: new Twilio.Types.PhoneNumber(Utils.TwilioPhone)
            );

            litjson.Text = JsonConvert.SerializeObject(call, Formatting.Indented);

        }
    }
}