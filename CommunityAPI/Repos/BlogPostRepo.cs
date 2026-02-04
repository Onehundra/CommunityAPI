using CommunityAPI.Data;
using CommunityAPI.Models;
using CommunityAPI.Interfaces;



namespace CommunityAPI.Repos
    
{
    public class BlogPostRepo : IBlogPostRepo
    {
        private readonly AppDbContext _db;


        public BlogPostRepo(AppDbContext db)
        { 
            _db = db;
        }
        public void Add(BlogPost post)
        {
            _db.BlogPosts.Add(post);
            _db.SaveChanges();
        }
    }
}
