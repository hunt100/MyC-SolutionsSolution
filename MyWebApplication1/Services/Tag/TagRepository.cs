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
    public class TagRepository : ITagRepository
    {
        readonly DataContext _context;

        public TagRepository(DataContext context)
        {
            _context = context;
        }
        
        public void Add(Tag Tag)
        {
            _context.Add(Tag);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var Tag = _context.Tags.Find(id);
            _context.Remove(Tag);
        }

        public Task<List<Tag>> GetAll()
        {
            return _context.Tags.ToListAsync();
        }

        public Task<List<Tag>> GetTags(Expression<Func<Tag, bool>> predicate)
        {
            return _context.Tags.Where(predicate).ToListAsync();
        }

        public void Edit(Tag Tag)
        {
            _context.Update(Tag);
        }

        public Task<Tag> GetTagById(int id)
        {
            return  _context.Tags.FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool TagExistAndId(int id)
        {
            return _context.Tags.Any(m => m.Id == id);
        }
    }
}