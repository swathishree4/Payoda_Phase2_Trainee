using Apiproject.Model;

namespace Apiproject.Interface
{
    public interface IGame
    {
        Task<IEnumerable<Game>> GetGame();
        Task<Game> GetGameById(int GameId);
        Task PostGame(Game game);
        Task PutGame(int GameId, Game game);
        Task DeleteGame(int GameId);

        Task<IEnumerable<Game>> GetGamesByAttendance(int minAttendance, int maxAttendance);
        Task<int> CountGamesByAttendance(int minAttendance, int maxAttendance);
        Task<IEnumerable<Player>> GetPlayersByPerformance(int minPoints, int minAssists, int minRebounds);
    }
}
