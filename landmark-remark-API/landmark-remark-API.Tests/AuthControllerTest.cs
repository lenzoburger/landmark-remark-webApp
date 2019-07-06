using landmark_remark_API.Controllers;
using landmark_remark_API.Dtos;
using landmark_remark_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace landmark_remark_API.Tests
{
    public class AuthControllerTest
    {
        [Fact]
        public async Task Create_ReturnsNewlyRegisteredUser()
        {
            // Arrange
            var testUsername = "testingRegUser";
            var dbContext = DbContextMocker.GetLandmarkingContext(nameof(Create_ReturnsNewlyRegisteredUser));
            var repository = new AuthRepository(dbContext);
            var mapper = IMapperMocker.getMapper();
            var controller = new AuthController(repository, mapper);

            var newUser = new UserRegisterDto()
            {
                Username = testUsername,
                Password = "TestingRegPwd123@",
                Email = "testingRegUser@gmail.com"
            };

            // Act
            var response = await controller.Register(newUser) as ObjectResult;

            // Assert
            var createdUser = Assert.IsType<UserToReturnDto>(response.Value);
            Assert.Equal(testUsername.ToLower(), createdUser.Username);


            //cleanup
            dbContext.Dispose();
        }
    }
}
