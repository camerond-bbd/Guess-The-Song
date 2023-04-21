using GuessTheSong.components;
using GuessTheSong.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using SongGame.Models;

namespace GuessTheSong.Pages
{
    public partial class Profile
    {
        [Parameter]
        public int Id { get; set; }
        
        public string Name { get; set; } = "";

        public int Score { get; set; }

        public Players player { get; set; } = new Players();
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            player = ModelLoader.getPlayers(Id);
            Scores playerScore = ModelLoader.getScore(Id);
            Name = player.username;

            Score = playerScore.player_score;
        }


        public void goToGameClick()
        {
            Navigation.NavigateTo($"/GamePage/{Id}");
        }
    }
}
