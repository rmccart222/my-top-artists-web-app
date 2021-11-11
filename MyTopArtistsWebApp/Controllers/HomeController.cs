using Microsoft.AspNetCore.Mvc;
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

        public HomeController(ISpotifyAccountService spotifyAccountService)
        {
           _spotifyAccountService = spotifyAccountService;
        }

        public IActionResult Index()
        {
            try 
            { 
                var token = _spotifyAccountService.GetToken()
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }

            return View();
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
