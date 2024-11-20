using ArsenalFansModel.Dto;

namespace ArsenalFansCore.Contracts.Interfaces
{
    public interface IPlayerService : IService
    {
        Task<IEnumerable<PlayerDto>> GetPlayerDtosAsync();
        Task<PlayerDto> GetPlayerDtoByIdAsync(int id);
        Task AddPlayerAsync(PlayerDto player);
        Task UpdatePlayerAsync(PlayerDto player);
        Task DeletePlayerAsync(int id);
    }
}