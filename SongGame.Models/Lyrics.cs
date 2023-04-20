﻿namespace SongGame.Models
{
    public class Lyrics
    {
        public int lyric_id { get; }
        public int song_id { get; set; }
        public string lyric_text { get; set; }
       
        public Lyrics (int songId, string lyricText) {
            song_id = songId;
            lyric_text = lyricText; 
        }
    }
}