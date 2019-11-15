using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyWebApplication1.Models;
using MyWebApplication1.Models.Movies;

namespace MyWebApplication1.Services
{
    public interface IPhotoRepository
    {
        void Add(Photo Photo);

        Task Save();

        void Delete(int id);

        Task<List<Photo>> GetAll();
        
        Task<List<Photo>> GetPhotos(Expression<Func<Photo, bool>> predicate);

        void Edit(Photo Photo);

        Task<Photo> GetPhotoById(int id);

        bool PhotoExistAndId(int id);
    }
}