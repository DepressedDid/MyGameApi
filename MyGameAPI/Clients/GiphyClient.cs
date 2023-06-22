using MyGameAPI.Models;
using Newtonsoft.Json;

namespace MyGameAPI
{
    public class GiphyClient
    {
        private HttpClient _httpClient;
        private static string _address;
        private static string _apikey;
        public GiphyClient()
        {
            _apikey = GiphyConstants.apikey;
            _address = GiphyConstants.address;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_address);
        }
        public async Task<GifModel> GetGifsAsync(string GameName)
        {
            var responce = await _httpClient.GetAsync($"v1/gifs/search?q={GameName}&api_key={_apikey}&limit=5");
            responce.EnsureSuccessStatusCode();
            var content = responce.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<GifModel>(content);
            return result;
        }
       
    }
}
