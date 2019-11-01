using System;
using System.ComponentModel.DataAnnotations;

namespace MyWebApplication1.Models
{
    public class Profile
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        
        [Display(Name = "Profile FirstName")]
        public string FirstName { get; set; }
        
        [Display(Name = "Profile LastName")]
        public string LastName { get; set; }
        
        [Display(Name = "Profile Patronymic")]
        public string Patronymic { get; set; }
        
        [Display(Name = "Profile Age")]
        public int Age { get; set; }
        
        [Display(Name = "Biography")]
        public string Biography { get; set; }
        
        [Display(Name = "City")]
        public string City { get; set; }
        
        [Display(Name = "Profile Joined")]
        public DateTime Joined { get; set; }
        
        [Display(Name = "Profile Born")]
        public DateTime Born { get; set; }
        
        [Display(Name = "Profile Avatar Url")]
        public string AvatarUrl { get; set; }
        
        [Display(Name = "Profile User ref")]
        public virtual User User { get; set; }
        
    }
}