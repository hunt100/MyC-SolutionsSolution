using System.ComponentModel.DataAnnotations;

namespace MyWebApplication1.Models.Movies
{
    public class Like
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        
        public int ProfileId { get; set; }
        
        [Display(Name = "Like Author")]
        public virtual Profile LikeAuthor{ get; set; }
        
        public int PostId { get; set; }
        
        [Display(Name = "Like Post")]
        public virtual Post LikePost{ get; set; }
        
        [Display(Name = "Like Is Active")]
        public bool Active { get; set; }
    }
}