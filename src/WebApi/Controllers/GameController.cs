using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<List<Game>> Get()
        {
            return await _gameService.Get();
        }

        [HttpGet("{id}")]
        public async Task<Game> Get(int id)
        {
            return await _gameService.Get(id);
        }

        [Route("GetByPlatform")]
        [HttpGet]
        public async Task<List<Game>> GetByPlatform(int platformId)
        {
            return await _gameService.GetByPlatform(platformId);
        }

        [Route("GetPlatforms")]
        [HttpGet]
        public async Task<List<Platform>> GetPlatforms()
        {
            return await _gameService.GetPlatforms();
        }

        [Route("GetDevelopers")]
        [HttpGet]
        public async Task<List<Developer>> GetDevelopers()
        {
            return await _gameService.GetDevelopers();
        }
    }
}
