using AutoMapper;
using landmark_remark_API.Dtos;
using landmark_remark_API.Models;

namespace landmark_remark_API.Helpers
{
    public class AutomoMapperConfigurations : Profile
    {
        public AutomoMapperConfigurations()
        {
            CreateMap<User, UserToReturnDto>();
            CreateMap<UserRegisterDto, User>();
        }
    }
}