using GuessTheSong.Utils;
using Microsoft.AspNetCore.Components;
using System.Security.Cryptography.X509Certificates;

namespace GuessTheSong.components
{
    public partial class PopupMessage
    {
        public class errorObject
        {
            public string message { get; set; }
            public bool showMessage { get; set; }

            public errorObject() {
                message = string.Empty;
                showMessage = false;
            }

            public errorObject(string message, bool showMesasge) {
                this.message = message;
                this.showMessage = showMesasge;
                
            }
        }
        [Parameter]
        public string errorMessage { get; set; } = "";
        
        [Parameter]
        public bool isDisplayingMessage { get; set; }
        public string getClasses()
        {
            return (isDisplayingMessage) ? $"backdrop" : $"backdrop noDisplay";
        }

        public void onclick()
        {
            this.isDisplayingMessage = false;
        }

        public void update(errorObject errorObj)
        {
            this.errorMessage = errorObj.message;
            this.isDisplayingMessage = errorObj.showMessage;
            this.StateHasChanged();
        }

        public PopupMessage()
        {
            PubSubManager.Subscribe<errorObject>("displayErrorMessage", this.update);
        }
    }
}
