namespace MyGameAPI.Models
{
    public class StoreLink
    {
        public int Count { get; set; }
        public string? Next { get; set; }
        public string? Previous { get; set; }

        public List<Result> results { get; set; }
        public string StoreLinkToResponce()
        {
            try
            {
                var pattern = "The requested game can be found at these links: ";
                string? responce = "";
                string? result = "";
                if (results == null)
                {
                    return "Not Found";
                }
                    for (int i = 0; i < results.Count; i++)
                {

                    responce += results[i].Url + "\n";

                }
                if (responce == null)
                {
                    result = null;
                }
                else
                {
                    result = pattern + responce;
                }
                return result;
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

    }
    public class Result
    {
        public int Id { get; set; }
        public string? Game_id { get; set; }
        public string? Store_id { get; set; }
        public string? Url { get; set; }

    }
}
