using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OfficeClip.OpenSource.Integration.Rest.Library.Twilio.Voice
{
    public class Rest
    {
        public const string VoicePostUrl = "https://api.twilio.com/2010-04-01/Accounts/{0}/Calls.json";

        public static async Task<ReturnMessage> PostCommand(
                                string twilioAccountId,
                                string twilioSecretKey,
                                string toNumber,
                                string fromNumber,
                                string twiml)
        {
            var restCredential = new Library.Rest(
                                        twilioAccountId,
                                        twilioSecretKey);
            var url = string.Format(
                                    VoicePostUrl,
                                    twilioAccountId);

            var parameters = new
            {
                To = toNumber,
                From = fromNumber,
                Twiml = twiml
            };

            string json = JsonConvert.SerializeObject(parameters);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await restCredential.PostAsync(
                                                        url,
                                                        content).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                // return the errror
            }
            var responseContent = await 
                                        response
                                        .Content
                                        .ReadAsStringAsync()
                                        .ConfigureAwait(false);

            var returnMessage = ReturnMessage.FromJson(responseContent);
            return returnMessage;

        }
    }
}