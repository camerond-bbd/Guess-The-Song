using GuessTheSong.components;

namespace GuessTheSong.Utils
{
    public class GameManager
    {
        private int[] songIds;
        public int[] getThreeSongIds()
        {
            List<int> result = new List<int>();
            Random rnd = new Random();
            songIds = ModelLoader.getAllSongIds();
            int size = songIds.Length;
            for (int i = 0; i < 3; i++)
            {
                result.Add(rnd.Next(size));
            }
            return result.ToArray();
        }
        public GameManager() {
            songIds = getThreeSongIds();
            PubSubManager.Subscribe<OptionsDisplay.OptionsDisplayDataPass>("optionWasClicked", optionWasChosen);
            Lyrics = ModelLoader.getSongLyrics(songIds[0]);
        }
        public SongGame.Models.Lyrics Lyrics = new SongGame.Models.Lyrics();


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
