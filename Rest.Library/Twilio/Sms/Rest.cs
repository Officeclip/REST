using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace OfficeClip.OpenSource.Integration.Rest.Library.Twilio.Sms
{
    public class Rest
    {
        public const string SmsPostUrl = "https://api.twilio.com/2010-04-01/Accounts/{0}/Messages";
        public const string SmsGetUrl = "https://api.twilio.com/2010-04-01/Accounts/{0}/Messages/{1}";

        public static async Task<ReturnMessage> GetMessage(
                                RestCredentialInfo restCredentialInfo,
                                string messageId)
        {
            var restCredential = new Library.Rest(
                                        restCredentialInfo.TwilioAccountId,
                                        restCredentialInfo.TwilioSecretKey);
            var url = string.Format(
                                    SmsGetUrl,
                                    restCredentialInfo.TwilioAccountId,
                                    messageId);
            var response = await restCredential.GetAsync(
                                                        url).ConfigureAwait(false);
            var responseContent = await 
                                        response
                                        .Content
                                        .ReadAsStringAsync()
                                        .ConfigureAwait(false);
            ReturnMessage twilioMessage = null;
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(
                           responseContent);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    twilioMessage = new ReturnMessage()
                    {
                        ReturnSid = xmlDoc.SelectSingleNode(
                                                "TwilioResponse/Message/Sid").InnerText,
                        Created = Convert.ToDateTime(
                                                xmlDoc.SelectSingleNode(
                                                    "TwilioResponse/Message/DateCreated").InnerText),
                        Updated = Convert.ToDateTime(
                                                xmlDoc.SelectSingleNode(
                                                    "TwilioResponse/Message/DateUpdated").InnerText),
                        Sent = Convert.ToDateTime(
                                                xmlDoc.SelectSingleNode(
                                                        "TwilioResponse/Message/DateSent").InnerText),
                        From = xmlDoc.SelectSingleNode(
                                                "TwilioResponse/Message/From").InnerText,
                        To = xmlDoc.SelectSingleNode(
                                                "TwilioResponse/Message/To").InnerText,
                        Message = xmlDoc.SelectSingleNode(
                                                "TwilioResponse/Message/Body").InnerText,
                        NumberOfSms = Convert.ToInt32(xmlDoc.SelectSingleNode(
                                                 "TwilioResponse/Message/NumSegments").InnerText),
                        Status = xmlDoc.SelectSingleNode(
                                                 "TwilioResponse/Message/Status").InnerText,
                        Direction = xmlDoc.SelectSingleNode(
                                                 "TwilioResponse/Message/Direction").InnerText
                    };
                    var errorCode = xmlDoc.SelectSingleNode(
                                                 "TwilioResponse/Message/ErrorCode");
                    if (errorCode != null)
                    {
                        var twilioException = new Exception()
                        {
                            Code = Convert.ToInt32(errorCode.InnerText),
                            Message = xmlDoc.SelectSingleNode(
                                                 "TwilioResponse/Message/ErrorMessage").InnerText
                        };
                        twilioMessage.RestException = twilioException;
                    }
                }
                catch
                {

                }
            }
            return twilioMessage;
        }

        public static async Task<ReturnMessage> SendMessage(
            RestCredentialInfo restCredentialInfo,
            ReturnMessage twilioMessage)
        {
            var restCredential = new Library.Rest(
                                            restCredentialInfo.TwilioAccountId,
                                            restCredentialInfo.TwilioSecretKey);
            var url = string.Format(
                                SmsPostUrl,
                                restCredentialInfo.TwilioAccountId);
            var content = new StringContent(twilioMessage.ToMessageString());
            var response = await restCredential.PostAsync(
                                               url,
                                               content).ConfigureAwait(false);
            var responseContent = await 
                                        response
                                        .Content
                                        .ReadAsStringAsync()
                                        .ConfigureAwait(false);
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(
                           responseContent);

            if (!response.IsSuccessStatusCode)
            {
                var restException = new Exception();
                try
                {
                    restException.Code = Convert.ToInt32(
                                                         xmlDoc.SelectSingleNode(
                                                                         "TwilioResponse/RestException/Code")
                                                        .InnerText);
                    restException.Message = xmlDoc.SelectSingleNode(
                                                                    "TwilioResponse/RestException/Message").InnerText;
                    restException.MoreInfo = xmlDoc.SelectSingleNode(
                                                                     "TwilioResponse/RestException/MoreInfo").InnerText;
                    restException.Status = Convert.ToInt32(
                                                           xmlDoc.SelectSingleNode(
                                                                                   "TwilioResponse/RestException/Status")
                                                            .InnerText);
                }
                catch (System.Exception ex)
                {
                    restException = new Exception
                    {
                        Code = 0,
                        Message = ex.Message,
                        MoreInfo = "",
                        Status = 0
                    };
                }
                twilioMessage.Status = "failed";
                twilioMessage.RestException = restException;
            }
            else
            {
                try
                {
                    twilioMessage.ReturnSid = xmlDoc.SelectSingleNode(
                                                                      "TwilioResponse/Message/Sid").InnerText;
                    twilioMessage.Created = Convert.ToDateTime(
                                                               xmlDoc.SelectSingleNode(
                                                                                       "TwilioResponse/Message/DateCreated")
                                                                     .InnerText);
                    twilioMessage.Updated = Convert.ToDateTime(
                                                               xmlDoc.SelectSingleNode(
                                                                                       "TwilioResponse/Message/DateUpdated")
                                                                     .InnerText);
                    var sentValue = xmlDoc.SelectSingleNode(
                                                            "TwilioResponse/Message/DateSent");
                    if (sentValue.Value != null)
                    {
                        twilioMessage.Sent = Convert.ToDateTime(sentValue.InnerText);
                    }
                    twilioMessage.NumberOfSms = Convert.ToInt32(
                                                         xmlDoc.SelectSingleNode(
                                                                                 "TwilioResponse/Message/NumSegments")
                                                               .InnerText);
                    twilioMessage.Direction = xmlDoc.SelectSingleNode(
                                                                      "TwilioResponse/Message/Direction").InnerText;
                    twilioMessage.Status = xmlDoc.SelectSingleNode(
                                                                   "TwilioResponse/Message/Status").InnerText;
                }
                catch (System.Exception ex)
                {
                }
            }
            return twilioMessage;
        }
    }
}