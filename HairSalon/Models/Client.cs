using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
    public class Client
    {
        private string FirstName {get; set;}
        private string LastName {get; set;}
        private string PhoneNumber {get; set;}
        private string EmailAddress {get; set;}
        private int Id {get; set;}

        public Client (string firstName, string lastName, string phoneNumber, string emailAddress, int id = 0)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            Id = id;
        }

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherClient;
                bool idEquality = this.Id == newClient.Id;
                bool firstNameEquality = this.FirstName == newClient.FirstName;
                bool lastNameEquality = this.LastName == newClient.LastName;
                bool phoneNumberEquality = this.PhoneNumber == newClient.PhoneNumber;
                bool emailAddressEquality = this.EmailAddress == newClient.EmailAddress;
                return (idEquality && firstNameEquality && lastNameEquality && phoneNumberEquality && emailAddressEquality);
            }
        }

        public static List<Client> GetAll()
        {
            List<Client> allClients = new List<Client> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientFirstName = rdr.GetString(1);
                string clientLastName = rdr.GetString(2);
                string clientPhoneNumber = rdr.GetString(3);
                string clientEmailAddress = rdr.GetString(4);
                Client newClient = new Client(clientFirstName, clientLastName, clientPhoneNumber, clientEmailAddress, clientId);
                allClients.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allClients;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Client Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE id = (@search_id);";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@search_id";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int clientId = 0;
            string clientFirstName = "";
            string clientLastName = "";
            string clientPhoneNumber = "";
            string clientEmailAddress = "";
            while(rdr.Read())
            {
                clientId = rdr.GetInt32(0);
                clientFirstName = rdr.GetString(1);
                clientLastName = rdr.GetString(2);
                clientPhoneNumber = rdr.GetString(3);
                clientEmailAddress = rdr.GetString(4);
            }
            Client newClient = new Client(clientFirstName, clientLastName, clientPhoneNumber, clientEmailAddress, clientId);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newClient;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO clients
                                  (first_name, last_name, phone_number, email_address)
                              VALUES
                                  (@first_name, @last_name, @phone_number, @email_address);";
            MySqlParameter firstName = new MySqlParameter();
            firstName.ParameterName = "@first_name";
            firstName.Value = this.FirstName;
            cmd.Parameters.Add(firstName);
            MySqlParameter lastName = new MySqlParameter();
            lastName.ParameterName = "@last_name";
            lastName.Value = this.LastName;
            cmd.Parameters.Add(lastName);
            MySqlParameter phoneNumber = new MySqlParameter();
            phoneNumber.ParameterName = "@phone_number";
            phoneNumber.Value = this.PhoneNumber;
            cmd.Parameters.Add(phoneNumber);
            MySqlParameter emailAddress = new MySqlParameter();
            emailAddress.ParameterName = "@email_address";
            emailAddress.Value = this.EmailAddress;
            cmd.Parameters.Add(emailAddress);
            cmd.ExecuteNonQuery();
            Id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Edit(string newFirstName, string newLastName, string newPhoneNumber, string newEmailAddress)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE clients SET
                                  first_name = @new_first_name,
                                  last_name = @new_last_name,
                                  phone_number = @new_phone_number,
                                  email_address = @new_email_address
                              WHERE id = @search_id;";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@search_id";
            searchId.Value = Id;
            cmd.Parameters.Add(searchId);
            MySqlParameter firstName = new MySqlParameter();
            firstName.ParameterName = "@new_first_name";
            firstName.Value = newFirstName;
            cmd.Parameters.Add(firstName);
            MySqlParameter lastName = new MySqlParameter();
            lastName.ParameterName = "@new_last_name";
            lastName.Value = newLastName;
            cmd.Parameters.Add(lastName);
            MySqlParameter phoneNumber = new MySqlParameter();
            phoneNumber.ParameterName = "@new_phone_number";
            phoneNumber.Value = newPhoneNumber;
            cmd.Parameters.Add(phoneNumber);
            MySqlParameter emailAddress = new MySqlParameter();
            emailAddress.ParameterName = "@new_email_address";
            emailAddress.Value = newEmailAddress;
            cmd.Parameters.Add(emailAddress);
            cmd.ExecuteNonQuery();
            FirstName = newFirstName;
            LastName = newLastName;
            PhoneNumber = newPhoneNumber;
            EmailAddress = newEmailAddress;
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
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients WHERE id = @client_id; DELETE FROM stylists_clients WHERE client_id = @client_id;";
            MySqlParameter clientIdParameter = new MySqlParameter();
            clientIdParameter.ParameterName = "@client_id";
            clientIdParameter.Value = this.Id;
            cmd.Parameters.Add(clientIdParameter);
            cmd.ExecuteNonQuery();
            if (conn != null)
            {
              conn.Close();
            }
        }

        public List<Stylist> GetStylists()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT stylists.* FROM clients
                JOIN stylists_clients ON (clients.id = stylists_clients.client_id)
                JOIN stylists ON (stylists_clients.stylist_id = stylists.id)
                WHERE clients.id = @client_id;";
            MySqlParameter clientIdParameter = new MySqlParameter();
            clientIdParameter.ParameterName = "@client_id";
            clientIdParameter.Value = Id;
            cmd.Parameters.Add(clientIdParameter);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            List<Stylist> stylists = new List<Stylist> {};
            while(rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistName = rdr.GetString(1);
                string stylistDescription = rdr.GetString(2);
                Stylist foundStylist = new Stylist (stylistName, stylistDescription, stylistId);
                stylists.Add(foundStylist);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return stylists;
        }

        public void AddStylist(Stylist newStylist)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists_clients (stylist_id, client_id) VALUES (stylist_id, @client_id);";
            MySqlParameter stylist_id = new MySqlParameter();
            stylist_id.ParameterName = "@stylist_id";
            stylist_id.Value = newStylist.Id;
            cmd.Parameters.Add(stylist_id);
            MySqlParameter client_id = new MySqlParameter();
            client_id.ParameterName = "@client_id";
            client_id.Value = Id;
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
