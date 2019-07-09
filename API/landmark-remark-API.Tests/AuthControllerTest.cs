using landmark_remark_API.Controllers;
using landmark_remark_API.Dtos;
using landmark_remark_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace landmark_remark_API.Tests
{
    public class AuthControllerTest
    {
        // Mock AuthController 'register' method verify CreatedAtRouteResult object
        [Fact]
        public async Task Post_Register_ReturnsNewlyCreatedUser()
        {
            // Arrange
            var testUsername = "testingRegUser";
            var dbContext = DbContextMocker.GetLandmarkingContext(nameof(Post_Register_ReturnsNewlyCreatedUser), false);
            var repository = new AuthRepository(dbContext);
            var mapper = IMapperMocker.getMapper();
            var iConfig = IConfigMocker.getIconfiguration();
            var controller = new AuthController(repository, mapper, iConfig);

            var newUser = new UserRegisterDto()
            {
                Username = testUsername,
                Password = "TestingRegPwd123@",
                Email = "testingRegUser@gmail.com"
            };

            // Act

            var response = await controller.Register(newUser);

            // Assert
            var CreatedAtRouteResult = Assert.IsType<CreatedAtRouteResult>(response);
            var createdUser = Assert.IsType<UserToReturnDto>(CreatedAtRouteResult.Value);
            Assert.Equal(testUsername.ToLower(), createdUser.Username);


            //cleanup
            dbContext.Dispose();
        }

         // Mock AuthController 'login' method verify JWT token and return user object
        [Fact]
        public async Task Post_Login_returnsJWTTokenAndUserObject()
        {
            // Arrange
            var testUsername = "Parsons83";
            var dbContext = DbContextMocker.GetLandmarkingContext(nameof(Post_Login_returnsJWTTokenAndUserObject));
            var repository = new AuthRepository(dbContext);
            var mapper = IMapperMocker.getMapper();
            var iConfig = IConfigMocker.getIconfiguration();
            var controller = new AuthController(repository, mapper, iConfig);

            var userLogin = new UserLoginDto()
            {
                Username = testUsername,
                Password = "password"
            };

            // Act
            var response = await controller.Login(userLogin);

            // Assert
            var OkObjectResult = Assert.IsType<OkObjectResult>(response);

                //// retrieve & convert anonymous response object with Reflection
            dynamic responseObject = OkObjectResult.Value;
            var tokenProperty = responseObject.GetType().GetProperty("token");
            string encodedToken = tokenProperty.GetValue(responseObject, null);
            var userObjectProperty = responseObject.GetType().GetProperty("userObject");
            UserToReturnDto userObject = userObjectProperty.GetValue(responseObject, null);


            Assert.Equal(testUsername.ToLower(), userObject.Username);

                // decode verifyJWT
            var decodedToken = new JwtSecurityToken(encodedToken);
            var jwtUsername = decodedToken.Claims.First(claim => claim.Type == "unique_name").Value;
            Assert.Equal(testUsername.ToLower(), jwtUsername);

            //cleanup
            dbContext.Dispose();
        }
    }
}
