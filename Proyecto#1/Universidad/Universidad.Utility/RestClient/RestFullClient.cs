using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Universidad.Utility.RestClient
{
    public class RestFullClient : IRestClient
    {
        public string Post(string url, string json)
        {
            try
            {
                HttpClient client = new HttpClient();
                StringContent stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url,stringContent).Result;
                var result = response.Content.ReadAsStringAsync();
                return result.Result;
            
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
