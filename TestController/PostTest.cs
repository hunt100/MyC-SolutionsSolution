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
    public class PostTest
    {
        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IPostRepository>();
            var PostService = new PostService(fakeRepository);
            var Post = new Post(){Id = 1, Description = "This is my description", CreatedAt = DateTime.Parse("2019-05-05"), ProfileId = 1};
            await PostService.AddAndSafe(Post);
        }

        [Fact]
        public async Task GetPostTest()
        {
            var Posts = new List<Post>
            {
                new Post() {Id = 1, Description = "This is my description", CreatedAt = DateTime.Parse("2019-05-05"), ProfileId = 1},
                new Post() {Id = 2, Description = "This is my description222", CreatedAt = DateTime.Parse("2019-04-04"), ProfileId = 2},
            };

            var fakeRepositoryMock = new Mock<IPostRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(Posts);


            var PostService = new PostService(fakeRepositoryMock.Object);

            var resultPosts = await PostService.GetPosts();

            Assert.Collection(resultPosts, Post => { Assert.Equal(DateTime.Parse("2019-05-05"), Post.CreatedAt);},
                Post => { Assert.Equal("This is my description222", Post.Description); });
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IPostRepository>();
            var PostService = new PostService(fakeRepository);
            int PostId = 1;
            await PostService.Delete(PostId);
        }
        
        [Fact]
        public async Task EditTest()
        {
            var fakeRepository = Mock.Of<IPostRepository>();
            var PostService = new PostService(fakeRepository);
            var Post = new Post() {Id = 1, Description = "This is my description", CreatedAt = DateTime.Parse("2019-05-05"), ProfileId = 1};
            await PostService.Edit(Post);
        }
        
        [Fact]
        public async Task GetPostByIdTest()
        {
            int id = 1;
            var Post2 = new Post() {Id = id, Description = "This is my description", CreatedAt = DateTime.Parse("2019-05-05"), ProfileId = 3};

            var fakeRepositoryMock = new Mock<IPostRepository>();
            fakeRepositoryMock.Setup(x => x.GetPostById(id)).ReturnsAsync(Post2);
            
            var PostService = new PostService(fakeRepositoryMock.Object);
            var resultPost = await PostService.GetPostById(id);
            Assert.Equal(3, resultPost.ProfileId);
        }
        
        [Fact]
        public void PostExistsTest()
        {
            int PostId = 1;

            var fakeRepositoryMock = new Mock<IPostRepository>();
            fakeRepositoryMock.Setup(x => x.PostExistAndId(PostId)).Returns(true);

            var PostService = new PostService(fakeRepositoryMock.Object);

            var isExist = PostService.IsPostExist(PostId);

            Assert.True(isExist);
        }
    }
}