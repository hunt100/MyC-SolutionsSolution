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
    public class ProfileTest1
    {
        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IProfileRepository>();
            var ProfileService = new ProfileService(fakeRepository);
            var Profile = new Profile(){Id = 1, Age = 18, City = "Almaty", FirstName = "Anvar",LastName = "HunT", Born = DateTime.Parse("2019-05-05")};
            await ProfileService.AddAndSafe(Profile);
        }

        [Fact]
        public async Task GetProfileTest()
        {
            var Profiles = new List<Profile>
            {
                new Profile() {Id = 1, Age = 18, City = "Almaty", FirstName = "Anvar",LastName = "HunT", Born = DateTime.Parse("2019-05-05")},
                new Profile() {Id = 2, Age = 19, City = "Almaty", FirstName = "Dias",LastName = "Isabekov", Born = DateTime.Parse("2019-04-03")},
            };

            var fakeRepositoryMock = new Mock<IProfileRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(Profiles);


            var ProfileService = new ProfileService(fakeRepositoryMock.Object);

            var resultProfiles = await ProfileService.GetProfiles();

            Assert.Collection(resultProfiles, Profile => { Assert.Equal(18, Profile.Age); },
                Profile => { Assert.Equal(DateTime.Parse("2019-04-03"), Profile.Born); });
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IProfileRepository>();
            var ProfileService = new ProfileService(fakeRepository);
            int ProfileId = 1;
            await ProfileService.Delete(ProfileId);
        }
        
        [Fact]
        public async Task EditTest()
        {
            var fakeRepository = Mock.Of<IProfileRepository>();
            var ProfileService = new ProfileService(fakeRepository);
            var Profile = new Profile() {Id = 1, Age = 18, City = "Almaty", FirstName = "Anvar",LastName = "HunT", Born = DateTime.Now};
            await ProfileService.Edit(Profile);
        }
        
        [Fact]
        public async Task GetProfileByIdTest()
        {
            int id = 1;
            var Profile2 = new Profile() {Id = id, Age = 18, City = "Almaty", FirstName = "Anvar",LastName = "HunT", Born = DateTime.Now};

            var fakeRepositoryMock = new Mock<IProfileRepository>();
            fakeRepositoryMock.Setup(x => x.GetProfileById(id)).ReturnsAsync(Profile2);
            
            var ProfileService = new ProfileService(fakeRepositoryMock.Object);
            var resultProfile = await ProfileService.GetProfileById(id);
            Assert.Equal("Almaty", resultProfile.City);
        }
        
        [Fact]
        public void ProfileExistsTest()
        {
            int ProfileId = 1;

            var fakeRepositoryMock = new Mock<IProfileRepository>();
            fakeRepositoryMock.Setup(x => x.ProfileExistAndId(ProfileId)).Returns(true);

            var ProfileService = new ProfileService(fakeRepositoryMock.Object);

            var isExist = ProfileService.IsProfileExist(ProfileId);

            Assert.True(isExist);
        }
    }
}