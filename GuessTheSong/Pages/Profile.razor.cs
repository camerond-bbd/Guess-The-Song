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
            Players player = ModelLoader.getPlayers(Id);
            Scores playerScore = ModelLoader.getScore(Id);
            Name = player.username;

            Score = playerScore.player_score;
        }
        
        public Players loggedinUser { get; set; }

        public Profile()
        {
            loggedinUser = new Players();
            if (Id == 0)
                return;
            loggedinUser = ModelLoader.getPlayers(Id);
            //PubSubManager.Publish<PopupMessage.errorObject>("displayErrorMessage", new PopupMessage.errorObject(errorMessage, displayError, () => { }));
        }


        public void goToGameClick()
        {

        }
    }
}
