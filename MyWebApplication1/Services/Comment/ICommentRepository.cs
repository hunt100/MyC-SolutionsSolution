using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyWebApplication1.Models;
using MyWebApplication1.Models.Movies;

namespace MyWebApplication1.Services
{
    public interface ICommentRepository
    {
        void Add(Comment Comment);

        Task Save();

        void Delete(int id);

        Task<List<Comment>> GetAll();
        
        Task<List<Comment>> GetComments(Expression<Func<Comment, bool>> predicate);

        void Edit(Comment Comment);

        Task<Comment> GetCommentById(int id);

        bool CommentExistAndId(int id);
    }
}