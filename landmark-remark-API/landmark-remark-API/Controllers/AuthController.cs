using System;
using System.Threading.Tasks;
using AutoMapper;
using landmark_remark_API.Dtos;
using landmark_remark_API.Models;
using landmark_remark_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace landmark_remark_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepository authRepo, IMapper mapper)
        {
            _authRepo = authRepo;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto UserDto)
        {
            UserDto.Username = UserDto.Username.ToLower();
            UserDto.Email = UserDto.Email.ToLower();

            if (await _authRepo.UsernameExistsAsync(UserDto.Username))
            {
                return BadRequest("This username is not available");
            }

            if (await _authRepo.EmailExistsAsync(UserDto.Email))
            {
                return BadRequest("This email is already in use");
            }

            var newUserModel = _mapper.Map<User>(UserDto);

            var newUserInstance = await _authRepo.RegisterAsync(newUserModel, UserDto.Password);

            var userToReturnDto = _mapper.Map<UserToReturnDto>(newUserInstance);

            return CreatedAtRoute("GetUser", new {controller = "Users", id = newUserInstance.Id}, userToReturnDto);
        }

        public Task<OkObjectResult> GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            await _authRepo.Login(userLoginDto.Username, userLoginDto.Password);
            return Ok("2.0");
        }

    }
}