using System;
using Microsoft.EntityFrameworkCore;
using MyWebApplication1.Models;
using MyWebApplication1.Models.Movies;

namespace MyWebApplication1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
//            modelBuilder.Entity<Movie>().HasData(new Movie
//                {
//                    Id = 1,
//                    Author = "Todd Phillips",
//                    Genre = "Crime , Drama , Thriller",
//                    Name = "Joker",
//                    Poster = "https://dz7u9q3vpd4eo.cloudfront.net/admin-uploads/posters/mxt_movies_poster/joker_dabf394a-d4f2-4b68-90e2-011ed6b54012_poster.png?d=270x360&q=20",
//                    CreatedAt = new DateTime(2019, 10, 3)
//                },
//                new Movie
//                {
//                    Id = 2,
//                    Author = "David Leitch",
//                    Genre = "Action , Adventure",
//                    Name = "Fast & Furious Presents: Hobbs & Shaw",
//                    Poster = "https://dz7u9q3vpd4eo.cloudfront.net/admin-uploads/posters/mxt_movies_poster/fast-furious-presents-hobbs-shaw_14d1ab4f-c90c-46d1-9e04-f7d69f285ebd_poster.png?d=270x360&q=20",
//                    CreatedAt = new DateTime(2019, 8, 2)
//                },
//                new Movie
//                {
//                    Id = 3,
//                    Author = "Jon Favreau",
//                    Genre = "Adventure , Animation , Drama , Family , Musical",
//                    Name = "The Lion King",
//                    Poster = "https://dz7u9q3vpd4eo.cloudfront.net/admin-uploads/posters/mxt_movies_poster/the-lion-king_3904aadc-3a07-4836-892f-763b2dfdeea3_poster.png?d=270x360&q=20",
//                    CreatedAt = new DateTime(2019, 7, 19)
//                },
//                new Movie
//                {
//                    Id = 4,
//                    Author = "Joachim Rønning",
//                    Genre = "Adventure , Family , Fantasy",
//                    Name = "Maleficent: Mistress of Evil",
//                    Poster = "https://dz7u9q3vpd4eo.cloudfront.net/admin-uploads/posters/mxt_movies_poster/maleficent-mistress-of-evil_c8507e61-a6b3-404d-b8c5-df6f74bc62be_poster.png?d=270x360&q=20",
//                    CreatedAt = new DateTime(2019, 10, 18)
//                });

            modelBuilder.Entity<Profile>().HasOne(m => m.User).WithOne(u => u.Profile)
                .HasForeignKey<Profile>(j => j.UserId);

            modelBuilder.Entity<Comment>().HasOne(p => p.Post).WithMany(c => c.Comments)
                .HasForeignKey(p => p.PostId);

            modelBuilder.Entity<PostTagConnection>().HasKey(p => new {p.TagId, p.PostId});
            
            modelBuilder.Entity<PostTagConnection>().HasOne(p => p.Post).WithMany(c => c.PostTagConnections)
                .HasForeignKey(p => p.PostId);
            
            modelBuilder.Entity<PostTagConnection>().HasOne(p => p.Tag).WithMany(c => c.PostTagConnections)
                .HasForeignKey(p => p.TagId);
            
            modelBuilder.Entity<Post>().HasOne(p => p.PostAuthor).WithMany(c => c.Posts)
                .HasForeignKey(p => p.ProfileId);
            
            modelBuilder.Entity<Comment>().HasOne(p => p.CommentAuthor).WithMany(c => c.Comments)
                .HasForeignKey(p => p.ProfileId);
            
            modelBuilder.Entity<Like>().HasOne(p => p.LikeAuthor).WithMany(c => c.Likes)
                .HasForeignKey(p => p.ProfileId);
            
            modelBuilder.Entity<Like>().HasOne(p => p.LikePost).WithMany(c => c.Likes)
                .HasForeignKey(p => p.PostId);
            
            modelBuilder.Entity<Photo>().HasOne(p => p.Post).WithMany(c => c.Photos)
                .HasForeignKey(p => p.PostId);
        }
    }
}