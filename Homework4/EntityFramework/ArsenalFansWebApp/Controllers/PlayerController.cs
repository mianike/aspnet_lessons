using ArsenalFansCore.Contracts.Interfaces;
using ArsenalFansModel.Dto;
using ArsenalFansWebApp.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArsenalFansWebApp.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayerController(IPlayerService playerService, IMapper mapper)
        {
            _playerService = playerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var playerDtos = await _playerService.GetPlayerDtosAsync();

            var playerViewModels = _mapper.Map<List<PlayerViewModel>>(playerDtos);

            return View(playerViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlayerViewModel playerView)
        {
            if (ModelState.IsValid)
            {
                var playerDto = _mapper.Map<PlayerDto>(playerView);

                await _playerService.AddPlayerAsync(playerDto);

                return RedirectToAction(nameof(Index));
            }

            return View(playerView);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var playerDto = await _playerService.GetPlayerDtoByIdAsync(id);

            var playerViewModel = _mapper.Map<PlayerViewModel>(playerDto);

            return View(playerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PlayerViewModel playerView)
        {
            if (ModelState.IsValid)
            {
                var playerDto = _mapper.Map<PlayerDto>(playerView);

                await _playerService.UpdatePlayerAsync(playerDto);

                return RedirectToAction(nameof(Index));
            }

            return View(playerView);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var playerDto = await _playerService.GetPlayerDtoByIdAsync(id);

            var playerViewModel = _mapper.Map<PlayerViewModel>(playerDto);

            return View(playerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await _playerService.DeletePlayerAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
