namespace MyGameAPI.Models
{
    public class GifModel
    {
        public List<Gif> data { get; set; }


        public string GifUrlToString()
        {
            var result = "";
            for (int i = 0; i < data.Count; i++)
            {
                if (i + 1 != data.Count)
                {
                    result += data[i].images.original.Url + " ";
                }
                else
                {
                    result += data[i].images.original.Url;
                }
            }
            return result;
        }

    }
    public class Gif
    {
        public Images images { get; set; }
        public string Id { get; set; }
        public string Url { get; set; }    
    }
   
    public class Images
    {
        public Original original { get; set; }
    }
    public class Original
    {
        public string Url { get; set; }
    }
}
