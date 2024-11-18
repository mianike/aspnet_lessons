using ArsenalFans.Services.Contracts;
using ArsenalFans.Models;
using ArsenalFans.DAL.Repositories.Contracts;

namespace ArsenalFans.Services
{
    public class PostgresPlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PostgresPlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<List<Player>> GetPlayersAsync()
        {
            return await _playerRepository.GetPlayersAsync();
        }

        public async Task<Player> GetPlayerByIdAsync(int id)
        {
            return await _playerRepository.GetPlayerByIdAsync(id);
        }

        public async Task AddPlayerAsync(Player player)
        {
            if (string.IsNullOrWhiteSpace(player.FirstName) || string.IsNullOrWhiteSpace(player.LastName))
            {
                throw new ArgumentException("Player's first and last name is required");
            }

            await _playerRepository.AddPlayerAsync(player);
        }

        public async Task UpdatePlayerAsync(Player updatedPlayer)
        {
            if (string.IsNullOrWhiteSpace(updatedPlayer.FirstName) || string.IsNullOrWhiteSpace(updatedPlayer.LastName))
            {
                throw new ArgumentException("Player's first and last name is required");
            }

            await _playerRepository.UpdatePlayerAsync(updatedPlayer);
        }

        public async Task DeletePlayerAsync(int id)
        {
            await _playerRepository.DeletePlayerAsync(id);
        }
    }
}