using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ChatBot.Communication.Clients
{
    public static class FitnessApiClient
    {
        private static readonly string WebApiAddress = "https://fitnesssystemapi/";

        public static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(WebApiAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new
            MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", "Token");

            return client;
        }
    }
}
