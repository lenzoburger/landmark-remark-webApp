using System;
using System.Collections.Generic;
using System.Security.Claims;
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

    // MarkerNote API controller
    public class MarkerNoteController : ControllerBase
    {
        private readonly ILandmarkingRepository _repo;
        private readonly IMapper _mapper;
        public MarkerNoteController(ILandmarkingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        // GET all MarkerNotes
        [HttpGet]
        public async Task<IActionResult> GetMarkerNotes()
        {
            var markerNotes = await _repo.GetMarkerNotesAsync();
            var markerNotesToReturn = _mapper.Map<IEnumerable<MarkerNoteForReturnDto>>(markerNotes);

            return Ok(markerNotesToReturn);
        }

        // GET MarkerNote id
        [HttpGet("{id}", Name = "GetMarkerNote")]
        public async Task<IActionResult> GetMarkerNote(int id)
        {
            var markerNote = await _repo.GetMarkerNoteAsync(id);
            var markerNoteToReturn = _mapper.Map<MarkerNoteForReturnDto>(markerNote);

            return Ok(markerNoteToReturn);
        }

        // GET MarkerNote searchString: username Or Note content
        [HttpGet("search/{searchString}")]
        public async Task<IActionResult> GetMarkerNotes(string searchString)
        {
            var markerNotes = await _repo.GetMarkerNotesAsync(searchString);
            var markerNotesToReturn = _mapper.Map<IEnumerable<MarkerNoteForReturnDto>>(markerNotes);

            return Ok(markerNotesToReturn);
        }

        // Transforms/Maps recieved MarkerNote data, saves it, and returns newly created MarkerNote from repo.
        [HttpPost("create")]
        public async Task<IActionResult> CreateMarkerNote(MarkerNoteCreateDto markerNoteDto)
        {
            // Get JWT Claims
            var tokeUserName = User.FindFirst(ClaimTypes.Name).Value;
            var tokeUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            markerNoteDto.UserId = tokeUserId;
            var markerNoteToCreate = _mapper.Map<MarkerNote>(markerNoteDto);
            
            _repo.Add(markerNoteToCreate);

            if (await _repo.SaveAll())
            {   
                var markerToReturn = _mapper.Map<MarkerNoteForReturnDto>(markerNoteToCreate);
                markerToReturn.Username = tokeUserName;
                return CreatedAtRoute("GetMarkerNote", new { id = markerNoteToCreate.Id }, markerToReturn);
            }
            return BadRequest("Could not save the Marker Note");
        }
    }
}

// foreach (var marker in markerNoteOwner.UserMarkerNotes)
// {
//     if ((marker.Latitude == markerNoteDto.Latitude) && (marker.Longitude == markerNoteDto.Longitude))
//     {
//         var markerNoteRepo = await _repo.GetMarkerNoteAsync(marker.Id);
//         _mapper.Map(markerNoteDto, markerNoteRepo);

//         if (await _repo.SaveAll())
//         {
//             return NoContent();
//         }else {
//             throw new Exception($"Updating markerNote {markerNoteDto.Id} failed on save");
//         }
//     }
// }