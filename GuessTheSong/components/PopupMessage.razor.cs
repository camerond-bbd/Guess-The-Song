using Microsoft.AspNetCore.Components;

namespace GuessTheSong.components
{
    public partial class PopupMessage
    {
        public string errorMessage = "";
        
        [Parameter]
        public bool isDisplayingMessage { get; set; }
        public string getClasses()
        {
            return (isDisplayingMessage) ? $"popupMessage" : $"popupMessage noDisplay";
        }
    }
}
