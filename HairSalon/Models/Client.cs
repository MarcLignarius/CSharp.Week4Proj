using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
    public class Client
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _emailAddress;
        private int _stylistId;

        public Client(string firstName, string lastName, string phoneNumber, string emailAddress, int stylistId, int id = 0)
        {
            _firstName = firstName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
            _emailAddress = emailAddress;
            _stylistId = stylistId;
            _id = id;
        }

        public string FirstName {get => _firstName; set => _firstName = value;}
        public string LastName {get => _lastName; set => _lastName = value;}
        public string PhoneNumber {get => _phoneNumber; set => _phoneNumber = value;}
        public string EmailAddress {get => _emailAddress; set => _emailAddress = value;}
        public int StylistId {get => _stylistId; set => _stylistId = value;}
        public int Id {get => _id;}

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherClient;
                bool idEquality = this.Id.Equals(newClient.Id);
                bool firstNameEquality = this.FirstName.Equals(newClient.FirstName);
                bool lastNameEquality = this.LastName.Equals(newClient.LastName);
                bool phoneNumberEquality = this.PhoneNumber.Equals(newClient.PhoneNumber);
                bool emailAddressEquality = this.EmailAddress.Equals(newClient.EmailAddress);
                bool stylistIdEquality = this.StylistId.Equals(newClient.StylistId);
                return (idEquality && firstNameEquality && lastNameEquality && phoneNumberEquality && emailAddressEquality && stylistIdEquality);
             }
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO clients (first_name, last_name, phone_number, email_address, stylist_id) VALUES (@first_name, @last_name, @phone_number, @email_address, @stylist_id);";
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
            MySqlParameter stylistId = new MySqlParameter();
            stylistId.ParameterName = "@stylist_id";
            stylistId.Value = this.StylistId;
            cmd.Parameters.Add(stylistId);
            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
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
                int clientStylistId = rdr.GetInt32(5);
                Client newClient = new Client(clientFirstName, clientLastName, clientPhoneNumber, clientEmailAddress, clientStylistId, clientId);
                allClients.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allClients;
        }

        public static Client Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE id = @search_id;";
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
            int clientStylistId = 0;
            while(rdr.Read())
            {
              clientId = rdr.GetInt32(0);
              clientFirstName = rdr.GetString(1);
              clientLastName = rdr.GetString(2);
              clientPhoneNumber = rdr.GetString(3);
              clientEmailAddress = rdr.GetString(4);
              clientStylistId = rdr.GetInt32(5);
            }
            Client foundClient = new Client(clientFirstName, clientLastName, clientPhoneNumber, clientEmailAddress, clientStylistId, clientId);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return foundClient;
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
            FirstName = newFirstName;
            LastName = newLastName;
            PhoneNumber = newPhoneNumber;
            EmailAddress = newEmailAddress;
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void DeleteClient()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients WHERE id = @search_id;";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@search_id";
            searchId.Value = Id;
            cmd.Parameters.Add(searchId);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
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
    }
}
