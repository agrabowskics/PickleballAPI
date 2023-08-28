using BlazorWebAssembely.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorWebAssembely.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly PlayersContext _context;

        private int CalculateAge(Player player)
        {
            var today = DateTime.Now;
            var age = today.Year - player.Birthday.Year;

            if (today.Month < player.Birthday.Month
                || ((today.Month == player.Birthday.Month) && (today.Day < player.Birthday.Day)))
            {
                age--;
            }

            return age;
        }

        public PlayersController(PlayersContext context) 
        { 
            _context = context;
        }

        [HttpGet("Players/{page}")]
        public async Task<ActionResult<PlayerResponseDto>> GetAllPlayers(int page = 0)
        {
            var pageResults = 25f;
            var pageCount = (int) Math.Ceiling(_context.Players.Count() / pageResults);

            var players = await _context.Players
                .Skip(page)
                .Take(25)
                .ToListAsync();

            var response = new PlayerResponseDto()
            {
                Players = players,
                Pages = pageCount,
                CurrentPage = page
            };

            return Ok(response);
        }

        [HttpGet("Player/{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == id);

            return player == null ? NotFound("Could not find player") : Ok(player);
        }

        [HttpGet("Search/Age/{age1}/{age2}/{page}")]
        public async Task<ActionResult<PlayerResponseDto>> GetAllPlayersAtAge(int age1, int age2, int page)
        {
            var pageResults = 25f;
            var pageCount = (int)Math.Ceiling(_context.Players.Count() / pageResults);
            
            var result = GetAgeRange(age1, age2);
            var players = await result
                .Skip(page)
                .Take(25)
                .ToListAsync();

            var response = new PlayerResponseDto()
            {
                Players = players,
                Pages = pageCount,
                CurrentPage = page
            };

            return Ok(response);
        }

        private IQueryable<Player> GetAgeRange(int start, int end)
        {
            var today = DateTime.Now;

            // Lazy calculation for testing
            var val = _context.Players.Where (player => (today.Year - player.Birthday.Year - 1) + (((today.Month > player.Birthday.Month)
                || ((today.Month == player.Birthday.Month) && (today.Day >= player.Birthday.Day))) ? 1 : 0) >= start
            && (today.Year - player.Birthday.Year - 1) + (((today.Month > player.Birthday.Month)
                || ((today.Month == player.Birthday.Month) && (today.Day >= player.Birthday.Day))) ? 1 : 0) <= end);

            return val;
        }
    }
}
