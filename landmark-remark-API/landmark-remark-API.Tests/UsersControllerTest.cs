using landmark_remark_API.Controllers;
using landmark_remark_API.Dtos;
using landmark_remark_API.Models;
using landmark_remark_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace landmark_remark_API.Tests
{
    public class UsersControllerTest
    {
        [Fact]
        public async Task Get_ReturnsUserDetails()
        {
            // Arrange
            var dbContext = DbContextMocker.GetLandmarkingContext(nameof(Get_ReturnsUserDetails));
            var repository = new LandmarkingRepository(dbContext);
            var mapper = IMapperMocker.getMapper();
            var controller = new UsersController(repository, mapper);
            int userId = 3;

            // Act
            var response = await controller.GetUser(userId) as OkObjectResult;

            // Assert
            var user = Assert.IsType<UserToReturnDto>(response.Value);
            Assert.Equal(userId, user.Id);


            //cleanup
            dbContext.Dispose();
        }
    }
}
