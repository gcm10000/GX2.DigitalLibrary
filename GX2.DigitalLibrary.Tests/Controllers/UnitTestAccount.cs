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
    public class UnitTestAccount
    {
        readonly Mock<IAccountService> _mockAccountService = new();

        [Fact]
        public async void RegisterTest()
        {
            _mockAccountService.Setup(x => x.RegisterAsync(It.IsAny<RegisterViewModel>()).Result).Returns(true);
            AccountController accountController = new(_mockAccountService.Object);
            
            var result = await accountController.RegisterAsync(It.IsAny<RegisterViewModel>());

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void UpdateTest()
        {
            _mockAccountService.Setup(x => x.UpdateAsync(It.IsAny<RegisterViewModel>()).Result).Returns(true);
            AccountController accountController = new(_mockAccountService.Object);
            
            var result = await accountController.UpdateAsync(It.IsAny<RegisterViewModel>());

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
        
        [Fact]
        public async void DeleteTest()
        {
            _mockAccountService.Setup(x => x.DeleteAsync(It.IsAny<string>()).Result).Returns(true);
            AccountController accountController = new(_mockAccountService.Object);
            
            var result = await accountController.DeleteAsync(It.IsAny<string>());

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
