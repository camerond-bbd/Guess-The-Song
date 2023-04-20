namespace GuessTheSong.Utils
{
    public class Encryption
    {
      public static string encrypt(string text){
            string encryptedText = "";
            foreach(char character in text){
                int temp =(int)(character+5);
                encryptedText += (char)temp;
            }
            return encryptedText;
       }

       public static string decrypt(string text){
            string decryptedText = "";
            foreach(char character in text){
                decryptedText += (char)((int)character-5);
            }
            return decryptedText;
       }
    }
}
