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
    public class CommentRepository : ICommentRepository
    {
        readonly DataContext _context;

        public CommentRepository(DataContext context)
        {
            _context = context;
        }
        
        public void Add(Comment Comment)
        {
            _context.Add(Comment);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var Comment = _context.Comments.Find(id);
            _context.Remove(Comment);
        }

        public Task<List<Comment>> GetAll()
        {
            return _context.Comments.ToListAsync();
        }

        public Task<List<Comment>> GetComments(Expression<Func<Comment, bool>> predicate)
        {
            return _context.Comments.Where(predicate).ToListAsync();
        }

        public void Edit(Comment Comment)
        {
            _context.Update(Comment);
        }

        public Task<Comment> GetCommentById(int id)
        {
            return  _context.Comments.FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool CommentExistAndId(int id)
        {
            return _context.Comments.Any(m => m.Id == id);
        }
    }
}