using MusixmatchClientLib.Auth;
using MusixmatchClientLib;
using Newtonsoft.Json;
using SpotifyAPI.Web;
using Razor.Utils.Components.Utils.Model;
using MusixmatchClientLib.API.Model.Types;

namespace Razor.Utils.Components.Utils
{
    internal class Spotify
    {
        string clientID = "CLIENT ID";
        string clientSecret ="CLIENT SECRET";

        List<SongModel> trackList = new List<SongModel> { };

        private string code;
        SpotifyClient spotify;

        public Spotify(string code)
        {
            this.code = code;


            this.spotify = AuthenticatedClient().Result;
        }
        private async Task<SpotifyClient> AuthenticatedClient()
        {
            string baseUrl = "https://localhost:7097/";
            var response = await new OAuthClient().RequestToken(new AuthorizationCodeTokenRequest(clientID, clientSecret, code, new Uri(baseUrl + "Song/Index"))); ;
            return new SpotifyClient(response.AccessToken);

        }

        public async Task<List<SongModel>> GenerateTracks(string playlistName, int numberOfTracks)
        {
            Random rnd = new Random();


            var playlist = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.Playlist, playlistName));
            var tracks = await spotify.Playlists.Get(playlist.Playlists.Items[0].Id);

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
                        uri = track.PreviewUrl,
                    });
                }
            }
            return trackList;
        }
        public string getLyrics()
        {
            List<Track> trackList = new List<Track>();


            MusixmatchToken token = new MusixmatchToken();
            MusixmatchClient mp = new MusixmatchClient(token);

            Console.WriteLine("testing, " + JsonConvert.SerializeObject(mp.SongSearch("Do I Wanna Know?")[0]));

            return "";

        }

        /*       public void playTrack(string trackUri)
                {
                    spotify.Player.ResumePlayback(new PlayerResumePlaybackRequest() { Uris = new List<string> { trackUri } });
                }*/

    }
}
