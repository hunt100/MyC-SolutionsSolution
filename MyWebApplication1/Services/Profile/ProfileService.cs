using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApplication1.Models;
using MyWebApplication1.Models.Movies;

namespace MyWebApplication1.Services
{
    public class ProfileService
    {
        private readonly IProfileRepository _ProfileRepository;

        public ProfileService(IProfileRepository ProfileRepository)
        {
            _ProfileRepository = ProfileRepository;
        }

        public async Task<List<Profile>> GetProfiles() => await _ProfileRepository.GetAll();
        
        public async Task AddAndSafe(Profile Profile)
        {
            _ProfileRepository.Add(Profile);
            await _ProfileRepository.Save();
        }
        
        public async Task Edit(Profile Profile)
        {
            _ProfileRepository.Edit(Profile);
            await _ProfileRepository.Save();
        }

        public async Task<List<Profile>> Edit(int id)
        {
            var searchedProfiles = await _ProfileRepository.GetProfiles(Profile => Profile.Id == id);
            return searchedProfiles;
        }
        
        public async Task Delete(int id)
        {
            _ProfileRepository.Delete(id);
            await _ProfileRepository.Save();
        }

        public async Task<Profile> GetProfileById(int id)
        {
            return await _ProfileRepository.GetProfileById(id);
        }

        public bool IsProfileExist(int id)
        {
            return _ProfileRepository.ProfileExistAndId(id);
        }
        
        
    }
}