using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApplication1.Models;
using MyWebApplication1.Models.Movies;

namespace MyWebApplication1.Services
{
    public class UserService
    {
        private readonly IUserRepository _UserRepository;

        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public async Task<List<User>> GetUsers() => await _UserRepository.GetAll();
        
        public async Task AddAndSafe(User User)
        {
            _UserRepository.Add(User);
            await _UserRepository.Save();
        }
        
        public async Task Edit(User User)
        {
            _UserRepository.Edit(User);
            await _UserRepository.Save();
        }

        public async Task<List<User>> Edit(int id)
        {
            var searchedUsers = await _UserRepository.GetUsers(User => User.Id == id);
            return searchedUsers;
        }
        
        public async Task Delete(int id)
        {
            _UserRepository.Delete(id);
            await _UserRepository.Save();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _UserRepository.GetUserById(id);
        }

        public bool IsUserExist(int id)
        {
            return _UserRepository.UserExistAndId(id);
        }
        
        
    }
}