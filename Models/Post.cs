namespace piktureAPI.Models
{
    public class Post
    {
        public int id { get; set; }
        public string userEmail { get; set; }
        public string userName { get; set; } = "";
        public string userAvatarUrl { get; set; } = "";
        public string imageUrl { get; set; } = "";
        public int numOfLikes { get; set; }
        public string title { get; set; } = "";
        public string category { get; set; } = "";

    }
}
