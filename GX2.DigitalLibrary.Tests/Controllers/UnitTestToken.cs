using GX2.DigitalLibrary.Interfaces;
using GX2.DigitalLibrary.ViewModel;
using GX2.DigitalLibrary.ViewModel.Models;
using GX2.DigitalLibrary.Web.Controllers.API;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace GX2.DigitalLibrary.Tests.Controllers
{
    public class UnitTestToken
    {
        #region Property
        private readonly Mock<ITokenService> _mockToken = new();
        private readonly Mock<IAccountService> _mockAccountService = new();
        #endregion

        [Fact]
        public async void TestToken()
        {
            _mockAccountService.Setup(x => x.ValidateAsync(It.IsAny<string>(), It.IsAny<string>()).Result).Returns(true);

            TokenController tokenController = new(_mockAccountService.Object, _mockToken.Object);

            CredentialViewModel credentialViewModel = new()
            {
                Username = "gcm10000",
                Password = "SenhaSecreta#2021",
                Role = "Admin"
            };

            var result = await tokenController.AccessToken(credentialViewModel);

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
