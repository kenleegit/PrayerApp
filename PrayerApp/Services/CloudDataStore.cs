using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Plugin.Connectivity;

namespace PrayerApp
{
    public class CloudDataStore : IDataStore<Item>
    {
        HttpClient client;
        IEnumerable<Item> items;
        string catname;
        //public string Catname;

        public CloudDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");

            items = new List<Item>();
            catname = "daily"; //todo parameterize the path to get entries
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"wp-json/wp/v2/posts/?per_page=20&page=1&categories=" + catname);
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Item>>(json));
            }

            return items;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(string catname, bool forceRefresh = false)
        {
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"wp-json/wp/v2/posts/?per_page=20&page=1&categories=" + catname);
                //2018-01-10 Remove HTML tags with Regexp. You see </p> is actually <\\/p>.
                string pattern1 = @"<(\\/)*[a-z]+>";
                json = Regex.Replace(json, pattern1, String.Empty);
                string pattern2 = @"&#8211;";
                var json2 = Regex.Replace(json, pattern2, "-");
                string pattern3 = "&nbsp;";
                var json3 = Regex.Replace(json2, pattern3, " ");
                //string replacer = "";
                //Regex regexp = new Regex(pattern);
                //json = regexp.Replace(json, replacer);
                //2018-01-10 
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Item>>(json3));
            }

            return items;
        }

        public async Task<Item> GetItemAsync(string id)
        {
            if (id != null && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"api/" + catname + "/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Item>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            if (item == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/" + catname, new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            if (item == null || item.Id == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/" + catname + "/{item.Id}"), byteContent);


            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !CrossConnectivity.Current.IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/" + catname + "/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
