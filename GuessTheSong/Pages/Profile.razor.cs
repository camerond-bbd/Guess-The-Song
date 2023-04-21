using GuessTheSong.components;
using GuessTheSong.Utils;
using Microsoft.AspNetCore.Components;
using SongGame.Models;


namespace GuessTheSong.Pages
{
    public partial class Profile
    {
        [Parameter]
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public int Score { get; set; }
        public Profile()
        {

            Players player = ModelLoader.getPlayers(Id);
            Scores playerScores = ModelLoader.getScore(Id);

            Name = player.username;

            Score = playerScores.player_score;

        }
    }
}
