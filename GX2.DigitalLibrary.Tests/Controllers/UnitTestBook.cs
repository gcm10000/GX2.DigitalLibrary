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
    public class UnitTestBook
    {
        private readonly Mock<IBookService> _mockBookService = new();

        [Fact]
        public void TestIndex()
        {
            BookController controller = new(_mockBookService.Object);

            var result = controller.Index();

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void TestFindByCategory()
        {
            BookController controller = new(_mockBookService.Object);

            var result = controller.FindByCategory(It.IsAny<string>());

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void TestFind()
        {
            BookController controller = new(_mockBookService.Object);

            var result = controller.Find(0);

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void TestAdd()
        {
            _mockBookService.Setup(x => x.InsertBook(It.IsAny<BookViewModel>())).Returns(true);

            BookController controller = new(_mockBookService.Object);

            var result = await controller.Add(It.IsAny<BookViewModel>());

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void TestUpdate()
        {
            _mockBookService.Setup(x => x.UpdateBook(It.IsAny<BookViewModel>())).Returns(true);

            BookController controller = new(_mockBookService.Object);

            var result = await controller.Update(It.IsAny<BookViewModel>());

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
        [Fact]
        public async void TestDelete()
        {
            _mockBookService.Setup(x => x.DeleteBook(It.IsAny<int>())).Returns(true);

            BookController controller = new(_mockBookService.Object);

            var result = await controller.Delete(It.IsAny<int>());

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
