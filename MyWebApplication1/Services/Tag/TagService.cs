using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApplication1.Models;
using MyWebApplication1.Models.Movies;

namespace MyWebApplication1.Services
{
    public class TagService
    {
        private readonly ITagRepository _TagRepository;

        public TagService(ITagRepository TagRepository)
        {
            _TagRepository = TagRepository;
        }

        public async Task<List<Tag>> GetTags() => await _TagRepository.GetAll();
        
        public async Task AddAndSafe(Tag Tag)
        {
            _TagRepository.Add(Tag);
            await _TagRepository.Save();
        }
        
        public async Task Edit(Tag Tag)
        {
            _TagRepository.Edit(Tag);
            await _TagRepository.Save();
        }

        public async Task<List<Tag>> Edit(int id)
        {
            var searchedTags = await _TagRepository.GetTags(Tag => Tag.Id == id);
            return searchedTags;
        }
        
        public async Task Delete(int id)
        {
            _TagRepository.Delete(id);
            await _TagRepository.Save();
        }

        public async Task<Tag> GetTagById(int id)
        {
            return await _TagRepository.GetTagById(id);
        }

        public bool IsTagExist(int id)
        {
            return _TagRepository.TagExistAndId(id);
        }
        
        
    }
}