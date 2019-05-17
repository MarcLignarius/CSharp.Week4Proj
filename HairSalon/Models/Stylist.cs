using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
    public class Stylist
    {
        private string _name;
        private string _description;
        private int _id;

        public Stylist(string name, string description, int id = 0)
        {
            _name = name;
            _description = description;
            _id = id;
        }

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                bool idEquality = this.GetId().Equals(newStylist.GetId());
                bool nameEquality = this.GetName().Equals(newStylist.GetName());
                bool descriptionEquality = this.GetDescription().Equals(newStylist.GetDescription());
                return (idEquality && nameEquality && descriptionEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.GetId().GetHashCode();
        }

        public string GetName()
        {
            return _name;
        }

        public string GetDescription()
        {
            return _description;
        }

        public int GetId()
        {
            return _id;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists (name, description) VALUES (@name, @description);";
            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = this._name;
            cmd.Parameters.Add(name);
            MySqlParameter description = new MySqlParameter();
            description.ParameterName = "@description";
            description.Value = this._description;
            cmd.Parameters.Add(description);
            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

        }

        public List<Client> GetClients()
        {
          List<Client> allStylistClients = new List<Client> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylist_id;";
          MySqlParameter stylistId = new MySqlParameter();
          stylistId.ParameterName = "@stylist_id";
          stylistId.Value = this._id;
          cmd.Parameters.Add(stylistId);
          var rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
            int clientId = rdr.GetInt32(0);
            string clientFirstName = rdr.GetString(1);
            string clientLastName = rdr.GetString(2);
            string clientPhoneNumber = rdr.GetString(3);
            string clientEmailAddress = rdr.GetString(4);
            int clientStylistId = rdr.GetInt32(5);
            Client newClient = new Client(clientFirstName, clientLastName, clientPhoneNumber, clientEmailAddress, clientStylistId, clientId);
            allStylistClients.Add(newClient);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allStylistClients;
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists ORDER BY name;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistName = rdr.GetString(1);
                string stylistDescription = rdr.GetString(2);
                Stylist newStylist = new Stylist(stylistName, stylistDescription, stylistId);
                allStylists.Add(newStylist);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allStylists;
        }

        public static Stylist Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists WHERE id = (@search_id);";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@search_id";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int stylistId = 0;
            string stylistName = "";
            string stylistDescription = "";
            while(rdr.Read())
            {
              stylistId = rdr.GetInt32(0);
              stylistName = rdr.GetString(1);
              stylistDescription = rdr.GetString(2);
            }
            Stylist newStylist = new Stylist(stylistName, stylistDescription, stylistId);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newStylist;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public List<Specialty> GetSpecialties()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT specialties.* FROM stylists
                JOIN stylists_specialties ON (stylists.id = stylists_specialties.stylist_id)
                JOIN specialties ON (stylists_specialties.specialty_id = specialties.id)
                WHERE stylists.id = @stylist_id;";
            MySqlParameter stylistIdParameter = new MySqlParameter();
            stylistIdParameter.ParameterName = "@stylist_id";
            stylistIdParameter.Value = _id;
            cmd.Parameters.Add(stylistIdParameter);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            List<Specialty> specialties = new List<Specialty> {};
            while(rdr.Read())
            {
                int thisSpecialtyId = rdr.GetInt32(0);
                string specialtyName = rdr.GetString(1);
                string specialtyDescription = rdr.GetString(2);
                Specialty foundSpecialty = new Specialty(specialtyName, specialtyDescription, thisSpecialtyId);
                specialties.Add(foundSpecialty);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return specialties;
        }

        public void AddSpecialty(Specialty newSpecialty)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists_specialties (stylist_id, specialty_id) VALUES (@stylist_id, @specialty_id);";
            MySqlParameter stylist_id = new MySqlParameter();
            stylist_id.ParameterName = "@stylist_id";
            stylist_id.Value = newSpecialty.GetId();
            cmd.Parameters.Add(stylist_id);
            MySqlParameter specialty_id = new MySqlParameter();
            specialty_id.ParameterName = "@specialty_id";
            specialty_id.Value = _id;
            cmd.Parameters.Add(specialty_id);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
