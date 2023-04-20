namespace SongGame.Models
{ 
    public class Genres
    {
        public int genre_id { get; set;  }
        public string name { get; set; }

        public Genres ()
        {
            genre_id = 0;
            name = string.Empty;
        }

        public Genres (string genreName)
        {
            name = genreName;
        }
    }
}