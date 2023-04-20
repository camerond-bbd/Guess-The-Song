using SongGame.Models;

namespace GuessTheSong.Utils
{
    public class ModelLoader
    {
        public Artists getArtist(int id)
        {
            string query = $"SELECT [name] FROM artists WHERE artist_id = {id}";
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(new string[] { "name" }, query);
            //Artists artist = new Artists((string)result["name"],id);
            Artists artists = new Artists();
            artists.artist_id = id;
            artists.name = (string)result["name"];
            return artists;
        }

        public Genres getGenre(string id)
        {
            string query = $"SELECT [name] FROM genres WHERE genre_id = {id}";
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(new string[] { "name" }, query);
            Genres genre = new Genres();
            genre.name = (string)result["name"];
            genre.genre_id = id;
            return genre;
        }

        public Lyrics getLyrics(int id)
        {
            string query = $"SELECT lyric_text FROM lyrics WHERE lyric_id = {id}";
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(new string[] { "lyric_text" }, query);
            Lyrics lyrics = new Lyrics();
            lyrics.lyric_id = id;
            lyrics.lyric_text = result["lyric_text"];
            return lyrics;
        }

        public Players getPlayers(int id)
        {
            string query = $"SELECT username FROM players WHERE player_id = {id}";
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(new string[] { "username" }, query);
            Players players = new Players();
            players.username = (string) result["username"];
            players.player_id = id;
            return players;
        }

        public Scores getScore(int player_id)
        {
            string query = $"SELECT COUNT(player_score) AS tot_player_score  FROM scores WHERE player_id = {id}";
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(new string[] {"tot_player_score"}, query);
            Scores scores = new Scores();
            scores.player_id = player_id;
            scores.player_score = result.tot_player_score;
            return scores;
        }

        public Songs getSongs(int id)
        {
            string query = $"SELECT title, artist_id, genre_id FROM songs WHERE song_id = {id}";
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(new string[] {"title","artist_id","genre_id"}, query);
            result = DatabaseConnectionManager.doQuery(query);
            Songs song = new Songs();
            song.song_id = id;
            song.title = result["title"];
            song.artist_id = result["artist_id"];
            song.genre_id = result["genre_id"];
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
            DatabaseConnectionManager.executeQuery(query); //handle should we get false returned 
        }

        public void AddPlayer(string username, string password)
        {
            string query = $"INSERT INTO players (username,player_password) VALUES ('{username}','{password}')";
            DatabaseConnectionManager.executeQuery(query);
        }

        public void RemovePlayer(string username)
        {
            string query = $"DELETE FROM players WHERE username = {username}";
            DatabaseConnectionManager.executeQuery(query);
         }



    }
}
