using System.Data.SqlClient;

namespace Database
{
    public class Repository : IRepository
    {
        String _conStr = string.Empty;

        public Repository(String ConnectionString)
        {
            _conStr = ConnectionString;
        }

        public void addUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(_conStr))
            {
                String queryString =
                    @"INSERT INTO SOFT806.dbo.Users (ID, Login, Password)
                    VALUES (NEWID(), @Login, HASHBYTES('SHA2_512',@Password))";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Login", user.Login);
                command.Parameters.AddWithValue("@Password", user.Password);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool Login(User user)
        {
            Boolean result = false;

            using (SqlConnection connection = new SqlConnection(_conStr))
            {
                String queryString =
                    @"SELECT TOP 1 
                        Users.ID, 
                        Users.Login, 
                        Users.Password 
                    FROM 
                        SOFT806.dbo.Users AS Users
                    WHERE 
	                    Users.Login = @Login AND HASHBYTES('SHA2_512',@Password) = Users.Password";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Login", user.Login);
                command.Parameters.AddWithValue("@Password", user.Password);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result = true;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return result;
        }

        public User? getUserByLogin(string Login)
        {
            User? user = null;

            using (SqlConnection connection = new SqlConnection(_conStr))
            {
                String queryString =
                    @"SELECT TOP 1 
                        Users.ID, 
                        Users.Login, 
                        Users.Password 
                    FROM 
                        SOFT806.dbo.Users AS Users
                    WHERE 
	                    Users.Login = @Login;";

                SqlCommand com = new SqlCommand(queryString, connection);
                com.Parameters.AddWithValue("@Login", Login);

                try
                {
                    connection.Open();
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new User();
                        user.ID = (Guid)reader["ID"];
                        user.Login = (String)reader["Login"];
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return user;
        }
    }
}
