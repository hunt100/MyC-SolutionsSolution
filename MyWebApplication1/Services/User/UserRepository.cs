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
    public class UserRepository : IUserRepository
    {
        readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        
        public void Add(User User)
        {
            _context.Add(User);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var User = _context.Users.Find(id);
            _context.Remove(User);
        }

        public Task<List<User>> GetAll()
        {
            return _context.Users.ToListAsync();
        }

        public Task<List<User>> GetUsers(Expression<Func<User, bool>> predicate)
        {
            return _context.Users.Where(predicate).ToListAsync();
        }

        public void Edit(User User)
        {
            _context.Update(User);
        }

        public Task<User> GetUserById(int id)
        {
            return  _context.Users.FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool UserExistAndId(int id)
        {
            return _context.Users.Any(m => m.Id == id);
        }
    }
}