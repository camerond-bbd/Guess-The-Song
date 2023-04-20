using GuessTheSong.components;
using GuessTheSong.Utils;

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
            ModelLoader.getUserDetails(username, password);

            if (password)
            {
                errorMessage = "Password is incorrect";
                displayError = true;

                PubSubManager.Publish<PopupMessage.errorObject>("displayErrorMessage", new PopupMessage.errorObject(errorMessage, displayError));
                return;
            }
            else if (username)
            {
                errorMessage = "Username is incorrect";
                displayError = true;
                PubSubManager.Publish<PopupMessage.errorObject>("displayErrorMessage", new PopupMessage.errorObject(errorMessage, displayError));
                return;
            } else
            {

            }
        }
    }
}
