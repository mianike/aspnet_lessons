using ArsenalFansWebApp.Models;

namespace ArsenalFansApp.Contracts
{
    public interface IPlayerService
    {
        Task<List<Player>> GetPlayersAsync();
        Task<Player> GetPlayerByIdAsync(int id);
        Task AddPlayerAsync(Player player);
        Task UpdatePlayerAsync(Player updatedPlayer);
        Task DeletePlayerAsync(int id);
    }
}