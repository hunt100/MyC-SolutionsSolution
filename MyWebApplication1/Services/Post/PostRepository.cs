using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebApplication1.Data;
using MyWebApplication1.Models;
using MyWebApplication1.Models.Movies;

namespace MyWebApplication1.Services
{
    public class PostRepository : IPostRepository
    {
        readonly DataContext _context;

        public PostRepository(DataContext context)
        {
            _context = context;
        }
        
        public void Add(Post Post)
        {
            _context.Add(Post);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var Post = _context.Posts.Find(id);
            _context.Remove(Post);
        }

        public Task<List<Post>> GetAll()
        {
            return _context.Posts.ToListAsync();
        }

        public Task<List<Post>> GetPosts(Expression<Func<Post, bool>> predicate)
        {
            return _context.Posts.Where(predicate).ToListAsync();
        }

        public void Edit(Post Post)
        {
            _context.Update(Post);
        }

        public Task<Post> GetPostById(int id)
        {
            return  _context.Posts.FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool PostExistAndId(int id)
        {
            return _context.Posts.Any(m => m.Id == id);
        }
    }
}