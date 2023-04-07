using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using piktureAPI.Services.PostService;
using piktureAPI.Services.UserService;

namespace piktureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IWebHostEnvironment _environment;
        public PostController(IPostService postService, IWebHostEnvironment environment) { 
            _postService = postService; 
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPostIds()
        {
            var posts = await _postService.GetAllPostIds();
            return Ok(posts);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchPosts()
        {
            String keyWord = Request.Query["key"];
            var posts = await _postService.SearchPosts(keyWord);
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await _postService.GetPostById(id);
            string imagePath = post.imageUrl;

            byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);

            // Return the image as a response with the appropriate MIME type
            return File(imageBytes, "image/jpeg");
        }

        [HttpPost]
        public async Task<IActionResult> UploadPost()
        {
            var formData = Request.Form;
            var image = formData.Files.GetFile("image");
            
            if(image == null || image.Length == 0)
            {
                return BadRequest("Image not selected");
            }
            if (formData["title"] == "")
            {
                return BadRequest("Title not included");
            }

            var imagePath = Path.Combine(_environment.WebRootPath, "Assets", "Posts", image.FileName);

            _postService.AddPost(formData, imagePath);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return Ok("Image uploaded successfully");
        }

    }
}
