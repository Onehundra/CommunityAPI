using CommunityAPI.Interfaces;
using CommunityAPI.Models;
namespace CommunityAPI.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepo _blogPostRepo;

        public BlogPostService(IBlogPostRepo blogPostRepo)
        {
            _blogPostRepo = blogPostRepo;
        }

        public void Create(BlogPost post)
        {
            _blogPostRepo.Add(post);
        }
    }
}
