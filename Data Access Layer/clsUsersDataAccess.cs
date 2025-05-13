using System;
using System.Data;
using System.Data.SqlClient;
namespace Data_Access_Layer
{
    public class clsUsersDataAccess
    {
        public static DataTable GetAllUsers()
        {
            DataTable _dtUsers = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetAllUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                _dtUsers.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            return _dtUsers;
        }
        public static int? AddNewUser(string Username, string Password, string UserRoll, string UserState)
        {
            int? NewUserID = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_AddNewUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@UserRoll", UserRoll);
                        command.Parameters.AddWithValue("@UserState", UserState);
                        SqlParameter ReturnParam = new SqlParameter("@NewUserID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(ReturnParam);
                        command.ExecuteNonQuery();
                        NewUserID = (int?)ReturnParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            return NewUserID;
        }
        public static bool GetUserInfoByID(int? UserID, ref string Username, ref string Password, ref string UserRoll, ref string UserState)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetUserInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                Username = (string)reader["Username"];
                                Password = (string)reader["Password"];
                                UserRoll = (string)reader["UserRoll"];
                                UserState = (string)reader["UserState"];
                            }
                            else
                            {
                                isFound = false;
                                reader.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                isFound = false;
                Console.WriteLine("Error : " + ex.Message);
            }
            return isFound;
        }
        public static bool UpdateUser(int? UserID, string Username, string Password, string UserRoll, string UserState)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_UpdateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", (object)UserID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@UserRoll", UserRoll);
                        command.Parameters.AddWithValue("@UserState",UserState);
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            return (RowsAffected > 0);
        }
        public static bool DeleteUser(int? UserID)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_DeleteUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", (object)UserID ?? DBNull.Value);
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            return (RowsAffected > 0);
        }
        public static bool GetUserInfoByUsernameAndPassword(string Username, string Password, ref int? UserID, ref string UserRoll, ref string UserState)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("[SP_GetUserInfoByUsernameAndPassword]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())  // ✅ Ensures data is read before accessing
                            {
                                isFound = true;
                                UserID = reader["UserID"] != DBNull.Value ? (int?)reader["UserID"] : null;
                                UserRoll = reader["UserRoll"] != DBNull.Value ? reader["UserRoll"].ToString() : string.Empty;
                                UserState = reader["UserState"] != DBNull.Value ? reader["UserState"].ToString() : string.Empty;
                            }
                            else
                                isFound = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return isFound;
        }
        public static bool GetUserInfoIfUserStateTrue(string UserState,ref int?UserID,ref string Username,ref string Password,ref string UserRoll)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetUserInfoUserStateInTrue", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserState", UserState);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                if (reader["UserID"] != DBNull.Value)
                                    UserID = (int?)reader["UserID"];

                                Username =(string)reader["Username"];
                                Password = (string)reader["Password"];
                                UserRoll = (string)reader["UserRoll"];
                            }
                            else
                            {
                                isFound = false;
                                reader.Close();
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                isFound = false;
                Console.WriteLine("Error : " + ex.Message);
            }
            return isFound;
        }
        public static int Count()
        {
            return clsDataAccessHelper.Count("SP_GetCountOfUsers");
        }
    }
}
