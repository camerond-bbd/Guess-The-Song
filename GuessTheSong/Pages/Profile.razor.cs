using GuessTheSong.components;
using GuessTheSong.Utils;
using Microsoft.AspNetCore.Components;

namespace GuessTheSong.Pages
{
    public partial class Profile
    {
        [Parameter]
        public int? Id { get; set; }
        public Profile()
        {
            string errorMessage = "User not found";
            bool displayError = true;

            //PubSubManager.Publish<PopupMessage.errorObject>("displayErrorMessage", new PopupMessage.errorObject(errorMessage, displayError, () => { }));
        }
    }
}
