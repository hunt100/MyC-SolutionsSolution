using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using Xunit;
using MyWebApplication1;
using MyWebApplication1.Models.Movies;
using MyWebApplication1.Services;

namespace TestController
{
    public class UnitTest1
    {
        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<ILikeRepository>();
            var likeService = new LikeService(fakeRepository);
            var like = new Like() {Active = true, ProfileId = 1};
            await likeService.AddAndSafe(like);
        }

        [Fact]
        public async Task GetLikeTest()
        {
            var likes = new List<Like>
            {
                new Like() {Active = true, ProfileId = 1},
                new Like() {Active = false, ProfileId = 2},
            };

            var fakeRepositoryMock = new Mock<ILikeRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(likes);


            var likeService = new LikeService(fakeRepositoryMock.Object);

            var resultLikes = await likeService.GetLikes();

            Assert.Collection(resultLikes, like => { Assert.True(like.Active); },
                like => { Assert.Equal(2, like.ProfileId); });
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<ILikeRepository>();
            var likeService = new LikeService(fakeRepository);
            int likeId = 1;
            await likeService.Delete(likeId);
        }
        
        [Fact]
        public async Task EditTest()
        {
            var fakeRepository = Mock.Of<ILikeRepository>();
            var likeService = new LikeService(fakeRepository);
            var like = new Like() {ProfileId = 1, Active = false, PostId = 1};
            await likeService.Edit(like);
        }
        
        [Fact]
        public async Task GetLikeByIdTest()
        {
            int id = 1;
            var like2 = new Like() {Id = id, Active = false, PostId = 1, ProfileId = 1};

            var fakeRepositoryMock = new Mock<ILikeRepository>();
            fakeRepositoryMock.Setup(x => x.GetLikeById(id)).ReturnsAsync(like2);
            
            var likeService = new LikeService(fakeRepositoryMock.Object);
            var resultLike = await likeService.GetLikeById(id);
            Assert.Equal(1, resultLike.PostId);
        }
        
        [Fact]
        public void LikeExistsTest()
        {
            int likeId = 1;

            var fakeRepositoryMock = new Mock<ILikeRepository>();
            fakeRepositoryMock.Setup(x => x.LikeExistAndId(likeId)).Returns(true);

            var likeService = new LikeService(fakeRepositoryMock.Object);

            var isExist = likeService.IsLikeExist(likeId);

            Assert.True(isExist);
        }
    }
}