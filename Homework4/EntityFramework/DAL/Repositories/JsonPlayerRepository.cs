using System.Text.Json;
using ArsenalFans.DAL.Repositories.Contracts;
using ArsenalFans.Models;

namespace ArsenalFans.DAL.Repositories
{
    public class JsonPlayerRepository : IPlayerRepository
    {
        private readonly string _filePath;

        public JsonPlayerRepository(IConfiguration configuration)
        {
            _filePath = configuration["JsonFilePath"];
        }

        public async Task<List<Player>> GetPlayersAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Player>();
            }

            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Player>>(json) ?? new List<Player>();
        }

        public async Task<Player> GetPlayerByIdAsync(int id)
        {
            var players = await GetPlayersAsync();
            return players.FirstOrDefault(p => p.Id == id);
        }

        public async Task AddPlayerAsync(Player player)
        {
            var players = await GetPlayersAsync();
            players.Add(player);
            await SavePlayersAsync(players);
        }

        public async Task UpdatePlayerAsync(Player player)
        {
            var players = await GetPlayersAsync();
            var existingPlayer = players.FirstOrDefault(p => p.Id == player.Id);
            if (existingPlayer != null)
            {
                existingPlayer.FirstName = player.FirstName;
                existingPlayer.LastName = player.LastName;
                existingPlayer.Age = player.Age;
                existingPlayer.Position = player.Position;
                existingPlayer.Nationality = player.Nationality;
                await SavePlayersAsync(players);
            }
        }

        public async Task DeletePlayerAsync(int id)
        {
            var players = await GetPlayersAsync();
            var player = players.FirstOrDefault(p => p.Id == id);
            if (player != null)
            {
                players.Remove(player);
                await SavePlayersAsync(players);
            }
        }

        private async Task SavePlayersAsync(List<Player> players)
        {
            var json = JsonSerializer.Serialize(players, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}