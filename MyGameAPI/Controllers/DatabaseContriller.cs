using Microsoft.AspNetCore.Mvc;

namespace MyGameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataBaseController : ControllerBase
    {
        private readonly ILogger<DataBaseController> _logger;
        public DataBaseController(ILogger<DataBaseController> logger)
        {
            _logger = logger;
        }
        [HttpGet(Name ="Check Data")]
        public async Task<DataBaseModel> ViewList(long ID)
        {
            DataBase data = new DataBase();
            DataBaseModel dataBaseModel = new DataBaseModel();
            dataBaseModel.DataList = data.GetDataAsync(ID).Result;
            return dataBaseModel;
        }
    }
}
