using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebApplication1.Data;
using MyWebApplication1.Models;

namespace MyWebApplication1.Services
{
    public class ProfileRepository : IProfileRepository
    {
        readonly DataContext _context;

        public ProfileRepository(DataContext context)
        {
            _context = context;
        }
        
        public void Add(Profile Profile)
        {
            _context.Add(Profile);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var Profile = _context.Profiles.Find(id);
            _context.Remove(Profile);
        }

        public Task<List<Profile>> GetAll()
        {
            return _context.Profiles.ToListAsync();
        }

        public Task<List<Profile>> GetProfiles(Expression<Func<Profile, bool>> predicate)
        {
            return _context.Profiles.Where(predicate).ToListAsync();
        }

        public void Edit(Profile Profile)
        {
            _context.Update(Profile);
        }

        public Task<Profile> GetProfileById(int id)
        {
            return  _context.Profiles.FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool ProfileExistAndId(int id)
        {
            return _context.Profiles.Any(m => m.Id == id);
        }
    }
}