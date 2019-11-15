using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApplication1.Models.Movies;

namespace MyWebApplication1.Services
{
    public class LikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<List<Like>> GetLikes() => await _likeRepository.GetAll();
        
        public async Task AddAndSafe(Like like)
        {
            _likeRepository.Add(like);
            await _likeRepository.Save();
        }
        
        public async Task Edit(Like like)
        {
            _likeRepository.Edit(like);
            await _likeRepository.Save();
        }

        public async Task<List<Like>> Edit(int id)
        {
            var searchedLikes = await _likeRepository.GetLikes(like => like.Id == id);
            return searchedLikes;
        }
        
        public async Task Delete(int id)
        {
            _likeRepository.Delete(id);
            await _likeRepository.Save();
        }

        public async Task<Like> GetLikeById(int id)
        {
            return await _likeRepository.GetLikeById(id);
        }

        public bool IsLikeExist(int id)
        {
            return _likeRepository.LikeExistAndId(id);
        }
        
        
    }
}