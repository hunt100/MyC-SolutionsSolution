using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApplication1.Models;
using MyWebApplication1.Models.Movies;

namespace MyWebApplication1.Services
{
    public class CommentService
    {
        private readonly ICommentRepository _CommentRepository;

        public CommentService(ICommentRepository CommentRepository)
        {
            _CommentRepository = CommentRepository;
        }

        public async Task<List<Comment>> GetComments() => await _CommentRepository.GetAll();
        
        public async Task AddAndSafe(Comment Comment)
        {
            _CommentRepository.Add(Comment);
            await _CommentRepository.Save();
        }
        
        public async Task Edit(Comment Comment)
        {
            _CommentRepository.Edit(Comment);
            await _CommentRepository.Save();
        }

        public async Task<List<Comment>> Edit(int id)
        {
            var searchedComments = await _CommentRepository.GetComments(Comment => Comment.Id == id);
            return searchedComments;
        }
        
        public async Task Delete(int id)
        {
            _CommentRepository.Delete(id);
            await _CommentRepository.Save();
        }

        public async Task<Comment> GetCommentById(int id)
        {
            return await _CommentRepository.GetCommentById(id);
        }

        public bool IsCommentExist(int id)
        {
            return _CommentRepository.CommentExistAndId(id);
        }
        
        
    }
}