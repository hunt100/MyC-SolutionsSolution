using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyWebApplication1.Models.Movies;

namespace MyWebApplication1.Models
{
    public class Profile
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        
        [Display(Name = "Profile FirstName")]
        [Required(ErrorMessage = "First name can't be null'")]
        public string FirstName { get; set; }
        
        [Display(Name = "Profile LastName")]
        [Required(ErrorMessage = "Last name can't be null'")]
        public string LastName { get; set; }
        
        [Display(Name = "Profile Patronymic")]
        public string Patronymic { get; set; }
        
        [Display(Name = "Profile Age")]
        [Range(3, 100, ErrorMessage = "Your too young or old for this system")]
        public int Age { get; set; }
        
        [Display(Name = "Biography")]
        public string Biography { get; set; }
        
        [Display(Name = "City")]
        [Required(ErrorMessage = "City must be provided")]
        [StringLength(50, ErrorMessage = "Too many symbols for City")]
        public string City { get; set; }
        
        [Display(Name = "Profile Joined")]
        [Required(ErrorMessage = "Join Time can't be null'")]
        [RegularExpression(@"^(19|20)dd([- /.])(0[1-9]|1[012])2(0[1-9]|[12][0-9]|3[01])$")]
        [DataType(DataType.Date)]
        public DateTime Joined { get; set; }
        
        [Display(Name = "Profile Born")]
        [Required(ErrorMessage = "Born Time can't be null'")]
        [RegularExpression(@"^(19|20)dd([- /.])(0[1-9]|1[012])2(0[1-9]|[12][0-9]|3[01])$")]
        [DataType(DataType.Date)]
        public DateTime Born { get; set; }
        
        [Display(Name = "Profile Avatar Url")]
        [Url(ErrorMessage = "Wrong url for avatar")]
        public string AvatarUrl { get; set; }
        public int UserId { get; set; }
        
        [Display(Name = "Profile User ref")]
        public virtual User User { get; set; }
        
        public ICollection<Post> Posts { get; set; }
        
        public ICollection<Comment> Comments { get; set; }
        
        public ICollection<Like> Likes { get; set; }
        
    }
}