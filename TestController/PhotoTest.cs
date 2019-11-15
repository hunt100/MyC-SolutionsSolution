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
    public class PhotoTest
    {
        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IPhotoRepository>();
            var PhotoService = new PhotoService(fakeRepository);
            var Photo = new Photo(){Id = 1, PostId = 1, PhotoUrl = "https://2krota.ru/wp-content/uploads/2019/02/0_i-1.jpg"};
            await PhotoService.AddAndSafe(Photo);
        }

        [Fact]
        public async Task GetPhotoTest()
        {
            var Photos = new List<Photo>
            {
                new Photo() {Id = 1, PostId = 1, PhotoUrl = "https://2krota.ru/wp-content/uploads/2019/02/0_i-1.jpg"},
                new Photo() {Id = 2, PostId = 2, PhotoUrl = "https://avatanplus.com/files/photos/mid/5898cefd5798715a14e88daf.jpg"},
            };

            var fakeRepositoryMock = new Mock<IPhotoRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(Photos);


            var PhotoService = new PhotoService(fakeRepositoryMock.Object);

            var resultPhotos = await PhotoService.GetPhotos();

            Assert.Collection(resultPhotos, Photo => { Assert.Equal(1, Photo.PostId); },
                Photo => { Assert.Equal("https://avatanplus.com/files/photos/mid/5898cefd5798715a14e88daf.jpg", Photo.PhotoUrl); });
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IPhotoRepository>();
            var PhotoService = new PhotoService(fakeRepository);
            int PhotoId = 1;
            await PhotoService.Delete(PhotoId);
        }
        
        [Fact]
        public async Task EditTest()
        {
            var fakeRepository = Mock.Of<IPhotoRepository>();
            var PhotoService = new PhotoService(fakeRepository);
            var Photo = new Photo() {Id = 1, PostId = 1, PhotoUrl = "https://2krota.ru/wp-content/uploads/2019/02/0_i-1.jpg"};
            await PhotoService.Edit(Photo);
        }
        
        [Fact]
        public async Task GetPhotoByIdTest()
        {
            int id = 1;
            var Photo2 = new Photo() {Id = id, PostId = 1, PhotoUrl = "https://2krota.ru/wp-content/uploads/2019/02/0_i-1.jpg"};

            var fakeRepositoryMock = new Mock<IPhotoRepository>();
            fakeRepositoryMock.Setup(x => x.GetPhotoById(id)).ReturnsAsync(Photo2);
            
            var PhotoService = new PhotoService(fakeRepositoryMock.Object);
            var resultPhoto = await PhotoService.GetPhotoById(id);
            Assert.Equal("https://2krota.ru/wp-content/uploads/2019/02/0_i-1.jpg", resultPhoto.PhotoUrl);
        }
        
        [Fact]
        public void PhotoExistsTest()
        {
            int PhotoId = 1;

            var fakeRepositoryMock = new Mock<IPhotoRepository>();
            fakeRepositoryMock.Setup(x => x.PhotoExistAndId(PhotoId)).Returns(true);

            var PhotoService = new PhotoService(fakeRepositoryMock.Object);

            var isExist = PhotoService.IsPhotoExist(PhotoId);

            Assert.True(isExist);
        }
    }
}