using ChatBot.Communication.Clients;
using ChatBot.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChatBot.Communication.Handlers
{
    public static class FitnessApiGateway
    {
        public static async Task<dynamic> Login(string username, string password)
        {
            var client = FitnessApiClient.GetClient();
            HttpContent content = new StringContent(
            "grant_type=password&username=" + username + "&password=" + password,
            System.Text.Encoding.UTF8,
            "application/x-www-form-urlencoded");

            return await client.PostAsync("Token", content);
        }

        public static async Task<List<string>> GetMovementsNames()
        {
            List<string> movements = new List<string>();
            var client = FitnessApiClient.GetClient();
            HttpResponseMessage response = await client.GetAsync("api/Movements/getMovementsNames");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                movements = JsonConvert.DeserializeObject<List<string>>(jsonString);
            }

            return movements;
        }

        public static async Task<(int, MovementInfo)> GetMovementInfo(string movement)
        {
            MovementInfo movementInfo = null;
            var client = FitnessApiClient.GetClient();
            HttpResponseMessage response = await client.GetAsync("api/Movements/getMovementInfo/" + movement);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                movementInfo = JsonConvert.DeserializeObject<MovementInfo>(jsonString);
            }

            return ((int)response.StatusCode, movementInfo);
        }

    }
}
