using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services;

namespace Tests.WebApi
{
    public class GameControllerTests
    {
        private IGameService _gameService;

        [SetUp]
        public void SetUp()
        {
            var mock = new Mock<IGameService>();

            // Mock fake data
            var games = MakeFakeGames();

            // Mock for get all games
            mock
                .Setup(s => s.Get())
                .Returns(Task.FromResult(games));

            // Mock for get simple game
            mock
                .Setup(s => s.Get(1))
                .Returns(Task.FromResult(games.FirstOrDefault()));

            // Mock for get all games by platform
            mock
                .Setup(s => s.GetByPlatform(1))
                .Returns(Task.FromResult(games.Where(g => g.PlatformId == 1).ToList()));

            // Mock for get all platforms
            mock
                .Setup(s => s.GetPlatforms())
                .Returns(Task.FromResult(games.Select(g => g.Platform).Distinct().ToList()));

            // Mock for get all developers
            mock
                .Setup(s => s.GetDevelopers())
                .Returns(Task.FromResult(games.Select(g => g.Platform.Developer).Distinct().ToList()));

            // Configure service as mock
            _gameService = mock.Object;
        }

        [Test]
        public void Get_SingleList_ReturnsList()
        {
            var actual = _gameService.Get();
            Assert.That(actual.Result, Is.Not.Null);
            Assert.That(actual.Result, Is.Not.Empty);
        }

        [Test]
        [TestCase(1)]
        public void Get_SingleGame_ReturnsGame(int gameId)
        {
            var actual = _gameService.Get(gameId);
            Assert.That(actual.Result, Is.Not.Null);
        }

        [Test]
        [TestCase(10)]
        public void Get_SingleGame_ReturnsNull(int gameId)
        {
            var actual = _gameService.Get(gameId);
            Assert.That(actual.Result, Is.Null);
        }

        [Test]
        [TestCase(1)]
        public void GetByPlatform_SinglePlatform_ReturnsList(int platformId)
        {
            var actual = _gameService.GetByPlatform(platformId);
            Assert.That(actual.Result, Is.Not.Null);
            Assert.That(actual.Result, Is.Not.Empty);
        }

        [Test]
        public void GetPlatforms_SingleList_ReturnsList()
        {
            var actual = _gameService.GetPlatforms();
            Assert.That(actual.Result, Is.Not.Null);
            Assert.That(actual.Result, Is.Not.Empty);
        }

        [Test]
        public void GetDevelopers_SingleList_ReturnsList()
        {
            var actual = _gameService.GetDevelopers();
            Assert.That(actual.Result, Is.Not.Null);
            Assert.That(actual.Result, Is.Not.Empty);
        }

        /// <summary>
        /// Make Fake games data
        /// CONFIGURE MANY DATA AND HANDLE BUSINESS LOGIC IN TESTS PROJECS IS A BAD PRACTICE!!!!!!!!!
        /// </summary>
        /// <returns>Fake games list</returns>
        private static List<Game> MakeFakeGames()
        {
            DateTime now = DateTime.Now;

            List<Developer> Developers = new()
            {
                new() { Id = 1, Name = "Nintendo" },
                new() { Id = 2, Name = "Sony" },
                new() { Id = 3, Name = "Microsoft" }
            };

            List<Platform> Platforms = new()
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

            return new()
            {
                new()
                {
                    Id = 1,
                    Title = "Fake game 1",
                    ReleaseDate = now,
                    PlatformId = 1,
                    Platform = Platforms.Where(d => d.Id == 1).FirstOrDefault(),
                },
                new()
                {
                    Id = 2,
                    Title = "Fake game 2",
                    ReleaseDate = now,
                    PlatformId = 2,
                    Platform = Platforms.Where(d => d.Id == 2).FirstOrDefault(),
                },
                new()
                {
                    Id = 3,
                    Title = "Fake game 3",
                    ReleaseDate = now,
                    PlatformId = 3,
                    Platform = Platforms.Where(d => d.Id == 3).FirstOrDefault(),
                },
            };
        }
    }
}
