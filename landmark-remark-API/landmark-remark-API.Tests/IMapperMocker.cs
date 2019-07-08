using AutoMapper;
using landmark_remark_API.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace landmark_remark_API.Tests
{
    //Returns Mock automapper
    public static class IMapperMocker
    {
        //Returns Mock automapper configured with the landmark_remark_API automapper profile
        public static IMapper getMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutomoMapperConfigurations());
            });

            return config.CreateMapper();
        }
    }
}
