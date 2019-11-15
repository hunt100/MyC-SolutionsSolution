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
    public class PhotoRepository : IPhotoRepository
    {
        readonly DataContext _context;

        public PhotoRepository(DataContext context)
        {
            _context = context;
        }
        
        public void Add(Photo Photo)
        {
            _context.Add(Photo);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var Photo = _context.Photos.Find(id);
            _context.Remove(Photo);
        }

        public Task<List<Photo>> GetAll()
        {
            return _context.Photos.ToListAsync();
        }

        public Task<List<Photo>> GetPhotos(Expression<Func<Photo, bool>> predicate)
        {
            return _context.Photos.Where(predicate).ToListAsync();
        }

        public void Edit(Photo Photo)
        {
            _context.Update(Photo);
        }

        public Task<Photo> GetPhotoById(int id)
        {
            return  _context.Photos.FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool PhotoExistAndId(int id)
        {
            return _context.Photos.Any(m => m.Id == id);
        }
    }
}