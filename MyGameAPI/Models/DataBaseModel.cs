using System.Globalization;

namespace MyGameAPI
{
    public class DataBaseModel
    {
        public List<Data> DataList {get;set;}
    }
    public class Data
    {
        
        public string GameName { get; set; }
        public string StoreLink { get; set; }
    }
}
