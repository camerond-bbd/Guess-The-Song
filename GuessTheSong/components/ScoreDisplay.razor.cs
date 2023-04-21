using Microsoft.AspNetCore.Components;
using SongGame.Models;

namespace GuessTheSong.components
{
    public partial class ScoreDisplay
    {
        public Scores playerScore = new Scores();

        [Parameter]
        public int Score { get; set; }
    }
}
