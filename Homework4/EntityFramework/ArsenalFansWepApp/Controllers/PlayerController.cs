﻿using ArsenalFansCore.Contracts.Interfaces;
using ArsenalFansModel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ArsenalFansWepApp.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var players = await _playerService.GetPlayersAsync();
            
            return View(players);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Player player)
        {
            if (ModelState.IsValid)
            {
                await _playerService.AddPlayerAsync(player);
                
                return RedirectToAction(nameof(Index));
            }

            return View(player);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var player = await _playerService.GetPlayerByIdAsync(id);

            return View(player);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                await _playerService.UpdatePlayerAsync(player);
                
                return RedirectToAction(nameof(Index));
            }

            return View(player);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var player = await _playerService.GetPlayerByIdAsync(id);

            return View(player);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await _playerService.DeletePlayerAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}