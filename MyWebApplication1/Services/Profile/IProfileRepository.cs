using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyWebApplication1.Models;
using MyWebApplication1.Models.Movies;

namespace MyWebApplication1.Services
{
    public interface IProfileRepository
    {
        void Add(Profile Profile);

        Task Save();

        void Delete(int id);

        Task<List<Profile>> GetAll();
        
        Task<List<Profile>> GetProfiles(Expression<Func<Profile, bool>> predicate);

        void Edit(Profile Profile);

        Task<Profile> GetProfileById(int id);

        bool ProfileExistAndId(int id);
    }
}