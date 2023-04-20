using GuessTheSong.components;
using GuessTheSong.Utils;
using SongGame.Models;

namespace GuessTheSong.Pages
{
    public partial class SignIn
    {
        public string password { get; set; } = "";
        public string username { get; set; } = "";
        public bool displayError = false;
        public string errorMessage = "";
        public void signInClick()
        {
            if (password.Length < 4)
            {
                errorMessage = "Password is invalid";
                displayError = true;

                PubSubManager.Publish<PopupMessage.errorObject>("displayErrorMessage", new PopupMessage.errorObject(errorMessage, displayError, () => { }));
                return;
            }
            if (username.Length < 4)
            {
                errorMessage = "Username is invalid";
                displayError = true;
                PubSubManager.Publish<PopupMessage.errorObject>("displayErrorMessage", new PopupMessage.errorObject(errorMessage, displayError, () => { }));
                return;
            }
            if (ModelLoader.getValidUser(username, password))
            {
                errorMessage = "Username successfully logged in";
                displayError = true;
                PubSubManager.Publish<PopupMessage.errorObject>("displayErrorMessage", new PopupMessage.errorObject(errorMessage, displayError, () =>{
                    Players signedInPlayer = ModelLoader.getPlayer(username, password);
                    Navigation.NavigateTo($"/Profile/{signedInPlayer.player_id}");
                }));
                
                return;
            }
        }
    }
}
