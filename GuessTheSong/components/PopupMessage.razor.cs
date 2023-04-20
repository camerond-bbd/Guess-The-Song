using GuessTheSong.Utils;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.Reflection.Metadata;

namespace GuessTheSong.components
{
    public partial class PopupMessage
    {
        public class errorObject
        {
            public string message { get; set; }
            public bool showMessage { get; set; }

            public delegate void onClickDo();

            public onClickDo doOnClick = () => { };

            public errorObject() {
                message = string.Empty;
                showMessage = false;
            
            }

            public errorObject(string message, bool showMesasge, onClickDo? doOnclick) {
                this.message = message;
                this.showMessage = showMesasge;
                if (doOnclick != null)
                    this.doOnClick = doOnclick;
            }
        }
        [Parameter]
        public string errorMessage { get; set; } = "";
        
        [Parameter]
        public bool isDisplayingMessage { get; set; }
        public errorObject.onClickDo doOnClick = () => { };
        public string getClasses()
        {
            return (isDisplayingMessage) ? $"backdrop" : $"backdrop noDisplay";
        }

        public void onclick()
        {
            this.isDisplayingMessage = false;
            this.doOnClick();
        }

        public void update(errorObject errorObj)
        {
            
            this.errorMessage = errorObj.message;
            this.isDisplayingMessage = errorObj.showMessage;
            this.doOnClick = errorObj.doOnClick;

            this.StateHasChanged();
        }

        public PopupMessage()
        {
            PubSubManager.Subscribe<errorObject>("displayErrorMessage", this.update);
        }

        ~PopupMessage()
        {
            PubSubManager.UnSubscribe<errorObject>("displayErrorMessage", this.update);
        }
    }
}
