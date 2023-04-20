using GuessTheSong.components;
using GuessTheSong.Utils;
using Microsoft.AspNetCore.Components.Routing;
using SongGame.Models;

namespace GuessTheSong.Pages
{
    public partial class SignUp
    {
        public string password { get; set; } = "";
        public string username { get; set; } = "";
        public bool displayError = false;
        public string errorMessage = "";
        public void signUpClick()
        {
            if (password.Length < 4)
            {
                errorMessage = "Password is too short";
                displayError = true;

                PubSubManager.Publish<PopupMessage.errorObject>("displayErrorMessage", new PopupMessage.errorObject(errorMessage, displayError, () => { }));
                return;
            }

            if (username.Length < 4)
            {
                errorMessage = "Username is too short";
                displayError = true;
                PubSubManager.Publish<PopupMessage.errorObject>("displayErrorMessage", new PopupMessage.errorObject(errorMessage, displayError, () => { }));
                return;
            }
            if (ModelLoader.isUserInDatabase(username))
            {
                errorMessage = "Username is already in use";
                displayError = true;
                
                PubSubManager.Publish<PopupMessage.errorObject>("displayErrorMessage", new PopupMessage.errorObject(errorMessage, displayError, () => {}));
                username = "";
                password = "";
                return;
            }

            ModelLoader.AddPlayer(username, Encryption.encrypt(password));
            errorMessage = "Username was registered successfully";
            displayError = true;

            Players signedInPlayer = ModelLoader.getPlayer(username, password);

            PubSubManager.Publish<PopupMessage.errorObject>("displayErrorMessage", new PopupMessage.errorObject(errorMessage, displayError, () =>
            {
                Navigation.NavigateTo($"/Profile/{signedInPlayer.player_id}");
            }));
            
        }
    }
}
