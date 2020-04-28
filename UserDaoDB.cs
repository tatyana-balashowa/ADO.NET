using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;

namespace Users.DAL
{
    public class UserDaoDB : IUserDao
    {
        private string connectionstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True";
        public IEnumerable <User> GetUsers ()
        {
            var result = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open(); //открываем соединение
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    var user = new User
                    {
                        ID = (int)read["IDUser"],
                        Name = (string)read["Name"],
                        DateOfBirth = (DateTime)read["DateOfBirth"],
                        Age = (int)read["Age"]
                    };
                    result.Add(user);
                }
            }
            return result;
        }
        public IEnumerable <User> GetNeedUsers(int index)
        {
            var result = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetDeletedUsers", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", index);
                connection.Open(); //открываем соединение
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    var user = new User
                    {
                        ID = (int)read["IDUser"],
                        Name = (string)read["Name"],
                        DateOfBirth = (DateTime)read["DateOfBirth"],
                        Age = (int)read["Age"]
                    };
                    result.Add(user);
                }
            }
            return result;
        }
        public void AddUser (User user)
        {
            using (SqlConnection connection = new SqlConnection (connectionstring))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "AddUser";

                var parameterName = command.CreateParameter();
                parameterName.DbType = System.Data.DbType.String;
                parameterName.Value = user.Name;
                parameterName.ParameterName = "@Name";
                command.Parameters.Add(parameterName);

                var parameterDateOfBirth = command.CreateParameter();
                parameterDateOfBirth.DbType = System.Data.DbType.DateTime;
                parameterDateOfBirth.Value = user.DateOfBirth;
                parameterDateOfBirth.ParameterName = "@DateOfBirth";
                command.Parameters.Add(parameterDateOfBirth);

                var parameterAge = command.CreateParameter();
                parameterAge.DbType = System.Data.DbType.Int32;
                parameterAge.Value = user.Age;
                parameterAge.ParameterName = "@Age";
                command.Parameters.Add(parameterAge);

                connection.Open();

                command.ExecuteNonQuery();

            }

        }
        public void RemoveUser (int index)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("RemoveUser", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", index);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
