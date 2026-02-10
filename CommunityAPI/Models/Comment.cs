namespace CommunityAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; } = "";
        public int UserId { get; set; }
        public int BlogPostId { get; set; }
        
    }
}
