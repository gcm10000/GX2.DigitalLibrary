using GX2.DigitalLibrary.Interfaces;
using GX2.DigitalLibrary.ViewModel.Models;
using GX2.DigitalLibrary.Web.Controllers.API;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GX2.DigitalLibrary.Tests.Controllers
{
    public class UnitTestAuthor
    {
        private readonly Mock<IAuthorService> _mockAuthorService = new();

        [Fact]
        public void TestIndex()
        {
            AuthorController controller = new(_mockAuthorService.Object);

            var result = controller.Index();

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void TestFind()
        {
            AuthorController controller = new(_mockAuthorService.Object);

            var result = controller.Find(0);

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void TestAdd()
        {
            _mockAuthorService.Setup(x => x.InsertAuthor(It.IsAny<AuthorViewModel>())).Returns(true);

            AuthorController controller = new(_mockAuthorService.Object);

            var result = await controller.Add(It.IsAny<AuthorViewModel>());

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
        
        [Fact]
        public async void TestUpdate()
        {
            _mockAuthorService.Setup(x => x.UpdateAuthor(It.IsAny<AuthorViewModel>())).Returns(true);

            AuthorController controller = new(_mockAuthorService.Object);

            var result = await controller.Update(It.IsAny<AuthorViewModel>());

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }        
        [Fact]
        public async void TestDelete()
        {
            _mockAuthorService.Setup(x => x.DeleteAuthor(It.IsAny<int>())).Returns(true);

            AuthorController controller = new(_mockAuthorService.Object);

            var result = await controller.Delete(It.IsAny<int>());

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
