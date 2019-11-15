using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebApplication1.Data;
using MyWebApplication1.Models.Movies;

namespace MyWebApplication1.Services
{
    public class LikeRepository : ILikeRepository
    {
        readonly DataContext _context;

        public LikeRepository(DataContext context)
        {
            _context = context;
        }
        
        public void Add(Like like)
        {
            _context.Add(like);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var like = _context.Likes.Find(id);
            _context.Remove(like);
        }

        public Task<List<Like>> GetAll()
        {
            return _context.Likes.ToListAsync();
        }

        public Task<List<Like>> GetLikes(Expression<Func<Like, bool>> predicate)
        {
            return _context.Likes.Where(predicate).ToListAsync();
        }

        public void Edit(Like like)
        {
            _context.Update(like);
        }

        public Task<Like> GetLikeById(int id)
        {
            return  _context.Likes.FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool LikeExistAndId(int id)
        {
            return _context.Likes.Any(m => m.Id == id);
        }
    }
}