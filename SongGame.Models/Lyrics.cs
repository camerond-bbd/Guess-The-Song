namespace SongGame.Models
{
    public class Lyrics
    {
        public int lyric_id { get; }
        public int song_id { get; set; }
        public string lyric_text { get; set; }

        public Lyrics ()
        {
            lyric_id = 0;
            song_id = 0;
            lyric_text = string.Empty;
        }
       
        public Lyrics (string lyricText) {
            lyric_text = lyricText; 
        }
    }
}