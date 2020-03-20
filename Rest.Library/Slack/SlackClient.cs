using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OfficeClip.OpenSource.Integration.Rest.Library.Slack
{
    public class SlackClient
    {
        public static async Task<HttpResponseMessage> SendMessageAsync(
                                                    RestCredentialInfo restCredentialInfo,
                                                    string message,
                                                    string blocks,
                                                    string channel = null, 
                                                    string username = null)
        {
            var payload = new
            {
                text = message,
                blocks,
                channel,
                username,
            };
            var serializedPayload = JsonConvert.SerializeObject(payload);
            var url = restCredentialInfo.SlackWebHookUrl;
            var restCredential = new Rest(string.Empty, string.Empty);
            var response = await restCredential.PostAsync(
                                        url,
                                        new StringContent(serializedPayload, Encoding.UTF8, "application/json"));

            return response;
        }
    }
}
