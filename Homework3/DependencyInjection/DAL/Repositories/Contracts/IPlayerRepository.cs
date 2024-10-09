using ArsenalFans.Models;

namespace ArsenalFans.DAL.Repositories.Contracts;

public interface IPlayerRepository
{
    Task<List<Player>> GetPlayersAsync();
    Task<Player> GetPlayerByIdAsync(int id);
    Task AddPlayerAsync(Player player);
    Task UpdatePlayerAsync(Player player);
    Task DeletePlayerAsync(int id);
}