namespace GuessTheSong.Pages
{
    public partial class SignUp
    {
        public string password { get; set; } = "";
        public string username { get; set; } = "";
        public bool displayError = false;
        public string errorMessage = "";
        public void signUpClick()
        {
            if (password.Length < 4)
            {
                errorMessage = "Password is too short";
                displayError = true;
                return;
            }

            if (username.Length < 4)
            {
                errorMessage = "Username is too short";
                displayError = true;
                return;
            }
        }
    }
}
