namespace SongGame.Models
{
    public class Songs
    {
        public int song_id { get; }
        public string title { get; set; }
        public int artist_id { get; set; }
        public int genre_id { get; set; }

        public Songs() { 
            song_id = 0;
            title = string.Empty;
            artist_id = 0;
            genre_id = 0;
        }

        public Songs (string songTitle, int artistId, int genreId)
        {
            title = songTitle;
            artist_id = artistId;
            genre_id = genreId;
        }
    }
}
