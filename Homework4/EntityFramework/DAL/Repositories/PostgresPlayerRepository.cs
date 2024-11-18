using ArsenalFans.DAL.Data;
using ArsenalFans.DAL.Repositories.Contracts;
using ArsenalFans.Models;
using Microsoft.EntityFrameworkCore;

namespace ArsenalFans.DAL.Repositories
{
    public class PostgresPlayerRepository : IPlayerRepository
    {
        private readonly ArsenalDbContext _context;

        public PostgresPlayerRepository(ArsenalDbContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> GetPlayersAsync()
        {
            return await _context.Players.ToListAsync();
        }
        public async Task<Player> GetPlayerByIdAsync(int id)
        {
            return await _context.Players.FindAsync(id);
        }

        public async Task AddPlayerAsync(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlayerAsync(Player player)
        {
            _context.Players.Update(player);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlayerAsync(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player != null)
            {
                _context.Players.Remove(player);
                await _context.SaveChangesAsync();
            }
        }
    }
}