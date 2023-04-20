using DatabaseHandler;
using SongGame.Models;


namespace GuessTheSong.Utils
{
    public class ModelLoader
    {
       public Artists getArtist(string id){
        Dictionary<string, string> result = new Dictionary<string, string>();
        string query = "SELECT [name] FROM artists WHERE artist_id = " + id;
        result = DatabaseHandler.execute(query);
        Artists artist = new Artists(result.name);
        return artist;
       }

       public Genres getGenre(string id){
            Dictionary<string, string> result = new Dictionary<string, string>();
            string query = "SELECT name FROM genres WHERE genre_id = " + id;
            result = DatabaseHandler.execute(query);
            Genres genres = new Genres(result.name);
            return genres;
       }

        public Lyrics getLyrics(string id)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            string query = "SELECT lyric_text FROM lyrics WHERE lyric_id = " + id;
            result = DatabaseHandler.execute(query);
            Lyrics lyrics = new Lyrics(result.name);
            return lyrics;
        }

        public Players getPlayers(string id)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            string query = "SELECT username FROM players WHERE player_id = " + id;
            result = DatabaseHandler.execute(query);
            Players players = new Players(result.username, result.playerPassword);
            return players;
        }

        public Scores getScore(string id)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            string query = "SELECT player_score FROM scores WHERE player_id = " + id;
            result = DatabaseHandler.execute(query);
            Scores scores = new Scores(result.playerScore);
            return scores;
        }

        public Songs getSongs(string id)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            string query = "SELECT title, artist_id, genre_id FROM songs WHERE song_id = " + id;
            result = DatabaseHandler.execute(query);
            Songs song = new Songs(result.songTitle, result.artistId, result.genreId);
            return song;
        }
    }
}
