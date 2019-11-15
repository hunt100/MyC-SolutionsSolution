using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyWebApplication1.Models;
using MyWebApplication1.Models.Movies;

namespace MyWebApplication1.Services
{
    public interface ITagRepository
    {
        void Add(Tag Tag);

        Task Save();

        void Delete(int id);

        Task<List<Tag>> GetAll();
        
        Task<List<Tag>> GetTags(Expression<Func<Tag, bool>> predicate);

        void Edit(Tag Tag);

        Task<Tag> GetTagById(int id);

        bool TagExistAndId(int id);
    }
}