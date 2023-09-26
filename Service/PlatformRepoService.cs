using System;
using System.Collections.Generic;
using System.Linq;
using PlatformService.DataLayer;
using PlatformService.Models;
using PlatformService.Repository;

namespace PlatformService.Service
{
    public class PlatformRepoService : IPlatformRepo
    {
        private readonly AppDbContext _dbContext;

        public PlatformRepoService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreatePlatform(Platform platform)
        {
            if(platform == null)
                throw new ArgumentNullException(nameof(platform));

            _dbContext.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _dbContext.Platforms.ToList();
        }

        public Platform GetPlatformByID(int id)
        {
            return _dbContext.Platforms.FirstOrDefault(platform => platform.Id == id);
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() >= 1;
        }
    }
}