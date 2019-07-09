using System.Threading.Tasks;
using AutoMapper;
using landmark_remark_API.Dtos;
using landmark_remark_API.Models;
using landmark_remark_API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace landmark_remark_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    // User Data api Controller 
    public class UsersController : ControllerBase
    {

        private readonly ILandmarkingRepository _landmarkingRepo; // To access User and db query methods
        private readonly IMapper _mapper; // To tranform/map request & response data into Model data

        // Constructor to set Landmarking repository, automapper
        public UsersController(ILandmarkingRepository landmarkingRepo, IMapper mapper)
        {
            _landmarkingRepo = landmarkingRepo;
            _mapper = mapper;
        }

        // Get User by id and return tranformed into UserToReturnDto
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _landmarkingRepo.GetUserAsync(id);

            var userToReturn = _mapper.Map<User, UserToReturnDto>(user);

            return Ok(userToReturn);
        }
    }
}