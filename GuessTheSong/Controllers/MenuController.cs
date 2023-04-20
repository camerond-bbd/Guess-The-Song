using GuessTheSong.Models;
using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;
using System.Diagnostics;

namespace GuessTheSong.Controllers
{
    public class MenuController : Controller
    {
        private readonly ILogger<MenuController> _logger;
        public MenuController(ILogger<MenuController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            var loginRequest = new LoginRequest(new Uri("https://localhost:7041/Game"),
                "db03438a98c64224a6e4861ebf1b226e", LoginRequest.ResponseType.Code)
            {
                Scope = new[] { Scopes.UserReadCurrentlyPlaying, Scopes.Streaming, Scopes.UserReadPlaybackState }
            };
            var uri = loginRequest.ToUri();
            Console.WriteLine(loginRequest.ToUri());
            return Redirect(uri.ToString());
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