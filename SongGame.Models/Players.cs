namespace SongGame.Models
{
    public class Players
    {
        public int player_id { get; }
        public string username { get; set; }
        public string player_password { get; set; }

        public Players() {
            player_id = 0;
            username = string.Empty;
            player_password = string.Empty;
        }

        public Players ( string userName, string playerPassword)
        {
            username = userName;
            player_password = playerPassword;
        }
    }
}
