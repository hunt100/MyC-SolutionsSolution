using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyWebApplication1.Models;
using MyWebApplication1.Models.Movies;

namespace MyWebApplication1.Services
{
    public interface IPostRepository
    {
        void Add(Post Post);

        Task Save();

        void Delete(int id);

        Task<List<Post>> GetAll();
        
        Task<List<Post>> GetPosts(Expression<Func<Post, bool>> predicate);

        void Edit(Post Post);

        Task<Post> GetPostById(int id);

        bool PostExistAndId(int id);
    }
}