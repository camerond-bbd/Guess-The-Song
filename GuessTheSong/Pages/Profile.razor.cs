using GuessTheSong.components;
using GuessTheSong.Utils;
using Microsoft.AspNetCore.Components;
using SongGame.Models;


namespace GuessTheSong.Pages
{
    public partial class Profile
    {
        [Parameter]
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public int Score { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            Players p = ModelLoader.getPlayers(Id);
            Name = p.username;
        }
        public Profile()
        {

/*            
            Scores playerScores = ModelLoader.getScore(Id);

           

            Score = playerScores.player_score;*/

        }
    }
}
