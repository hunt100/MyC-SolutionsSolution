using System.ComponentModel.DataAnnotations;

namespace MyWebApplication1.Models
{
    public class User
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        
        [Display(Name = "User login")]
        public string Login { get; set; }
        
        [Display(Name = "User password")]
        public string Password { get; set; }
        
        [Display(Name = "Active status")]
        public bool Active { get; set; }
        
        public Profile Profile { get; set; }
    }
}