using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyTopArtistsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyTopArtistsWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISpotifyAccountService _spotifyAccountService;
        private readonly IConfiguration _configuration;
        private readonly ISpotifyService _spotifyService;

        public HomeController(
            ISpotifyAccountService spotifyAccountService, IConfiguration configuration,
            ISpotifyService spotifyService)
        {
           _spotifyAccountService = spotifyAccountService;
            _configuration = configuration;
            _spotifyService = spotifyService;
        }

        public async Task<IActionResult> Index()
        {
            var topArtists = await GetTopArtists();
            return View(topArtists);
        }

        private async Task<IEnumerable<TopArtists>> GetTopArtists() 
        {
            try
            {
                var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);

                var topArtists = await _spotifyService.GetTopArtists(20, token);

                return topArtists;
             }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return Enumerable.Empty<TopArtists>();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
