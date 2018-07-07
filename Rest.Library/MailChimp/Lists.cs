using Newtonsoft.Json;
using System.Threading.Tasks;

namespace OfficeClip.OpenSource.Integration.Rest.Library.MailChimp
{
    public class Lists
    {
        public const string GetUrl = "https://{0}.api.mailchimp.com/3.0/lists";

        public static async Task<ListsInfo> GetLists(
            RestCredentialInfo restCredentialInfo,
            bool isUnblock = false)
        {
            var restCredential = new Rest(
                "dummy",
                restCredentialInfo.MailChimpApiKey);
            var url = string.Format(
                                    GetUrl,
                                    restCredentialInfo.MailChimpLocation);
            var response = (isUnblock)
                            ? await restCredential.GetAsync(
                                                    url, true).ConfigureAwait(false)
                            : await restCredential.GetAsync(
                                                    url);
            var responseContent = (isUnblock)
                                  ? await response.Content.ReadAsStringAsync().ConfigureAwait(false)
                                  : await response.Content.ReadAsStringAsync();
            var fetch = JsonConvert.DeserializeObject<ListsInfo>(responseContent);
            return fetch;
        }
    }
}
