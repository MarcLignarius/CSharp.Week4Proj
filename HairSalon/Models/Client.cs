using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
    public class Client
    {
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _emailAddress;
        private int _id;
        private int _stylistId;

        public Client (string firstName, string lastName, string phoneNumber, string emailAddress, int stylistId,  int id = 0)
        {
            _firstName = firstName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
            _emailAddress = emailAddress;
            _stylistId = stylistId;
            _id = id;
        }

        public string GetFirstName()
        {
            return _firstName;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public string GetPhoneNumber()
        {
            return _phoneNumber;
        }

        public void SetPhoneNumber(string newPhoneNumber)
        {
            _phoneNumber = newPhoneNumber;
        }

        public string GetEmailAddress()
        {
            return _emailAddress;
        }

        public void SetEmailAddress(string newEmailAddress)
        {
            _emailAddress = newEmailAddress;
        }

        public int GetId()
        {
            return _id;
        }

        public int GetStylistId()
        {
            return _stylistId;
        }

        public static List<Client> GetAll()
        {
            List<Client> allClients = new List<Client> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients ORDER BY last_name;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientFirstName = rdr.GetString(1);
                string clientLastName = rdr.GetString(2);
                string clientPhoneNumber = rdr.GetString(3);
                string clientEmailAddress = rdr.GetString(4);
                int clientStylistId = rdr.GetInt32(5);
                Client newClient = new Client(clientFirstName, clientLastName, clientPhoneNumber, clientEmailAddress, clientStylistId);
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
            cmd.CommandText = @"SELECT * FROM clients WHERE id = (@searchId);";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
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
            Client newClient = new Client(clientFirstName, clientLastName, clientPhoneNumber, clientEmailAddress, clientStylistId, clientId);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newClient;
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
                bool idEquality = this.GetId() == newClient.GetId();
                bool firstNameEquality = this.GetFirstName() == newClient.GetFirstName();
                bool lastNameEquality = this.GetLastName() == newClient.GetLastName();
                bool phoneNumberEquality = this.GetPhoneNumber() == newClient.GetPhoneNumber();
                bool emailAddressEquality = this.GetEmailAddress() == newClient.GetEmailAddress();
                bool stylistEquality = this.GetStylistId() == newClient.GetStylistId();
                return (idEquality && firstNameEquality && lastNameEquality && phoneNumberEquality && emailAddressEquality && stylistEquality);
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
            firstName.Value = this._firstName;
            cmd.Parameters.Add(firstName);
            MySqlParameter lastName = new MySqlParameter();
            lastName.ParameterName = "@last_name";
            lastName.Value = this._lastName;
            cmd.Parameters.Add(lastName);
            MySqlParameter phoneNumber = new MySqlParameter();
            phoneNumber.ParameterName = "@phone_number";
            phoneNumber.Value = this._phoneNumber;
            cmd.Parameters.Add(phoneNumber);
            MySqlParameter emailAddress = new MySqlParameter();
            emailAddress.ParameterName = "@email_address";
            emailAddress.Value = this._emailAddress;
            cmd.Parameters.Add(emailAddress);
            MySqlParameter stylistId = new MySqlParameter();
            stylistId.ParameterName = "@stylist_id";
            stylistId.Value = this._stylistId;
            cmd.Parameters.Add(stylistId);
            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Edit(string newPhoneNumber, string newEmailAddress)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE clients SET phone_number = @new_phone_number, email_address = @new_email_address WHERE id = @search_id;";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@search_id";
            searchId.Value = _id;
            cmd.Parameters.Add(searchId);
            MySqlParameter phoneNumber = new MySqlParameter();
            phoneNumber.ParameterName = "@new_phone_number";
            phoneNumber.Value = newPhoneNumber;
            cmd.Parameters.Add(phoneNumber);
            MySqlParameter emailAddress = new MySqlParameter();
            emailAddress.ParameterName = "@new_email_address";
            emailAddress.Value = newEmailAddress;
            cmd.Parameters.Add(emailAddress);
            cmd.ExecuteNonQuery();
            _phoneNumber = newPhoneNumber;
            _emailAddress = newEmailAddress;
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
            cmd.CommandText = @"DELETE FROM clients WHERE id = @search_id;";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@search_id";
            searchId.Value = _id;
            cmd.Parameters.Add(searchId);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
