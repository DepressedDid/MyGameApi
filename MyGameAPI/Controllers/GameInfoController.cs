using Microsoft.AspNetCore.Mvc;
using MyGameAPI.Models;
using System.Data;

namespace MyGameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameInfoController : ControllerBase
    {
        private readonly ILogger<GameInfoController> _logger;
        public GameInfoController(ILogger<GameInfoController> logger)
        {
            _logger = logger;
        }
        [HttpGet(Name = "GameInfo")]
        public string Game(string GameName)
        {
           
            RawgClient client = new RawgClient();
            try
            {
                client.GetGameInfoAsync(GameName).Result.GameInfoTostring();
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return client.GetGameInfoAsync(GameName).Result.GameInfoTostring();
        }
        [HttpGet("{GameName}/stores", Name = "Store")]
        public string Store(string GameName)
        {
            RawgClient client = new RawgClient();
            try
            {
                client.GetStoreLinkAsync(GameName).Result.StoreLinkToResponce();
            }
            catch(Exception e)
            {
                return e.Message;
            }           
            return client.GetStoreLinkAsync(GameName).Result.StoreLinkToResponce();
           
            
        }
        [HttpGet("{GameName}/reddit", Name = "Reddit")]
        public  string RedditPost(string GameName)
        {
            RawgClient client = new RawgClient();
            try
            {
                client.GetRecentPosts(GameName).Result.PostListToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return client.GetRecentPosts(GameName).Result.PostListToString();
        }
        [HttpGet("gifs/search", Name = "Gifs")]
        public string ShowGameGif(string GameName)
        {
            GiphyClient client = new GiphyClient();
            return client.GetGifsAsync(GameName).Result.GifUrlToString();
        }
        [HttpPost]
        public async void SaveGamewLinks(long message, string GameName)
        {
            DataBase data = new DataBase();
            RawgClient client = new RawgClient();
            try
            {
                client.GetStoreLinkAsync(GameName).Result.StoreLinkToResponce();
                var test = client.GetStoreLinkAsync(GameName).Result.StoreLinkToResponce();

            }
            catch (Exception e)
            {

            }
            var result = client.GetStoreLinkAsync(GameName).Result.StoreLinkToResponce();
            data.InsertGameNameAsync(message, GameName,result);

        }
        [HttpDelete]
        public async void DeleteAll(long ID)
        {
            DataBase data = new DataBase();
            data.Delete(ID);

        }
        //[HttpGet]
        //public async Task<DataBaseModel> ViewList(long ID)
        //{
        //    DataBase data = new DataBase();
        //    DataBaseModel dataBaseModel = new DataBaseModel();
        //    dataBaseModel.DataList = data.GetDataAsync(ID).Result;
        //    return dataBaseModel;
        //}

    }
}
