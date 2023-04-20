namespace SongGame.Models
{
    public class Scores
    {
        public int score_id { get; set; }
        public int player_id { get; set; }
        public int player_score { get; set; }

        public Scores ()
        {
            score_id = 0;
            player_id = 0;
            player_score = 0;
        }

        public Scores (int playerScore)
        {
            player_score = playerScore;
        }
    }
}