using ArsenalFansModel.Entities;

namespace ArsenalFansCore.Contracts.Interfaces
{
    public interface IPlayerService : IService
    {
        Task<List<Player>> GetPlayersAsync();
        Task<Player> GetPlayerByIdAsync(int id);
        Task<Player> GetPlayerByNameAsync(string name);
        Task AddPlayerAsync(Player player);
        Task UpdatePlayerAsync(Player player);
        Task DeletePlayerAsync(int id);
    }
}