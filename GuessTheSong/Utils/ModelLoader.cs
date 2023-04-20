using SongGame.Models;

namespace GuessTheSong.Utils
{
    public class ModelLoader
    {
        public Artists getArtist(int id)
        {
            string query = "SELECT [name] FROM artists WHERE artist_id = " + id;
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(new string[] { "name" }, query);
            //Artists artist = new Artists((string)result["name"],id);
            Artists artists = new Artists();
            artists.artist_id = id;
            artists.name = (string)result["name"];
            return artists;
        }

        public Genres getGenre(string id)
        {
            string query = "SELECT name FROM genres WHERE genre_id = " + id;
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(new string[] { "name" }, query);
            Genres genre = new Genres((string)result["name"]);
            return genre;
        }

        public Lyrics getLyrics(string id)
        {
            string query = "SELECT lyric_text FROM lyrics WHERE lyric_id = " + id;
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(new string[] { "lyric_text" }, query);
            Lyrics lyrics = new Lyrics((string)result["lyric_text"]);
            return lyrics;
        }

        public Players getPlayers(string id)
        {
            string query = "SELECT username FROM players WHERE player_id = " + id;
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(new string[] { "username" }, query);
            Players players = new Players((string) result["username"]);
            return players;
        }

        public Scores getScore(string id)
        {
            string query = $"SELECT COUNT(player_score) AS tot_player_score  FROM scores WHERE player_id = {id}";
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(new string[] {"tot_player_score"}, query);
           // Scores scores = new Scores(result[""]);
            return scores;
        }

        public Songs getSongs(string id)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            string query = "SELECT title, artist_id, genre_id FROM songs WHERE song_id = " + id;
            result = DatabaseConnectionManager.execute(query);
            Songs song = new Songs(result.songTitle, result.artistId, result.genreId);
            return song;
        }

        public void addScore(bool wonRound, int player_id)
        {
            if (wonRound)
            {
                query = "INSERT INTO scores(player_score) VALUES(1)";
            }
            else
            {
                query = "INSERT INTO scores(player_score) VALUES(0)";
            }
            DatabaseConnectionManager.execute(query);
        }

        public void AddPlayer(string username, string password)
        {
            string query = $"INSERT INTO players (username,player_password) VALUES ('{username}','{password}')";
            DatabaseConnectionManager.execute(query);
        }

        public void RemovePlayer(string username)
        {
            string query = "DELETE FROM players WHERE username = " + username;
            DatabaseConnectionManager.execute(query);
         }



    }
}
