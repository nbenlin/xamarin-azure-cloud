using Newtonsoft.Json;
using projectCdv.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace projectCdv.Helpers
{
    public class RestService
    {
        HttpClient _client;
        private CancellationToken cancellationToken;

        public RestService()
        {
            _client = new HttpClient();
            if (Device.RuntimePlatform == Device.UWP)
            {
                _client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            }
        }

        public async Task<List<User>> GetUsersAsync(string uri)
        {
            List<User> users = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<User>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR: {0}", ex.Message);
            }
            return users;
        }

        public async Task SaveUserAsync(User user)
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, Constants.AzureFunctionPostURL))
            {
                //var json = JsonConvert.SerializeObject(user);
                //using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    //request.Content = stringContent;
                    var content = JsonConvert.SerializeObject(user);
                    //using (HttpResponseMessage response = await client
                    //   .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    //    .ConfigureAwait(false))
                    // {
                    //    response.EnsureSuccessStatusCode();
                    //}
                    HttpResponseMessage hrm = await client.PostAsync(Constants.AzureFunctionPostURL, new StringContent(content, System.Text.Encoding.UTF8, "application/json"));
                }
            }
        }

    }
}
