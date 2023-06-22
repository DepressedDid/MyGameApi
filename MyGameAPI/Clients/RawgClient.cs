using MyGameAPI.Models;
using Newtonsoft.Json;

namespace MyGameAPI
{
    public class RawgClient
    {
        private HttpClient _httpClient;
        private static string _address;
        private static string _apikey;
        public RawgClient()
        {
            _apikey = RawgConstants.apikey;
            _address = RawgConstants.address;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_address);
        }
        public async Task<GameInfo> GetGameInfoAsync(string GameName)
        {
            var responce = await _httpClient.GetAsync($"/api/games/{GameName}?key={_apikey}");
            responce.EnsureSuccessStatusCode();
            var content = responce.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<GameInfo>(content);       
            return result;
        }
        public async Task<StoreLink> GetStoreLinkAsync(string GameName)
        {
            try
            {
                var responce = await _httpClient.GetAsync($"/api/games/{GameName}/stores?key={_apikey}");
                responce.EnsureSuccessStatusCode();
                var content = responce.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<StoreLink>(content);
                return result;
            }
            catch(Exception e)
            {
                return new StoreLink();
            }
        }
        public async Task<SubReddit> GetRecentPosts(string GameName)
        {
            var responce = await _httpClient.GetAsync($"/api/games/{GameName}/reddit?key={_apikey}");
            responce.EnsureSuccessStatusCode();
            var content = responce.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<SubReddit>(content);          
            return result;
        } 
      
    }
}
