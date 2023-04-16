using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpotifyAPI.Web;
using GuessTheSong.Models;
using static SpotifyAPI.Web.PlaylistRemoveItemsRequest;
using System.Collections.Generic;

namespace GuessTheSong.Controllers
{
/*   [ApiController]
    [Route("api/songs")]*/
    public class GameController : Controller
    {



        private readonly IConfiguration _config;

        public GameController(IConfiguration config)
        {
            _config = config;
        }

        public List<SongModel> Index(string code)
        {
             Spotify spotifyHandler = new Spotify(code);
            
            spotifyHandler.playTrack(spotifyHandler.GenerateTracks("Top 100 most streamed songs on Spotify", 6)[0].uri);

            return spotifyHandler.GenerateTracks("Top 100 most streamed songs on Spotify", 6);

        }

    }
}
