using landmark_remark_API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace landmark_remark_API.Tests
{
    public static class DbContextMocker
    {
        public static LandmarkingContext GetLandmarkingContext(string dbName, bool seedData = true)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<LandmarkingContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new LandmarkingContext(options);

            // Add users in memory
            if (seedData)
            {
                dbContext.Seed();
            }           

            return dbContext;
        }
    }
}
