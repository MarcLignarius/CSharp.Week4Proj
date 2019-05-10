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

        public Stylist(int id, string name, string description)
        {
            _id = id;
            _name = name;
            _description = description;
            _instances.Add(this);
            _id = _instances.Count;
            _clients = new List<Client>{};
        }
    }
}
