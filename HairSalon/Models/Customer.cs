namespace HairSalon.Models
{
    public class Client
    {
        private string _firstName;

        public Client (string firstName)
        {
            _firstName = firstName;
        }

        public string GetFirstName()
        {
            return _firstName;
        }
    }
}
