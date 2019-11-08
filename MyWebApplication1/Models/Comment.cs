using System;
using System.ComponentModel.DataAnnotations;

namespace MyWebApplication1.Models.Movies
{
    public class Comment
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        
        [Display(Name = "Comment Description")]
        [Required(ErrorMessage = "Comment can't be empty'")]
        public string CommentDescription { get; set; }
        
        [Display(Name = "Comment Created At")]
        public DateTime CreatedAt { get; set; }
        
        public int PostId { get; set; }
        
        [Display(Name = "Comment on Post")]
        public virtual Post Post { get; set; }

        public int ProfileId { get; set; }
        
        [Display(Name = "Comment Author")]
        public virtual Profile CommentAuthor { get; set; }
    }
}