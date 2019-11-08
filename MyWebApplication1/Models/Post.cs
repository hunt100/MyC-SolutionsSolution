using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWebApplication1.Models.Movies
{
    public class Post : IValidatableObject
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        
        [Display(Name = "Post Created At")]
        [Required(ErrorMessage = "Create Time can't be null'")]
        [RegularExpression(@"^(19|20)dd([- /.])(0[1-9]|1[012])2(0[1-9]|[12][0-9]|3[01])$")]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        
        [Display(Name = "Post Description")]
        [StringLength(5000, ErrorMessage = "Too many symbols in post")]
        public string Description { get; set; }

        public int ProfileId { get; set; }
        
        [Display(Name = "Post Author")]
        public virtual Profile PostAuthor { get; set; }
        
        [Display(Name = "Tags List")]
        public virtual ICollection<PostTagConnection> PostTagConnections { get; set; }
        
        [Display(Name = "Comments List")]
        public virtual ICollection<Comment> Comments { get; set; }
        
        [Display(Name = "Likes list")]
        public virtual ICollection<Like> Likes { get; set; }
        
        [Display(Name = "Photo List")]
        public virtual ICollection<Photo> Photos { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Description == "Vlados")
            {
                yield return new ValidationResult(
                    $"Vlados Error Alert!",
                    new[] { "Description" });
            }
        }
    }
}