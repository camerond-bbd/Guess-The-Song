using GuessTheSong.Utils;
using Microsoft.AspNetCore.Components;
using SongGame.Models;

namespace GuessTheSong.Pages
{
    public partial class GamePage
    {
        [Parameter]
        public int Id { get; set; }

        public GameManager Manager { get; set; } = new GameManager();
        public Players player { get; set; } = new Players();
        public string Name { get; set; } = "";
        public int Score { get; set; }
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            Players player = ModelLoader.getPlayers(Id);
            Scores playerScore = ModelLoader.getScore(Id);
            Name = player.username;

            Score = playerScore.player_score;
        }

        public GamePage()
        {
            
        }
    }
}
