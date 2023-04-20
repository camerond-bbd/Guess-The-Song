using DatabaseHandler;
using System.Collections.Generic;


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
        String query = "SELECT name FROM artists WHERE artist_id = " + id;
        result = DatabaseHandler.execute(query);
        Artist artist = new Artist(result.id, result.name)
        return artist
       }

       public Genres getGenre(String id){
       Dictionary<string, string> result = new Dictionary<string, string>();
        String query = "SELECT name FROM artists WHERE artist_id = " + id;
        result = DatabaseHandler.execute(query);
        Artist artist = new Artist(result.id, result.name)
        return artist
       }





    }
}
