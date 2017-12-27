using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using TaskAPI.DataAccess;
using TaskAPI.Models;


namespace TaskAPI.DataAccess
{
    //public class UserData : IUserData
    public class UserData
    {
        private SqlConnectionStringBuilder cb;

        public UserData()
        {
            cb = new SqlConnectionStringBuilder();
            cb.DataSource = "nicholas-apps.database.windows.net";
            cb.UserID = "nicholas";
            cb.Password = "Okamicat1234";
            cb.InitialCatalog = "Todos";
        }

        //public List<User> GetAll()
        public List<string[]> GetAll()
        {

            DataTable dt = new DataTable();
            var userList = new List<string[]>();
            using (SqlConnection connection = new SqlConnection(cb.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM [User]";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connection;
                    connection.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);                        
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        string id = row["ID"].ToString();
                        string name = row["NAME"].ToString();
                        userList.Add(new string[] { id, name });
                    }

                    connection.Close();
                }

                return userList;
            }
        }

        public User GetOne(int id)
        {
            DataTable dt = new DataTable();
            User user = new User(); 
            using (SqlConnection connection = new SqlConnection(cb.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = $"SELECT * FROM [User] Where ID ={id}";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connection;
                    connection.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    user.Id = (int)dt.Rows[0]["ID"];
                    user.Name = dt.Rows[0]["NAME"].ToString();


                    connection.Close();
                }
                return user;
            }    
        }

        public User Create(string name, string password)
        {
            try
            {
                DataTable dt = new DataTable();
                User user = new User();
                using (SqlConnection connection = new SqlConnection(cb.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = $"INSERT INTO [User] (NAME, PASSWORD) VALUES ({name}, {password})";
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Connection = connection;

                        connection.Open();

                        user = (User)cmd.ExecuteScalar();





                        connection.Close();
                    }
                }
                return user;
            }
            catch (Exception ex)
            {
                var exception = ex;
                throw;
            }

        }

    }
}
