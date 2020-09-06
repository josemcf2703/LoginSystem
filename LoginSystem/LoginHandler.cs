using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace LoginSystem {
    public class LoginHandler {
        
        public void Login() {
            Database database = new Database();
            Profile profile = new Profile();
            
            Console.WriteLine("Login");
            
            Console.Write("Username: ");
            profile.username = Console.ReadLine();
            
            Console.Write("\nPassword: ");
            profile.password = Console.ReadLine();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //Selects the database
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn and `password` = @pass", database.getConnection());

            //Inserts the username and password into the database.
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = profile.username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = profile.password;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            // Checks if the user already exists.
            if (table.Rows.Count > 0) {
                Console.WriteLine("noice one!");
            } else {
                if(profile.username.Trim().Equals("")) {
                    Console.WriteLine("Enter your username to login.");
                } else if (profile.password.Trim().Equals("")) {
                    Console.WriteLine("Enter your password to login.");
                } else {
                    Console.WriteLine("Error: Username or Password might be wrong.");
                }
            }
        }
    }
}