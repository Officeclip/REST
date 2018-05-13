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
            //client.DefaultRequestHeaders.Add("User-Agent", "twilio-csharp/5.6.2 (.NET 4+)");
        }

        public async Task<HttpResponseMessage> PostAsync(string url, StringContent content)
        {            
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            return await client.PostAsync(url, content);
        }

        public async Task<HttpResponseMessage> GetAsync(string path)
        {
            return await client.GetAsync(path);
        }

        //public async Task<Tuple<List<T>, HttpResponseMessage>> GetAllUsersAsync(
        //                                                    string queryString = "")
        //{
        //    HttpResponseMessage response = await client.GetAsync(queryString);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var values = await response.Content.ReadAsAsync<IEnumerable<T>>();
        //        var valueList = values.ToList();
        //        return new Tuple<List<T>, HttpResponseMessage>(valueList, response);
        //    }
        //    else
        //    {
        //        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //    }
        //    return new Tuple<List<T>, HttpResponseMessage>(null, response);
        //}

    }
}