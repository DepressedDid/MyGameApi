namespace MyGameAPI.Models
{
    public class SubReddit
    {
        public List<Post> results { get; set; }
        public string PostListToString()
        {
            var result = "";
            for (int i = 0; i < results.Count(); i++)
            {
                result += results[i].UserName.Replace("/u/","") +"\n" + results[i].Name + "\n" + results[i].Url + "\n";
            }
            if (result == "")
            {
                result = "Not Found";
            }
            return result;
        }
    }
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
    }
    
}
