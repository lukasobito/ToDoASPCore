using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ToDoASPCore.Utils
{
    public class Consume
    {
        private HttpClient client;
        public Consume(Uri uri)
        {
            client = new HttpClient();
            client.BaseAddress = uri;
        }
        public List<T> GetAll<T>(string type)
        {

            HttpResponseMessage message = client.GetAsync(type +"s").Result;
            string json = message.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public T GetOne<T>(string type,int id)
        {

            HttpResponseMessage message = client.GetAsync(type + "/" + id.ToString()).Result;
            string json = message.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(json);
        }

        public void Post<T>(string type,T f)
        {

            string json = JsonConvert.SerializeObject(f);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using(HttpResponseMessage response = client.PostAsync(type, content).Result)
            {
                if (!response.IsSuccessStatusCode) { throw new HttpRequestException(); }
            }
        }

        public void Put<T>(string type,T f)
        {

            string json = JsonConvert.SerializeObject(f);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = client.PutAsync(type, content).Result)
            {
                if (!response.IsSuccessStatusCode) { throw new HttpRequestException(); }
            }
        }

        public void Delete(string type,int id)
        {
            using (HttpResponseMessage response = client.DeleteAsync(type + "/" + id.ToString()).Result)
            {
                if (!response.IsSuccessStatusCode) { throw new HttpRequestException(); }
            }
        }
    }
}