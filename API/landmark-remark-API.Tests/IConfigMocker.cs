using AutoMapper;
using landmark_remark_API.Helpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace landmark_remark_API.Tests
{
    //Mock IConfiguration json data
    public static class IConfigMocker
    {
        //Mock IConfiguration
        public static IConfiguration getIconfiguration()
        {            
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            return configuration;
        }
    }
}
