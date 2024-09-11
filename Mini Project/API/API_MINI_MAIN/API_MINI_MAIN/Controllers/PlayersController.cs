using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apiproject.Model;
using Microsoft.AspNetCore.Authorization;

namespace API_MINI_MAIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlayersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Players
        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        
        // GET: api/Players/5
        [HttpGet("{id}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound(new { message = "Player not found. Please provide a valid ID." });
            }

            return player;
        }


        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.PlayerId)
            {
                return NotFound("Player ID does not match the provided ID.");
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        // POST: api/Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer", new { id = player.PlayerId }, player);
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
               
                return NotFound(new { message = "Please provide a valid ID." });
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //filterbyperformance
        [HttpGet("FilterByPerformance")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Player>>> FilterByPerformance(
        [FromQuery] int minPoints = 0,
        [FromQuery] int minAssists = 0,
        [FromQuery] int minRebounds = 0)
        {
            var players = await _context.Players
                .Where(p => p.TotalPoints >= minPoints
                         && p.TotalAssists >= minAssists
                         && p.TotalRebounds >= minRebounds)
                .ToListAsync();

            if (players == null || !players.Any())
            {
                return NotFound("No players found with the specified performance criteria.");
            }

            return Ok(players);
        }

        //search
        [HttpGet("Search")]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<IEnumerable<Player>>> SearchPlayers(
          [FromQuery] string? name = null,
          [FromQuery] string? position = null)
        {
            var query = _context.Players.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(p => p.Name.ToLower().Contains(name.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(position))
            {
                query = query.Where(p => p.Position.ToLower() == position.ToLower());
            }

            var players = await query.ToListAsync();

            if (players == null || !players.Any())
            {
                return NotFound("No players found matching the search criteria.");
            }

            return Ok(players);
        }

        //Statistics
        [HttpGet("Statistics")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetPlayerStatistics()
        {
            var statistics = await _context.Players.GroupBy(p => 1)
                .Select(g => new
                {
                    TotalPlayers = g.Count(),
                    AveragePoints = g.Average(p => p.TotalPoints),
                    AverageAssists = g.Average(p => p.TotalAssists),
                    AverageRebounds = g.Average(p => p.TotalRebounds),
                })
                .FirstOrDefaultAsync();

            return Ok(statistics);
        }



        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.PlayerId == id);
        }
    }
}
