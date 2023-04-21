using GuessTheSong.Utils;
using SongGame.Models;

namespace GuessTheSong.components
{
    public partial class OptionsDisplay
    {

        public class OptionsDisplayDataPass
        {
            public Artists artist { get; set; } = new Artists();
            public Songs song { get; set; } = new Songs();
            public Genres genre { get; set; } = new Genres();
        }
        public Artists artist { get; set; }= new Artists();
        public Songs song { get; set; } = new Songs();
        public Genres genre { get; set; } = new Genres();
        
      
        public void onClick()
        {
            OptionsDisplayDataPass passData = new OptionsDisplayDataPass();
            passData.song = song;
            passData.artist = artist; 
            passData.genre = genre;
            PubSubManager.Publish<OptionsDisplayDataPass>("optionWasClicked", passData);
        }

        OptionsDisplay() { 
            //PubSubManager.Subscribe<OptionsDisplayDataPass>()
        }
    }
}
