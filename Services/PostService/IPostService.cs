namespace piktureAPI.Services.PostService
{
    public interface IPostService
    {
        public Task<List<Post>> GetAllPostIds();
        public Task<Post> GetPostById(int id);
        public Task<List<Post>> SearchPosts(String key);
        public void AddPost(IFormCollection formData, String imagePath);
    }
}
