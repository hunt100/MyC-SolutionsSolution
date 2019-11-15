using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyWebApplication1.Models;
using MyWebApplication1.Models.Movies;

namespace MyWebApplication1.Services
{
    public interface IUserRepository
    {
        void Add(User user);

        Task Save();

        void Delete(int id);

        Task<List<User>> GetAll();
        
        Task<List<User>> GetUsers(Expression<Func<User, bool>> predicate);

        void Edit(User user);

        Task<User> GetUserById(int id);

        bool UserExistAndId(int id);
    }
}