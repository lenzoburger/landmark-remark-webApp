using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using landmark_remark_API.Dtos;
using landmark_remark_API.Models;
using landmark_remark_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace landmark_remark_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // Registration and authenticion api Controller 
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo; // To access Authetication db query methods
        private readonly IMapper _mapper; // To tranform/map request & response data into Model data
        private readonly IConfiguration _configuration; // To access AppSettings Configuration & secret key

        // Constructor to set Authentication repository, automapper and current IConfiguration
        public AuthController(IAuthRepository authRepo, IMapper mapper, IConfiguration configuration)
        {
            _configuration = configuration;
            _authRepo = authRepo;
            _mapper = mapper;
        }

        // Transforms/Maps recieved User data, saves it, and returns newly created user from db repo.
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

            return CreatedAtRoute("GetUser", new { controller = "Users", id = newUserInstance.Id }, userToReturnDto);
        }

        // Verifies user credentials and returns JWT Token
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var returnedUser = await _authRepo.LoginAsync(userLoginDto.Username.ToLower(), userLoginDto.Password);

            if (returnedUser == null)
            {
                return Unauthorized();
            }

            var securityTokenDescriptor = CreateSecurityTokenDescriptor(returnedUser);

            var securityTokenHandler = new JwtSecurityTokenHandler();

            var token = securityTokenHandler.CreateToken(securityTokenDescriptor);

            var userObject = _mapper.Map<UserToReturnDto>(returnedUser);

            await _authRepo.LoginAsync(userLoginDto.Username, userLoginDto.Password);

            return Ok(new
            {
                token = securityTokenHandler.WriteToken(token),
                userObject
            });
        }

        // generate new SecurityTokenDescriptor for securityTokenHandler
        private SecurityTokenDescriptor CreateSecurityTokenDescriptor(User loginUser)
        {
            //Set claim with username and id
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, loginUser.Id.ToString()),
                new Claim(ClaimTypes.Name, loginUser.Username)
            };

            //convert secret Key retrieved from AppSettings
            var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            //hash Secret key
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //Combine tokenSubject + expiryDate + Hashed secretKey
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            return tokenDescriptor;
        }

    }
}