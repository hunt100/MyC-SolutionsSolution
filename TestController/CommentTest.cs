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
    public class CommentTest
    {
        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<ICommentRepository>();
            var CommentService = new CommentService(fakeRepository);
            var Comment = new Comment(){Id = 1, CreatedAt = DateTime.Parse("2018-03-03"), CommentDescription = "CommentDescription"};
            await CommentService.AddAndSafe(Comment);
        }

        [Fact]
        public async Task GetCommentTest()
        {
            var Comments = new List<Comment>
            {
                new Comment() {Id = 1, CreatedAt = DateTime.Parse("2018-03-03"), CommentDescription = "CommentDescription"},
                new Comment() {Id = 2, CreatedAt = DateTime.Parse("2019-05-01"), CommentDescription = "CommentDescription2"},
            };

            var fakeRepositoryMock = new Mock<ICommentRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(Comments);


            var CommentService = new CommentService(fakeRepositoryMock.Object);

            var resultComments = await CommentService.GetComments();

            Assert.Collection(resultComments, Comment => { Assert.Equal("CommentDescription", Comment.CommentDescription); },
                Comment => { Assert.Equal(DateTime.Parse("2019-05-01"),Comment.CreatedAt); });
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<ICommentRepository>();
            var CommentService = new CommentService(fakeRepository);
            int CommentId = 1;
            await CommentService.Delete(CommentId);
        }
        
        [Fact]
        public async Task EditTest()
        {
            var fakeRepository = Mock.Of<ICommentRepository>();
            var CommentService = new CommentService(fakeRepository);
            var Comment = new Comment() {Id = 1, CreatedAt = DateTime.Parse("2018-03-03"), CommentDescription = "CommentDescription"};
            await CommentService.Edit(Comment);
        }
        
        [Fact]
        public async Task GetCommentByIdTest()
        {
            int id = 1;
            var Comment2 = new Comment() {Id = id, CreatedAt = DateTime.Parse("2018-03-03"), CommentDescription = "CommentDescription"};

            var fakeRepositoryMock = new Mock<ICommentRepository>();
            fakeRepositoryMock.Setup(x => x.GetCommentById(id)).ReturnsAsync(Comment2);
            
            var CommentService = new CommentService(fakeRepositoryMock.Object);
            var resultComment = await CommentService.GetCommentById(id);
            Assert.Equal("CommentDescription", resultComment.CommentDescription);
        }
        
        [Fact]
        public void CommentExistsTest()
        {
            int CommentId = 1;

            var fakeRepositoryMock = new Mock<ICommentRepository>();
            fakeRepositoryMock.Setup(x => x.CommentExistAndId(CommentId)).Returns(true);

            var CommentService = new CommentService(fakeRepositoryMock.Object);

            var isExist = CommentService.IsCommentExist(CommentId);

            Assert.True(isExist);
        }
    }
}