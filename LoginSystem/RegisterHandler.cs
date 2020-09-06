using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace LoginSystem {
    
    public class RegisterHandler {
        
        public void Register() {
            Profile profile = new Profile();
            string confirmpassword;

            Console.WriteLine("Register \n\n\n\n");
            
            Console.Write("Username: ");
            profile.username = Console.ReadLine();
            
            Console.Write("\nPassword: ");
            profile.password = Console.ReadLine();
            
            Console.Write("\nConfirm Password: ");
            confirmpassword = Console.ReadLine();
            
            Database database = new Database();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`username`, `password`) VALUES (@usn, @pass)", database.getConnection());
            
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = profile.username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = profile.password;
            
            database.openConnection();

            if (profile.password == confirmpassword) {
                if (checkUsername()) {
                    Console.WriteLine("Username already exists");
                } else {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        Console.WriteLine("Your account has been created.");
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }
            } else {
                Console.WriteLine("Wrong Confirmation Password");
            }
            database.closeConnection();
            
            // Checks if the username already exists
            Boolean checkUsername() { 
                Database database = new Database();

                String username = profile.username;

                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn", database.getConnection());

                command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;

                adapter.SelectCommand = command;

                adapter.Fill(table);

                // check if this username already exists in the database
                if (table.Rows.Count > 0) {
                    return true;
                } else {
                    return false;
                }
            }
        }
    }
}