using ArsenalFans.Models;
using System.Text.Json;

namespace ArsenalFans.Services
{
    public class JsonPlayerService : IPlayerService
    {
        private readonly string _filePath;

        public JsonPlayerService(IWebHostEnvironment webHostEnvironment)
        {
            _filePath = Path.Combine(webHostEnvironment.WebRootPath, "data", "players.json");
        }

        public List<Player> GetPlayers()
        {
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Player>>(json) ?? new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            var players = GetPlayers();
            players.Add(player);
            SavePlayers(players);
        }

        public void UpdatePlayer(Player updatedPlayer)
        {
            var players = GetPlayers();
            var player = players.FirstOrDefault(p => p.Id == updatedPlayer.Id);
            if (player != null)
            {
                player.FirstName = updatedPlayer.FirstName;
                player.LastName = updatedPlayer.LastName;
                player.Age = updatedPlayer.Age;
                player.Position = updatedPlayer.Position;
                player.Nationality = updatedPlayer.Nationality;
                SavePlayers(players);
            }
        }

        public void DeletePlayer(int id)
        {
            var players = GetPlayers();
            var player = players.FirstOrDefault(p => p.Id == id);
            if (player != null)
            {
                players.Remove(player);
                SavePlayers(players);
            }
        }

        private void SavePlayers(List<Player> players)
        {
            var json = JsonSerializer.Serialize(players, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
