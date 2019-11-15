using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyWebApplication1.Models.Movies;

namespace MyWebApplication1.Services
{
    public interface ILikeRepository
    {
        void Add(Like like);

        Task Save();

        void Delete(int id);

        Task<List<Like>> GetAll();
        
        Task<List<Like>> GetLikes(Expression<Func<Like, bool>> predicate);

        void Edit(Like like);

        Task<Like> GetLikeById(int id);

        bool LikeExistAndId(int id);
    }
}