using ArsenalFans.Services;
using ArsenalFans.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArsenalFans.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        private readonly List<Player> _players;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;

            _players = _playerService.GetPlayers();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_players);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                player.Id = _players.Max(p => p.Id) + 1;
                _playerService.AddPlayer(player);

                return RedirectToAction(nameof(Index));
            }

            return View(player);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var player = _players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        [HttpPost]
        public IActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                _playerService.UpdatePlayer(player);
                return RedirectToAction(nameof(Index));
            }

            return View(player);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var existingPlayer = _players.FirstOrDefault(p => p.Id == id);
            if (existingPlayer == null)
            {
                return NotFound();
            }

            return View(existingPlayer);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var existingPlayerIndex = _players.FindIndex(p => p.Id == id);
            if (existingPlayerIndex == -1)
            {
                return NotFound();
            }

            _players.RemoveAt(existingPlayerIndex);
            _playerService.DeletePlayer(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
