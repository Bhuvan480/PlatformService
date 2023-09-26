using System.Collections;
using System.Collections.Generic;
using PlatformService.Models;

namespace PlatformService.Repository
{
    public interface IPlatformRepo
    {
        bool SaveChanges();
        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformByID(int id);
        void CreatePlatform(Platform platform);
    }
}