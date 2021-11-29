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
    public class UnitTestMovementBook
    {
        private readonly Mock<IMovementBookService> _mockMovementBookService = new();

        [Fact]
        public async void TestReserve()
        {
            _mockMovementBookService.Setup(x => x.Reserve(It.IsAny<BookViewModel>())).Returns(true);

            MovementBookController controller = new(_mockMovementBookService.Object);

            var result = await controller.Reserve(It.IsAny<BookViewModel>());

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
        
        [Fact]
        public async void TestReturn()
        {
            _mockMovementBookService.Setup(x => x.Return(It.IsAny<BookViewModel>())).Returns(true);

            MovementBookController controller = new(_mockMovementBookService.Object);

            var result = await controller.Return(It.IsAny<BookViewModel>());

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

    }
}
