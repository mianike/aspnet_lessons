using ArsenalFansCore.Contracts.Interfaces;
using ArsenalFansDAL.Contracts.Interfaces;
using ArsenalFansModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArsenalFansCore.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Player>> GetPlayersAsync()
        {
            var playerRepository = _unitOfWork.GetRepository<Player>();

            var players = await playerRepository
                .AsReadOnlyQueryable()
                .ToListAsync();

            return players;
        }

        public async Task<Player> GetPlayerByIdAsync(int id)
        {
            var playerRepository = _unitOfWork.GetRepository<Player>();

            var player = await playerRepository
                .AsReadOnlyQueryable()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (player == null)
            {
                throw new KeyNotFoundException("Player not found");
            }

            return player;
        }

        public async Task<Player> GetPlayerByNameAsync(string name)
        {
            var playerRepository = _unitOfWork.GetRepository<Player>();

            var player = await playerRepository
                .AsReadOnlyQueryable()
                .FirstOrDefaultAsync(
                    p => string.Equals(p.FirstName, name, StringComparison.OrdinalIgnoreCase)
                    || string.Equals(p.LastName, name, StringComparison.OrdinalIgnoreCase));

            if (player == null)
            {
                throw new KeyNotFoundException("Player not found");
            }

            return player;
        }

        public async Task AddPlayerAsync(Player player)
        {
            var playerRepository = _unitOfWork.GetRepository<Player>();

            player.LastUpdatedUtc = DateTime.UtcNow;
            playerRepository.Create(player);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdatePlayerAsync(Player player)
        {
            var playerRepository = _unitOfWork.GetRepository<Player>();

            player.LastUpdatedUtc = DateTime.UtcNow;
            playerRepository.Update(player);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeletePlayerAsync(int id)
        {

            var player = await GetPlayerByIdAsync(id);

            var playerRepository = _unitOfWork.GetRepository<Player>();
            playerRepository.Delete(player);

            await _unitOfWork.SaveChangesAsync();

        }
    }
}