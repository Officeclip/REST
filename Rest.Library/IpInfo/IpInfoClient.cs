using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace OfficeClip.OpenSource.Integration.Rest.Library.IpInfo
{
    public class IpInfoClient
    {
        /// <summary>
        /// Sending a slack webhook message. See: https://api.slack.com/reference/messaging/payload
        /// </summary>
        /// <param name="restCredentialInfo"></param>
        /// <param name="message"></param>
        /// <param name="blocks"></param>
        /// <param name="channel"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static async Task<string> GetCountryAsync(
                                                    RestCredentialInfo restCredentialInfo,
                                                    string ipAddress)
        {
            var restCredential = new Library.Rest("", restCredentialInfo.IpInfoKey);
            var url = $"https://ipinfo.io/{ipAddress}";
            var response = await restCredential.GetAsync(
                                                    url, true);
            var responseContent = await response.Content.ReadAsStringAsync();
            dynamic fetch = JObject.Parse(responseContent);
            return fetch.country;
        }
    }
}
