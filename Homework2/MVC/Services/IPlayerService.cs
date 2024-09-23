using ArsenalFans.Models;
using System.Text.Json;

namespace ArsenalFans.Services
{
    public interface IPlayerService
    {
        public List<Player> GetPlayers();

        public void AddPlayer(Player player);

        public void UpdatePlayer(Player updatedPlayer);

        public void DeletePlayer(int id);
    }
}
