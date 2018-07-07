using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OfficeClip.OpenSource.Integration.Rest.Library
{
    public class Rest
    {
        private static readonly HttpClient client = new HttpClient();

        public Rest(string accountId, string secretKey, string userAgent = null)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                                            new MediaTypeWithQualityHeaderValue(
                                                                        "application/json"));
            var byteArray = Encoding.ASCII.GetBytes($"{accountId}:{secretKey}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                                                                            "Basic",
                                                                            Convert.ToBase64String(byteArray));
            if (userAgent!= null)
            {
                client.DefaultRequestHeaders.Add("User-Agent", userAgent);
            }
        }

        public async Task<HttpResponseMessage> PostAsync(string url, StringContent content, bool isUnblock = false)
        {            
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            return (isUnblock)
                    ? await client.PostAsync(url, content).ConfigureAwait(false)
                    : await client.PostAsync(url, content);
        }

        public async Task<HttpResponseMessage> GetAsync(string path, bool isUnblock = false)
        {
            return (isUnblock) 
                    ? await client.GetAsync(path).ConfigureAwait(false)
                    : await client.GetAsync(path);
        }
    }
}