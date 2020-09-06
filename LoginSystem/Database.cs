using MySql.Data.MySqlClient;
using System.Data;


namespace LoginSystem
{
    /*
         we need to download the mysql connector
         * add the connector to our project
         * ( watch the video to see how ) 
         * create a connection now with mysql
         * open xampp and start mysql & apache
         * go to phpmyadmin and create the users database
         */

        class Database {

            private MySqlConnection connection = new MySqlConnection("server=remotemysql.com;port=3306;username=xMx4SS9LKq;password=HUgTzn0Yez;database=xMx4SS9LKq");
            
            // create a function to open the connection
            public void openConnection()
            {
                if(connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            }

            // create a function to close the connection
            public void closeConnection()
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            // create a function to return the connection
            public MySqlConnection getConnection()
            {
                return connection;
            }
        }
    }