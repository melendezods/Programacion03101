using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Universidad.Utility.RestClient
{
    public class RestFullClient : IRestClient
    {
        public string Delete(string url)
        {
            try
            {
                string responseString = "";
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.DeleteAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        responseString = response.Content.ReadAsStringAsync().Result;
                    }
                }
                return responseString;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string Get(string url)
        {
            try
            {
                string responseString = "";
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        responseString = response.Content.ReadAsStringAsync().Result;
                    }
                }
                return responseString;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

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

        public string Put(string url, string json)
        {
            try
            {
                HttpClient client = new HttpClient();
                StringContent stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(url, stringContent).Result;
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
