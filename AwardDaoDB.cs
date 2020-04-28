using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;
using System.Data.SqlClient;

namespace Users.DAL
{
    public class AwardDaoDB: IAwardDao
    {
        private string connectionstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True";
        public IEnumerable <Award> GetAwards (int index)
        {
            var result = new List<Award>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetAwardByUser", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", index);
                connection.Open(); //открываем соединение
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    var award = new Award
                    {
                        ID = (int)read["IDAward"],
                        Title = (string)read["Title"]
                    };
                    result.Add(award);
                }
            }
            return result;
        }
        public IEnumerable <Award> GetNeedAwards(int indexUser, string Title)
        {
            var result = new List<Award>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetNeedAwards", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUser", indexUser);
                cmd.Parameters.AddWithValue("@title", Title);
                connection.Open(); //открываем соединение
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    var award = new Award
                    {
                        ID = (int)read["IDAward"],
                        Title = (string)read["Title"]
                    };
                    result.Add(award);
                }
            }
            return result;
        }
        public void AddAward(int index, string Title)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("AddAward", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUser", index);
                cmd.Parameters.AddWithValue("@title", Title);
                connection.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public void RemoveAward (int indexUser, string Title)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("RemoveAward", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUser", indexUser);
                cmd.Parameters.AddWithValue("@title", Title);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
