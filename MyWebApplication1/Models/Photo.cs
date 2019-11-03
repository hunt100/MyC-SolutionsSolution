using System.ComponentModel.DataAnnotations;

namespace MyWebApplication1.Models.Movies
{
    public class Photo
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        
        [Display(Name = "PhotoUrl")]
        public string PhotoUrl { get; set; }
        
        public int PostId { get; set; }
        
        [Display(Name = "Photo on Post")]
        public Post Post { get; set; }
    }
}