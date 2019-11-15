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
    public class TagTest
    {
        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<ITagRepository>();
            var TagService = new TagService(fakeRepository);
            var Tag = new Tag(){Id = 1, Color = Color.RED, TagName = "INCIDENTS"};
            await TagService.AddAndSafe(Tag);
        }

        [Fact]
        public async Task GetTagTest()
        {
            var Tags = new List<Tag>
            {
                new Tag() {Id = 1, Color = Color.RED, TagName = "INCIDENTS"},
                new Tag() {Id = 2, Color = Color.BLUE, TagName = "Topic"},
            };

            var fakeRepositoryMock = new Mock<ITagRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(Tags);


            var TagService = new TagService(fakeRepositoryMock.Object);

            var resultTags = await TagService.GetTags();

            Assert.Collection(resultTags, Tag => { Assert.Equal("INCIDENTS", Tag.TagName); },
                Tag => { Assert.Equal(Color.BLUE, Tag.Color); });
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<ITagRepository>();
            var TagService = new TagService(fakeRepository);
            int TagId = 1;
            await TagService.Delete(TagId);
        }
        
        [Fact]
        public async Task EditTest()
        {
            var fakeRepository = Mock.Of<ITagRepository>();
            var TagService = new TagService(fakeRepository);
            var Tag = new Tag() {Id = 1, Color = Color.RED, TagName = "INCIDENTS"};
            await TagService.Edit(Tag);
        }
        
        [Fact]
        public async Task GetTagByIdTest()
        {
            int id = 1;
            var Tag2 = new Tag() {Id = id, Color = Color.RED, TagName = "INCIDENTS"};

            var fakeRepositoryMock = new Mock<ITagRepository>();
            fakeRepositoryMock.Setup(x => x.GetTagById(id)).ReturnsAsync(Tag2);
            
            var TagService = new TagService(fakeRepositoryMock.Object);
            var resultTag = await TagService.GetTagById(id);
            Assert.Equal(Color.RED, resultTag.Color);
        }
        
        [Fact]
        public void TagExistsTest()
        {
            int TagId = 1;

            var fakeRepositoryMock = new Mock<ITagRepository>();
            fakeRepositoryMock.Setup(x => x.TagExistAndId(TagId)).Returns(true);

            var TagService = new TagService(fakeRepositoryMock.Object);

            var isExist = TagService.IsTagExist(TagId);

            Assert.True(isExist);
        }
    }
}