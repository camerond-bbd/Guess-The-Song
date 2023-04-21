using GuessTheSong.components;

namespace GuessTheSong.Utils
{
    public class GameManager
    {
        public GameManager() {
            PubSubManager.Subscribe<OptionsDisplay.OptionsDisplayDataPass>("optionWasClicked", optionWasChosen);
        }
        
        public int[] songList = new int[3];
        public int[] loadRound()
        {
            return songList;
        }

        public void optionWasChosen(OptionsDisplay.OptionsDisplayDataPass optionClicked)
        {

        }
    }
}
