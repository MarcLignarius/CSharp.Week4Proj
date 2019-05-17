using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
    public class Stylist
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public int Id {get; set;}

        public Stylist(string name, string description, int id = 0)
        {
            Name = name;
            Description = description;
            Id = id;
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
                bool idEquality = this.Id.Equals(newStylist.Id);
                bool nameEquality = this.Name.Equals(newStylist.Name);
                bool descriptionEquality = this.Description.Equals(newStylist.Description);
                return (idEquality && nameEquality && descriptionEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists (name) VALUES (@name);";
            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = this.Name;
            cmd.Parameters.Add(name);
            cmd.ExecuteNonQuery();
            Id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

        }

        public List<Client> GetClients()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT clients.* FROM stylists
                                  JOIN stylists_clients ON (stylists.id = stylists_clients.stylist_id)
                                  JOIN clients ON (stylists_clients.client_id = clients.id)
                              WHERE stylists.id = @stylist_id;";
            MySqlParameter stylistIdParameter = new MySqlParameter();
            stylistIdParameter.ParameterName = "@stylist_id";
            stylistIdParameter.Value = Id;
            cmd.Parameters.Add(stylistIdParameter);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            List<Client> clients = new List<Client>{};
            while(rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientFirstName = rdr.GetString(1);
                string clientLastName = rdr.GetString(2);
                string clientPhoneNumber = rdr.GetString(3);
                string clientEmailAddress = rdr.GetString(4);
                Client newClient = new Client(clientFirstName, clientLastName, clientPhoneNumber, clientEmailAddress, clientId);
                clients.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
              conn.Dispose();
            }
            return clients;
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> allCategories = new List<Stylist> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistName = rdr.GetString(1);
                string stylistDescription = rdr.GetString(2);
                Stylist newStylist = new Stylist(stylistName, stylistDescription, stylistId);
                allCategories.Add(newStylist);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCategories;
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

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM stylists WHERE id = @stylist_id; DELETE FROM stylists_clients WHERE stylist_id = @stylist_id;");
            MySqlParameter stylistIdParameter = new MySqlParameter();
            stylistIdParameter.ParameterName = "@stylist_id";
            stylistIdParameter.Value = this.Id;
            cmd.Parameters.Add(stylistIdParameter);
            cmd.ExecuteNonQuery();
            if (conn != null)
            {
                conn.Close();
            }
        }

        public void AddClient(Client newClient)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists_clients (stylist_id, client_id) VALUES (@stylist_id, @client_id);";
            MySqlParameter stylist_id = new MySqlParameter();
            stylist_id.ParameterName = "@stylist_id";
            stylist_id.Value = Id;
            cmd.Parameters.Add(stylist_id);
            MySqlParameter client_id = new MySqlParameter();
            client_id.ParameterName = "@client_id";
            client_id.Value = newClient.Id;
            cmd.Parameters.Add(client_id);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
