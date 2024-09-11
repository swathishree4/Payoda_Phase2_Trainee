using Apiproject.Interface;
using Apiproject.Model;

namespace Apiproject.Service
{
    public class GameService
    {
        private readonly IGame _gmrepo;
        public GameService(IGame gmrepo)
        {
            _gmrepo = gmrepo;
        }
        public async Task<IEnumerable<Game>> GetallGm()
        {
            return await _gmrepo.GetGame();
        }

        public async Task<Game> Getgmbyid(int id)
        {
            return await _gmrepo.GetGameById(id);
        }

        public async Task postgm(Game e)
        {
            await _gmrepo.PostGame(e);
        }

        public async Task putgm(int id, Game e)
        {
            await _gmrepo.PutGame(id, e);
        }

        public async Task Deletegm(int id)
        {
            await _gmrepo.DeleteGame(id);
        }

        public async Task<IEnumerable<Game>> GetGamesByAttendance(int minAttendance, int maxAttendance)
        {
            return await _gmrepo.GetGamesByAttendance(minAttendance, maxAttendance);
        }

        public async Task<int> CountGamesByAttendance(int minAttendance, int maxAttendance)
        {
            return await _gmrepo.CountGamesByAttendance(minAttendance, maxAttendance);
        }

        public async Task<IEnumerable<Player>> GetPlayersByPerformance(int minPoints, int minAssists, int minRebounds)
        {
            return await _gmrepo.GetPlayersByPerformance(minPoints, minAssists, minRebounds);
        }
    }
}
