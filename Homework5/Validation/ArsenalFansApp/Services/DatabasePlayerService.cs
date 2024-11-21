using ArsenalFansApp.Contracts;
using ArsenalFansDAL.Services;
using ArsenalFansModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArsenalFansWebApp.Services
{
    public class DatabasePlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;


        public DatabasePlayerService(ArsenalDbContext context)
        {
            var playerSet = context.Set<Player>();

            playerSet.Re
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