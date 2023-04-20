namespace SongGame.Models
{
    public class Artists
    {
        public int artist_id { get; set;  }
        public string name { get; set; }
       

        public Artists (string artistName)
        {
            name = artistName;
        }
    }
}