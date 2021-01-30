using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MyFit
{
    class Data_Access
    {
        public int VerifyUser (string email, string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionStringVal("MyFitDB")))
            {
                // NOT GOOD PRACTICE, very susceiptible to SQL injection. Use stored procedures instead
                //return connection.Query<User>($"Select * from User where LastName = '{ lastname }'").ToList(); 

                // Query means search, User is the type, then the sql command and the parameter
                // the new statement is a dynamic class with the property LastName = lastname (our parameter)
                // Dapper takes the LastName property and puts it into the sql command parameter

                /// need to learn how to convert ienumerable to int 
                var output = connection.Query<int>("dbo.VerifyUser @email, @password", new { email = email, password = password }).ToList();

                // Returns the first userID in the list (it will only ever contain one)
                // Will return 0 if there are no users with that email and password combination
                return output.First();
            }   
        }

        public void AddUser (string firstName, string lastName, string email, string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionStringVal("MyFitDB")))
            {
                // Create a list of users since our insert statement can hold multiple records (and is expecting multiple records)
                // Even though we will only be adding one record
                List<User> users = new List<User>();

                // Create a new instance of user and set the properties equal to the AddUser parameters. Add that instane to the list
                users.Add(new User { firstName = firstName, lastName = lastName, email = email, password = password });

                // Executes our stored procedure for every record we have in the users list (only one)
                connection.Execute("dbo.AddUser @FirstName, @LastName, @email, @password", users);
            }

        }

        public int CheckEmail(string email)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionStringVal("MyFitDB")))
            {
                var output = connection.Query<int>("dbo.CheckEmail @email", new { email = email}).ToList();
                return output.First();
            }
        }
    }
}
