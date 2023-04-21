using GuessTheSong.components;
using SongGame.Models;

namespace GuessTheSong.Utils
{
    public static class ModelLoader
    {
        static public Artists getArtist(int id)
        {
            string query = $"SELECT [name] FROM artists WHERE artist_id = {id}";
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(new string[] { "name" }, query)!;
            //Artists artist = new Artists((string)result["name"],id);
            Artists artists = new Artists();
            artists.artist_id = id;
            artists.name = (string)result["name"];
            return artists;
        }

        static public Genres getGenre(int id)
        {
            string query = $"SELECT [name] FROM genres WHERE genre_id = {id}";
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(new string[] { "name" }, query)!;
            Genres genre = new Genres();
            genre.name = (string)result["name"];
            genre.genre_id = id;
            return genre;
        }

        static public Lyrics getLyrics(int id)
        {
            string query = $"SELECT lyric_text FROM lyrics WHERE lyric_id = {id}";
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(new string[] { "lyric_text" }, query)!;
            Lyrics lyrics = new Lyrics();
            lyrics.lyric_id = id;
            lyrics.lyric_text = (string)result["lyric_text"];
            return lyrics;
        }

        static public Players getPlayers(int id)
        {
            string query = $"SELECT username FROM players WHERE player_id = {id}";
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(new string[] { "username" }, query)!;
            Players players = new Players();
            players.username = (string) result["username"];
            players.player_id = id;
            return players;
        }

        static public Scores getScore(int player_id)
        {
            string query = $"SELECT SUM(player_score) AS tot_player_score FROM scores WHERE player_id={player_id}";
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(new string[] {"tot_player_score"}, query)!;
            Scores scores = new Scores();
            scores.player_id = player_id;
            if (result["tot_player_score"] == DBNull.Value)
                scores.player_score = 0;
            else
                scores.player_score = (int)result["tot_player_score"];
            return scores;
        }

        static public Songs getSongs(int id)
        {
            string query = $"SELECT title, artist_id, genre_id FROM songs WHERE song_id = {id}";
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(new string[] {"title","artist_id","genre_id"}, query)!;
            //result = DatabaseConnectionManager.doQuery(new string[] { "title", "artist_id", "genre_id" }, query)!;
            Songs song = new Songs();
            song.song_id = id;
            song.title = (string)result["title"];
            song.artist_id = (int)result["artist_id"];
            song.genre_id = (int)result["genre_id"];
            return song;
        }

        static public void addScore(bool wonRound, int player_id)
        {
            string query;

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

        static public void AddPlayer(string username, string password)
        {
            string query = $"INSERT INTO players (username,player_password) VALUES ('{username}','{password}')";
            DatabaseConnectionManager.executeQuery(query);
        }

        static public void RemovePlayer(string username)
        {
            string query = $"DELETE FROM players WHERE username = {username}";
            DatabaseConnectionManager.executeQuery(query);
        }

        static public string getUserDetails(string username, string password)
        {
            string query = $"SELECT password FROM players WHERE username = {username}";
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(new string[] { "password" }, query)!;
            return (string)result["password"];
        }
        
        static public bool getValidUser(string username, string password)
        {
            string query = $"SELECT * FROM players WHERE (username = '{username}') AND (player_password = '{Encryption.encrypt(password)}')";
            return DatabaseConnectionManager.rowCount(query) == 1;
        }

        static public bool isUserInDatabase(string username)
        {
            string query = $"SELECT * FROM players WHERE (username = '{username}')";
            return DatabaseConnectionManager.rowCount(query) == 1;
        }

        static public Players getPlayer(string username, string password)
        {
            Players returnMe = new Players();
            string query = $"SELECT player_id,username,player_password FROM players WHERE (username = '{username}') AND (player_password = '{Encryption.encrypt(password)}')";
            string[] fields = new string[] { "Id","username","password" };
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(fields, query)!;
            returnMe.username = (string)result["username"];
            returnMe.player_id = (int)result["Id"];
            returnMe.player_password = (string)result["password"];
            return returnMe; 
        }

        static public OptionsDisplay.OptionsDisplayDataPass getIncorrectSongs(int Id)
        {
            string query = $"SELECT s.title, a.name, g.name FROM songs s, artists a, genres g WHERE s.song_id = {Id} AND a.artist_id = s.artist_id AND g.genre_id = s.genre_id";
            string[] fields = new string[] { "title, artist, genre" };
            Dictionary<string, object> result = DatabaseConnectionManager.doQuery(fields, query)!;
            OptionsDisplay.OptionsDisplayDataPass Out = new OptionsDisplay.OptionsDisplayDataPass();
            Out.artist.name = (string)result["artist"];
            Out.genre.name = (string)result["genre"];
            Out.song.title = (string)result["title"];
            return Out;
        }
    }
}
