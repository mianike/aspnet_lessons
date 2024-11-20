using ArsenalFansCore.Contracts.Interfaces;
using ArsenalFansDAL.Contracts.Interfaces;
using ArsenalFansModel.Dto;
using ArsenalFansModel.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ArsenalFansCore.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlayerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private async Task<Player> GetPlayerByIdAsync(int id)
        {
            var playerRepository = _unitOfWork.GetRepository<Player>();

            var player = await playerRepository
                .AsReadOnlyQueryable()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (player == null)
            {
                throw new KeyNotFoundException($"Player with id {id} not found");
            }

            return player;
        }

        public async Task<IEnumerable<PlayerDto>> GetPlayerDtosAsync()
        {
            var playerRepository = _unitOfWork.GetRepository<Player>();

            var players = await playerRepository
                .AsReadOnlyQueryable()
                .ToListAsync();

            var playerDtos = _mapper.Map<IEnumerable<PlayerDto>>(players);

            return playerDtos;
        }

        public async Task<PlayerDto> GetPlayerDtoByIdAsync(int id)
        {
            var player = await GetPlayerByIdAsync(id);

            var playerDto = _mapper.Map<PlayerDto>(player);

            return playerDto;
        }

        public async Task AddPlayerAsync(PlayerDto playerDto)
        {
            var player = _mapper.Map<Player>(playerDto);
            player.LastUpdatedUtc = DateTime.UtcNow;

            var playerRepository = _unitOfWork.GetRepository<Player>();
            playerRepository.Create(player);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdatePlayerAsync(PlayerDto playerDto)
        {
            var player = await GetPlayerByIdAsync(playerDto.Id);

            _mapper.Map(playerDto, player);
            player.LastUpdatedUtc = DateTime.UtcNow;

            var playerRepository = _unitOfWork.GetRepository<Player>();
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