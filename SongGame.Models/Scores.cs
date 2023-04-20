namespace SongGame.Models
{
    public class Scores
    {
        public int score_id { get; set; }
        public int player_id { get; set; }
        public int player_score { get; set; }

        public Scores (int playerId, int playerScore)
        {
            player_id = playerId;
            player_score = playerScore;
        }
    }
}