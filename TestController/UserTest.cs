using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using Xunit;
using MyWebApplication1;
using MyWebApplication1.Models;
using MyWebApplication1.Models.Movies;
using MyWebApplication1.Services;

namespace TestController
{
    public class UserTest1
    {
        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IUserRepository>();
            var UserService = new UserService(fakeRepository);
            var User = new User(){Id = 1, Login = "Ali", Password = "HeAli", Active = true};
            await UserService.AddAndSafe(User);
        }

        [Fact]
        public async Task GetUserTest()
        {
            var Users = new List<User>
            {
                new User() {Active = true, Id = 1, Login = "Ali", Password = "HeAli"},
                new User() {Active = false, Id = 2, Login = "Dima", Password = "Pak"},
            };

            var fakeRepositoryMock = new Mock<IUserRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(Users);


            var UserService = new UserService(fakeRepositoryMock.Object);

            var resultUsers = await UserService.GetUsers();

            Assert.Collection(resultUsers, User => { Assert.Equal("Ali", User.Login); },
                User => { Assert.Equal("Pak", User.Password); });
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IUserRepository>();
            var UserService = new UserService(fakeRepository);
            int UserId = 1;
            await UserService.Delete(UserId);
        }
        
        [Fact]
        public async Task EditTest()
        {
            var fakeRepository = Mock.Of<IUserRepository>();
            var UserService = new UserService(fakeRepository);
            var User = new User() {Id = 1, Login = "Ali", Password = "HeAli", Active = true};
            await UserService.Edit(User);
        }
        
        [Fact]
        public async Task GetUserByIdTest()
        {
            int id = 1;
            var User2 = new User() {Id = id, Login = "Ali", Password = "HeAli"};

            var fakeRepositoryMock = new Mock<IUserRepository>();
            fakeRepositoryMock.Setup(x => x.GetUserById(id)).ReturnsAsync(User2);
            
            var UserService = new UserService(fakeRepositoryMock.Object);
            var resultUser = await UserService.GetUserById(id);
            Assert.Equal("Ali", resultUser.Login);
        }
        
        [Fact]
        public void UserExistsTest()
        {
            int UserId = 1;

            var fakeRepositoryMock = new Mock<IUserRepository>();
            fakeRepositoryMock.Setup(x => x.UserExistAndId(UserId)).Returns(true);

            var UserService = new UserService(fakeRepositoryMock.Object);

            var isExist = UserService.IsUserExist(UserId);

            Assert.True(isExist);
        }
    }
}