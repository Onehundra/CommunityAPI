namespace CommunityAPI.DTOs
{
    public class UpdateBlogPostDto
    {
        public int UserId { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
    }
}
