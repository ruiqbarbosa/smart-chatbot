using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBot.Infrastructure.Extensions
{
    public static class LuisExtensions
    {
        
        public static LuisEntity GetEntity(this JObject luisObject, string entityName)
        {
            try
            {
                var token = luisObject.SelectToken("$instance." + entityName + "[0]");

                if (token == null)
                    return null;
                else
                    return token.ToObject<LuisEntity>();

                //luisObject.TryGetValue("entityName", out JToken entity);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }

    public class LuisEntity
    {
        public string Text { get; set; }

        public string Type { get; set; }

        public string Score { get; set; }
    }
}
