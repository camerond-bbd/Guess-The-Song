﻿namespace SongGame.Models
{ 
    public class Genres
    {
        public int genre_id { get; }
        public string name { get; set; }

        public Genres (string genreName)
        {
            name = genreName;
        }
    }
}