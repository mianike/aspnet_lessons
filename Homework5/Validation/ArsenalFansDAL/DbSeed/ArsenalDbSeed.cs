using ArsenalFansModel.Entities;
using System.Text.Json;
using ArsenalFansDAL.Contexts;

namespace ArsenalFansDAL.DbSeed
{
    public class ArsenalDbSeed
    {
        public static async Task PlayerSeed(ArsenalDbContext dbContext)
        {
            var playerSet = dbContext.Set<Player>();

            if (!playerSet.Any())
            {
                await using var fileStream = File.OpenRead("wwwroot/data/players.json");
                var players = await JsonSerializer.DeserializeAsync<List<Player>>(fileStream);

                await playerSet.AddRangeAsync(players!);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}