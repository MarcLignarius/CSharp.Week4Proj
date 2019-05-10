using System.Collections.Generic;

namespace HairSalon.Models
{
    public class Stylist
    {
        private static List<Stylist> _instances = new List<Stylist> {};
        private int _id;
        private string _name;
        private string _description;
        private List<Client> _clients;

        public Stylist(string name, string description)
        {
            _name = name;
            _description = description;
            _instances.Add(this);
            _id = _instances.Count;
            _clients = new List<Client>{};
        }

        public string GetName()
        {
            return _name;
        }

        // public string SetName(string newName)
        // {
        //     _name = newName;
        // }

        public string GetDescription()
        {
            return _description;
        }

        // public string SetDescription(string newDescription)
        // {
        //     _description = newDescription;
        // }

        public int GetId()
        {
            return _id;
        }

        public static List<Stylist> GetAll()
        {
            return _instances;
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }
    }
}
