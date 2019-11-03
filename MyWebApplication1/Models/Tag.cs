using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWebApplication1.Models.Movies
{
    public enum Color
    {
        RED, BLUE, GREEN, WHITE, GREY
    }
    
    public class Tag
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        
        [Display(Name = "Tag Name")]
        public string TagName { get; set; }
        
        [Display(Name = "Tag Color")]
        public Color? Color { get; set; }
        
        [Display(Name = "Posts List")]
        public virtual ICollection<PostTagConnection> PostTagConnections { get; set; }
    }
}