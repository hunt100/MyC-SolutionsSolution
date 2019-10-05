using System;
using System.ComponentModel.DataAnnotations;

namespace MyWebApplication1.Models.Movies
{
    public class Movie
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        
        [Display(Name = "Movie name")]
        public string Name { get; set; }
        
        [Display(Name = "Author name")]
        public string Author { get; set; }
        
        [Display(Name = "List of genres (by comma)")]
        public string Genre { get; set; }
        
        [Display(Name = "Url to poster")]
        public string Poster { get; set; }
        
        [Display(Name = "Release date")]
        public DateTime CreatedAt { get; set; }
    }
}