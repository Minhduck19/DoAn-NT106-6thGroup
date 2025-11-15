
namespace APP_DOAN
{
    internal class ChangePassword
    {
        private string loggedInEmail;
        private string idToken;

        public ChangePassword(string loggedInEmail, string idToken)
        {
            this.loggedInEmail = loggedInEmail;
            this.idToken = idToken;
        }

        internal void ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
}