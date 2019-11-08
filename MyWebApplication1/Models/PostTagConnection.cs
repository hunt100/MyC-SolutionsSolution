using MyWebApplication1.Models.Movies;

namespace MyWebApplication1.Models
{
    public class PostTagConnection
    {
        public int Id { get; set; }
        
        public int PostId { get; set; } 
            
        public Post Post { get; set; }
        
        public int TagId { get; set; }
        
        public Tag Tag { get; set; }
    }
}