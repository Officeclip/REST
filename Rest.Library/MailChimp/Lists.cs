using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeClip.OpenSource.Integration.Rest.Library.MailChimp
{
    public class Lists
    {
        public const string GetUrl = "https://{0}.api.mailchimp.com/3.0/lists";

        public static async Task<ListsInfo> GetLists(
            RestCredentialInfo restCredentialInfo)
        {
            var restCredential = new Rest(
                "dummy",
                restCredentialInfo.MailChimpApiKey);
            var url = string.Format(
                                    GetUrl,
                                    restCredentialInfo.MailChimpLocation);
            var response = await restCredential.GetAsync(
                                                    url);
            var responseContent = await response.Content.ReadAsStringAsync();
            var fetch = JsonConvert.DeserializeObject<ListsInfo>(responseContent);
            //var listsInfo = fetch.First();
            return fetch;
        }
    }
}
