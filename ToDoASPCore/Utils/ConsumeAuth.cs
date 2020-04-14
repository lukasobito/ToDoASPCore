using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ToDoASPCore.Utils
{
    public class ConsumeAuth
    {
        private HttpClient client;
        public ConsumeAuth(Uri uri)
        {
            client = new HttpClient();
            client.BaseAddress = uri;
        }

        public void Register<T>(string type, T t)
        {
            string json = JsonConvert.SerializeObject(t);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using(HttpResponseMessage response = client.PostAsync(type + "/register/", content).Result)
            {
                if (!response.IsSuccessStatusCode) { throw new HttpRequestException(); }
            }
        }
    }
}
