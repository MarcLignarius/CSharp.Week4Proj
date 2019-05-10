namespace HairSalon.Models
{
    public class Client
    {
        private string _firstName;
        private string _lastName;

        public Client (string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public string GetFirstName()
        {
            return _firstName;
        }

        public void SetFirstName(string newFirstName)
        {
            _firstName = newFirstName;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public void SetLastName(string newLastName)
        {
            _lastName = newLastName;
        }



    }
}
