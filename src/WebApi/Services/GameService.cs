using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IGameService
    {
        Task<List<Game>> Get();
        Task<Game> Get(int id);
        Task<List<Game>> GetByPlatform(int platformId);
        Task<List<Platform>> GetPlatforms();
        Task<List<Developer>> GetDevelopers();
    }

    public class GameService : IGameService
    {
        #region Fake data

        private readonly List<Developer> Developers;
        private readonly List<Platform> Platforms;
        private readonly List<Game> Games;

        #endregion

        public GameService()
        {
            // Populate fake database
            string dateTimeFormat = "yyyy-MM-dd";

            Developers = new()
            {
                new() { Id = 1, Name = "Nintendo" },
                new() { Id = 2, Name = "Sony" },
                new() { Id = 3, Name = "Microsoft" }
            };

            Platforms = new()
            {
                new()
                {
                    Id = 1,
                    Name = "Nintendo 3DS",
                    DeveloperId = 1,
                    Developer = Developers.Where(d => d.Id == 1).FirstOrDefault(),
                },
                new()
                {
                    Id = 2,
                    Name = "PlayStation",
                    DeveloperId = 2,
                    Developer = Developers.Where(d => d.Id == 2).FirstOrDefault(),
                },
                new()
                {
                    Id = 3,
                    Name = "Xbox Series X",
                    DeveloperId = 3,
                    Developer = Developers.Where(d => d.Id == 3).FirstOrDefault(),
                },
            };

            Games = new()
            {
                new()
                {
                    Id = 1,
                    Title = "Super Mario 3D Land",
                    ReleaseDate = DateTime.ParseExact("2011-11-03", dateTimeFormat, CultureInfo.InvariantCulture),
                    PlatformId = 1,
                    Platform = Platforms.Where(d => d.Id == 1).FirstOrDefault(),
                },
                new()
                {
                    Id = 2,
                    Title = "Metal Gear Solid 3: Snake Eater",
                    ReleaseDate = DateTime.ParseExact("2004-11-17", dateTimeFormat, CultureInfo.InvariantCulture),
                    PlatformId = 1,
                    Platform = Platforms.Where(d => d.Id == 1).FirstOrDefault(),
                },
                new()
                {
                    Id = 3,
                    Title = "Chrono Cross",
                    ReleaseDate = DateTime.ParseExact("1999-11-18", dateTimeFormat, CultureInfo.InvariantCulture),
                    PlatformId = 2,
                    Platform = Platforms.Where(d => d.Id == 2).FirstOrDefault(),
                },
                new()
                {
                    Id = 4,
                    Title = "Pink Panther: Pinkadelic Pursuit",
                    ReleaseDate = DateTime.ParseExact("2002-11-01", dateTimeFormat, CultureInfo.InvariantCulture),
                    PlatformId = 2,
                    Platform = Platforms.Where(d => d.Id == 2).FirstOrDefault(),
                },
                new()
                {
                    Id = 5,
                    Title = "Forza Horizon 5",
                    ReleaseDate = DateTime.ParseExact("2021-11-04", dateTimeFormat, CultureInfo.InvariantCulture),
                    PlatformId = 3,
                    Platform = Platforms.Where(d => d.Id == 3).FirstOrDefault(),
                },
                new()
                {
                    Id = 6,
                    Title = "Halo Infinite",
                    ReleaseDate = DateTime.ParseExact("2021-12-01", dateTimeFormat, CultureInfo.InvariantCulture),
                    PlatformId = 3,
                    Platform = Platforms.Where(d => d.Id == 3).FirstOrDefault(),
                },
            };
        }

        public async Task<List<Game>> Get()
        {
            await Task.Delay(1000);
            return Games;
        }

        public async Task<Game> Get(int id)
        {
            await Task.Delay(1000);
            return Games
                .Where(g => g.Id == id)
                .FirstOrDefault();
        }

        public async Task<List<Game>> GetByPlatform(int platformId)
        {
            await Task.Delay(1000);
            return Games
                .Where(g => g.PlatformId == platformId)
                .ToList();
        }

        public async Task<List<Platform>> GetPlatforms()
        {
            await Task.Delay(1000);
            return Platforms;
        }

        public async Task<List<Developer>> GetDevelopers()
        {
            await Task.Delay(1000);
            return Developers;
        }
    }
}
