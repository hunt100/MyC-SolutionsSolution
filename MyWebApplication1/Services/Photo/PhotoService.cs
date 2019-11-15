using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApplication1.Models;
using MyWebApplication1.Models.Movies;

namespace MyWebApplication1.Services
{
    public class PhotoService
    {
        private readonly IPhotoRepository _PhotoRepository;

        public PhotoService(IPhotoRepository PhotoRepository)
        {
            _PhotoRepository = PhotoRepository;
        }

        public async Task<List<Photo>> GetPhotos() => await _PhotoRepository.GetAll();
        
        public async Task AddAndSafe(Photo Photo)
        {
            _PhotoRepository.Add(Photo);
            await _PhotoRepository.Save();
        }
        
        public async Task Edit(Photo Photo)
        {
            _PhotoRepository.Edit(Photo);
            await _PhotoRepository.Save();
        }

        public async Task<List<Photo>> Edit(int id)
        {
            var searchedPhotos = await _PhotoRepository.GetPhotos(Photo => Photo.Id == id);
            return searchedPhotos;
        }
        
        public async Task Delete(int id)
        {
            _PhotoRepository.Delete(id);
            await _PhotoRepository.Save();
        }

        public async Task<Photo> GetPhotoById(int id)
        {
            return await _PhotoRepository.GetPhotoById(id);
        }

        public bool IsPhotoExist(int id)
        {
            return _PhotoRepository.PhotoExistAndId(id);
        }
        
        
    }
}