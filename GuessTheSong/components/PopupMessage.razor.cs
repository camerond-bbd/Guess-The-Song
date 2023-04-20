using Microsoft.AspNetCore.Components;

namespace GuessTheSong.components
{
    public partial class PopupMessage
    {
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
    }
}
