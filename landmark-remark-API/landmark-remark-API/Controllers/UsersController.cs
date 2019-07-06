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
    //[Authorize]

    public class UsersController : ControllerBase
    {

        private readonly ILandmarkingRepository _landmarkingRepo;
        private readonly IMapper _mapper;
        public UsersController(ILandmarkingRepository landmarkingRepo, IMapper mapper)
        {
            _landmarkingRepo = landmarkingRepo;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _landmarkingRepo.GetUserAsync(id);

            var userToReturn = _mapper.Map<User, UserToReturnDto>(user);

            return Ok(userToReturn);
        }
    }
}