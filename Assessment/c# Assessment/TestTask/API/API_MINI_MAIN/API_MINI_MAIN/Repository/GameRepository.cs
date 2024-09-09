using Apiproject.Interface;
using Apiproject.Model;
using Microsoft.EntityFrameworkCore;

namespace Apiproject.Repository
{
    public class GameRepository : IGame
    {
        private readonly AppDbContext _context;
        public GameRepository(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/Games
        //[HttpGet]
        public async Task<IEnumerable<Game>> GetGame()
        {
            return await _context.Games.Include(c => c.Player).ToListAsync();
        }
        public async Task<Game> GetGameById(int id)
        {
            return await _context.Games.FirstOrDefaultAsync(e => e.GameId == id);

        }

        public async Task PostGame(Game e)
        {
            await _context.Games.AddAsync(e);
            await _context.SaveChangesAsync();
        }

        public async Task PutGame(int id, Game e)
        {
            if (id == e.GameId)
            {
                _context.Entry(e).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteGame(int id)
        {
            var g = await _context.Games.FindAsync(id);
            if (g != null)
            {
                _context.Games.Remove(g);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Game>> GetGamesByAttendance(int minAttendance, int maxAttendance)
        {
            return await _context.Games.Where(g => g.Attendance >= minAttendance && g.Attendance <= maxAttendance).ToListAsync();
        }

        public async Task<int> CountGamesByAttendance(int minAttendance, int maxAttendance)
        {
            return await _context.Games.CountAsync(g => g.Attendance >= minAttendance && g.Attendance <= maxAttendance);
        }

        public async Task<IEnumerable<Player>> GetPlayersByPerformance(int minPoints, int minAssists, int minRebounds)
        {
            return await _context.Players.Where(p => p.TotalPoints >= minPoints && p.TotalAssists >= minAssists && p.TotalRebounds >= minRebounds).ToListAsync();
        }

    }
}
