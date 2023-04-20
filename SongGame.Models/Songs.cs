namespace SongGame.Models
{
    public class Songs
    {
        public int song_id { get; }
        public string title { get; set; }
        public int artist_id { get; set; }
        public int genre_id { get; set; }

        public Songs (string songTitle, int artistId, int genreId)
        {
            title = songTitle;
            artist_id = artistId;
            genre_id = genreId;
        }
    }
}
