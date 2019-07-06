using AutoMapper;
using landmark_remark_API.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace landmark_remark_API.Tests
{
    public static class IMapperMocker
    {
        //Mock automapper
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
