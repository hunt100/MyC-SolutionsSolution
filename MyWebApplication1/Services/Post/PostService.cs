using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApplication1.Models;
using MyWebApplication1.Models.Movies;

namespace MyWebApplication1.Services
{
    public class PostService
    {
        private readonly IPostRepository _PostRepository;

        public PostService(IPostRepository PostRepository)
        {
            _PostRepository = PostRepository;
        }

        public async Task<List<Post>> GetPosts() => await _PostRepository.GetAll();
        
        public async Task AddAndSafe(Post Post)
        {
            _PostRepository.Add(Post);
            await _PostRepository.Save();
        }
        
        public async Task Edit(Post Post)
        {
            _PostRepository.Edit(Post);
            await _PostRepository.Save();
        }

        public async Task<List<Post>> Edit(int id)
        {
            var searchedPosts = await _PostRepository.GetPosts(Post => Post.Id == id);
            return searchedPosts;
        }
        
        public async Task Delete(int id)
        {
            _PostRepository.Delete(id);
            await _PostRepository.Save();
        }

        public async Task<Post> GetPostById(int id)
        {
            return await _PostRepository.GetPostById(id);
        }

        public bool IsPostExist(int id)
        {
            return _PostRepository.PostExistAndId(id);
        }
        
        
    }
}