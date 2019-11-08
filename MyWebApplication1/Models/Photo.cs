using System.ComponentModel.DataAnnotations;

namespace MyWebApplication1.Models.Movies
{
    public class Photo
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        
        [Display(Name = "PhotoUrl")]
        [Required(ErrorMessage = "Url can't be null'")]
        [Url(ErrorMessage = "Url mismatch")]
        public string PhotoUrl { get; set; }
        
        public int PostId { get; set; }
        
        [Display(Name = "Photo on Post")]
        public Post Post { get; set; }
    }
}