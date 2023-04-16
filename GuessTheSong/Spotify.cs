
using SpotifyAPI.Web;
using SpotifyAPI.Web.Http;
using System.Text.Json;
using GuessTheSong.Models;

namespace GuessTheSong.Controllers
{
    public class Spotify
    {
string clientID = "db03438a98c64224a6e4861ebf1b226e";
        string clientSecret = "1d8cf167057247e39623a1ee4b1863a0";

        List<SongModel> trackList = new List<SongModel> { };

        string code;

         SpotifyClient spotify;

        public Spotify(string code)
        {
            this.code= code;
            this.spotify = getToken().Result;
        }
        private async Task<SpotifyClient> getToken()
        {
            var response = await new OAuthClient().RequestToken(new AuthorizationCodeTokenRequest(clientID,clientSecret, code, new Uri("https://localhost:7041/Game"))
);

             spotify = new SpotifyClient(response.AccessToken);
  /*          if (response.IsExpired)
            {
                Console.WriteLine("dieieii");
            var newResponse = await new OAuthClient().RequestToken(
    new AuthorizationCodeRefreshRequest(clientID, clientSecret, response.RefreshToken)
  );;
           

            }*/

            return spotify;
        }


        public List<SongModel> GenerateTracks(string playlistName, int numberOfTracks)
        {
            Random rnd = new Random();

            var playlist = spotify.Search.Item(new SearchRequest(SearchRequest.Types.Playlist, playlistName)).Result;
            var tracks = spotify.Playlists.Get(playlist.Playlists.Items[0].Id).Result;
  
            for (int i = 0; i <= numberOfTracks - 1; i++)
            {
                int selector = rnd.Next(tracks.Tracks.Items.Count);
                if (tracks.Tracks.Items[selector].Track is FullTrack)
                {
                    FullTrack track = (FullTrack)tracks.Tracks.Items[selector].Track; 

                    trackList.Add(new SongModel
                    {
                        name = track.Name,
                        genre = "",
                        artist = track.Artists[0].Name,
                        uri = track.Uri
                    });
                }
            }

            return trackList;
        }

       public void playTrack(string trackUri)
        {
            spotify.Player.ResumePlayback(new PlayerResumePlaybackRequest() { Uris = new List<string> { trackUri } });
        }
    }
}
