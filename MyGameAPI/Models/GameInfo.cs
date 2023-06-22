namespace MyGameAPI.Models
{
    public class GameInfo
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Released { get; set; }
        public double rating { get; set; }
        public double rating_top { get; set; }

        public Requirements requirements { get; set; }


        public List<Platforms> Platforms { get; set; }
        public GameInfo()
        {
            requirements = new Requirements();
        }
        public string GameInfoTostring()
        {
            Description=Description.Replace("<p>", "").Replace("</p>", "").Replace("<br />","");
            var result = Name + "\n" + "Released: " + Released +" "+"Raiting: "+$"{rating}/{rating_top}"+ "\n" + Description + "\n" + "Available on the following platforms: ";
            for (int i = 0; i < Platforms.Count; i++)
            {
                if (i + 1 != Platforms.Count)
                {
                    result += Platforms[i].Platform.Name + ", ";
                }
                else
                {
                    result += Platforms[i].Platform.Name +  ".";
                }

            }
            
            return result;
        }

    }
  
    public class Platforms
    {
        public Platform Platform { get; set; }
    }
    public class Platform
    {
        public int Id { get; set; }
        public string? Slug { get; set; }
        public string? Name { get; set; }
        //public Requirements requirements { get; set; }

    }

    public class Requirements
    {
        public string? minimum { get; set; }
        public string? Recommended { get; set; }
    }
}


