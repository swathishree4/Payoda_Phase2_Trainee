using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apiproject.Model;
using Apiproject.Service;
using Microsoft.AspNetCore.Authorization;

namespace Apiproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GamesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            return await _context.Games.ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound(new { message = "Game not found. Please provide a valid ID." });
            }

            return game;
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
            if (id != game.GameId)
            {
                return BadRequest();
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {

                    return NotFound("Please provide a valid ID.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGame", new { id = game.GameId }, game);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound(new { message = "Please provide a valid ID." });
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.GameId == id);
        }

        // GET: api/Games/FilterByAttendance?minAttendance=1000&maxAttendance=5000
        [HttpGet("FilterByAttendance")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Game>>> FilterByAttendance(int minAttendance, int maxAttendance)
        {
            var games = await _context.Games
                .Where(g => g.Attendance >= minAttendance && g.Attendance <= maxAttendance)
                .Include(g => g.Player)
                .ToListAsync();

            if (games == null || !games.Any())
            {
                return NotFound("No games found with attendance within the specified range.");
            }

            return Ok(games);
        }

        // GET: api/Games/CountByAttendance?minAttendance=1000&maxAttendance=5000
        [HttpGet("CountByAttendance")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<int>> CountByAttendance(int minAttendance, int maxAttendance)
        {
            var count = await _context.Games
                .CountAsync(g => g.Attendance >= minAttendance && g.Attendance <= maxAttendance);

            return Ok(count);
        }

        // GET: api/Games/FilterPlayersByPerformance?minPoints=20&minAssists=5&minRebounds=7
        [HttpGet("FilterPlayersByPerformance")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Player>>> FilterPlayersByPerformance(int minPoints, int minAssists, int minRebounds)
        {
            var players = await _context.Players
                .Where(p => p.TotalPoints >= minPoints && p.TotalAssists >= minAssists && p.TotalRebounds >= minRebounds)
                .Include(p => p.Games)
                .ToListAsync();

            if (players == null || !players.Any())
            {
                return NotFound("No players found with the specified performance criteria.");
            }

            return Ok(players);
        }




    }
}
