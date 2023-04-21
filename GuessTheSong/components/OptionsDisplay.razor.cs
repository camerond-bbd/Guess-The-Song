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

            public OptionsDisplayDataPass()
            {
                this.artist = new Artists();
                this.song = new Songs();
                this.genre = new Genres();
            }
        }

        public OptionsDisplayDataPass data = new OptionsDisplayDataPass();


        public void onClick()
        {
            PubSubManager.Publish<OptionsDisplayDataPass>("optionWasClicked", data);
        }

        public OptionsDisplay() { 
            //PubSubManager.Subscribe<OptionsDisplayDataPass>()
        }
    }
}
