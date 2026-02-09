namespace CommunityAPI.DTOs
{
    public class CreateCommentDto
    {
        public int UserId { get; set; }
        public int BlogPostId { get; set; }
        public string Text { get; set; } = "";
    }
}
