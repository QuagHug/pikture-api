using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace piktureAPI.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly DataContext _context;
        public PostService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Post>> GetAllPostIds()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }

        public async Task<Post> GetPostById(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.id == id);

            // Read the image file into a byte array
            return post;
        }

        public async Task<List<Post>> SearchPosts(String key)
        {
            var posts =  await _context.Posts.Where(post => post.title.Contains(key)).ToListAsync();

            return posts;
        }
        public void AddPost(IFormCollection formData, String imagePath)
        {
            var userEmail = formData["userEmail"];
            var userName = formData["userName"];
            var userAvatarUrl = formData["userAvatarUrl"];
            var imageUrl = imagePath;
            var title = formData["title"];
            var category = formData["category"];

            var newPost = new Post
            {
                userEmail = userEmail,
                userName = userName,
                userAvatarUrl = userAvatarUrl,
                imageUrl = imageUrl,
                title = title,
                category = category
            };
            _context.Posts.Add(newPost);
            _context.SaveChanges();
        }
    }
}