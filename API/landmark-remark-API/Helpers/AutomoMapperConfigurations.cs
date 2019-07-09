using AutoMapper;
using landmark_remark_API.Dtos;
using landmark_remark_API.Models;

namespace landmark_remark_API.Helpers
{
    // AutoMapper Profile Configuration
    public class AutomoMapperConfigurations : Profile
    {
        // Configure AutoMapper profiles
        public AutomoMapperConfigurations()
        {
            CreateMap<User, UserToReturnDto>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<MarkerNote, MarkerNoteForReturnDto>().ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username) );
            CreateMap<MarkerNoteCreateDto, MarkerNote>();
        }
    }
}