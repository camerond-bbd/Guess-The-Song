using DatabaseHandler;
using SongGame.Models;


namespace GuessTheSong.Utils
{
    public class ModelLoader
    {
       
       private Artists artist;
       private Genres genre;
       private Lyrics lyrics;
       private Players player;
       private Scores score;
       private Songs song;

       public Artists getArtist(String id){
        Dictionary<string, string> result = new Dictionary<string, string>();
        String query = "SELECT [name] FROM artists WHERE artist_id = " + id;
        result = DatabaseHandler.execute(query);
        Artists artist = new Artist(result.name);
        return artist;
       }

       public Genres getGenre(String id){
            Dictionary<string, string> result = new Dictionary<string, string>();
            String query = "SELECT name FROM artists WHERE artist_id = " + id;
            result = DatabaseHandler.execute(query);
            Genres genres = new Genres(result.name);
            return genres;
       }

        public Lyrics getLyrics(String id)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            String query = "SELECT lyric_text FROM lyrics WHERE lyric_id = " + id;
            result = DatabaseHandler.execute(query);
            Lyrics lyrics = new Lyrics(result.name);
            return lyrics;
        }

        public Players getPlayers(String id)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            String query = "SELECT username FROM players WHERE player_id = " + id;
            result = DatabaseHandler.execute(query);
            Players players = new Players(result.username, result.playerPassword);
            return players;
        }

        public Scores getScore(String id)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            String query = "SELECT player_score FROM scores WHERE player_id = " + id;
            result = DatabaseHandler.execute(query);
            Scores scores = new Scores(result.playerScore);
            return scores;
        }

        public Songs getSongs(String id)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            String query = "SELECT title, artist_id, genre_id FROM songs WHERE song_id = " + id;
            result = DatabaseHandler.execute(query);
            Songs song = new Songs(result.songTitle, result.artistId, result.genreId);
            return song;
        }
    }
}
