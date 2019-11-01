using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWebApplication1.Models.Movies
{
    public class Post
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        
        [Display(Name = "Post Created At")]
        public DateTime CreatedAt { get; set; }
        
        [Display(Name = "Post Description")]
        public string Description { get; set; }
        
        [Display(Name = "Post Author")]
        public virtual Profile PostAuthor { get; set; }
        
        [Display(Name = "Tags List")]
        public virtual ICollection<Tag> Tags { get; set; }
        
        [Display(Name = "Comments List")]
        public virtual ICollection<Comment> Comments { get; set; }
        
        [Display(Name = "Likes list")]
        public virtual ICollection<Like> Likes { get; set; }
        
        [Display(Name = "Photo List")]
        public virtual ICollection<Photo> Photos { get; set; }
    }
}