using SongGame.Models;

namespace GuessTheSong.components
{
    public partial class SmallProfileDisplay
    {
        public Players player;


        public SmallProfileDisplay()
        {
            player = new Players();
            player.username = "SomeUserName";
        }
    }
}
