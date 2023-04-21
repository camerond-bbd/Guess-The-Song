using Microsoft.AspNetCore.Components;

namespace GuessTheSong.Pages
{
    public partial class GamePage
    {
        [Parameter]
        public int UserID { get; set; }
    }
}
