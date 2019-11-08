using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApplication1.Models
{
    public class User 
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        
        [Display(Name = "User login")]
        [Required]
        [Remote(action: "IsAdminUser", controller: "User", ErrorMessage = "Can\'t be another admin user")]
        public string Login { get; set; }
        
        [Display(Name = "User password")]
        [SamePasswordLogin(ErrorMessage = "Password ali is not valid")]
        public string Password { get; set; }
        
        [Display(Name = "Active status")]
        public bool Active { get; set; }
        
        public Profile Profile { get; set; }

        public string GetErrorMessage()
        {
            return $"Login and password must be the different {Password}.";
        }
    }
}