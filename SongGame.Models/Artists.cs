namespace SongGame.Models
{
    public class Artists
    {
        public int artist_id { get; set;  }
        public string name { get; set; }
       

        public Artists()
        {
            artist_id = 0;
            name= string.Empty;
        }
        public Artists (string artistName, int artist_id)
        {
            name = artistName;
        }
    }
}