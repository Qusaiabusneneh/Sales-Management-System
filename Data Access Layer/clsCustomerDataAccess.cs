using System;
using System.Data;
using System.Data.SqlClient;
namespace Data_Access_Layer
{
    public class clsCustomerDataAccess
    {
        public static DataTable GetAllCustomers()
        {
            DataTable dtCustomer = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetAllCustomers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtCustomer.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            return dtCustomer;
        }
        public static int? AddNewCustomer(string CustomerName, string CustomerPhone, string CustomerEmail, byte[] CustomerImage)
        {
            int? NewCustomerID = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_AddNewCustomer", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CustomerName", CustomerName);
                        command.Parameters.AddWithValue("@CustomerPhone", CustomerPhone);
                        command.Parameters.AddWithValue("@CustomerEmail", CustomerEmail);

                        if (CustomerImage != null)
                            command.Parameters.AddWithValue("@CustomerImage", CustomerImage);
                        else
                            command.Parameters.AddWithValue("@CustomerImage", DBNull.Value);

                        SqlParameter ReturnParam = new SqlParameter("@NewCustomerID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(ReturnParam);
                        command.ExecuteNonQuery();
                        NewCustomerID = (int?)ReturnParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            return NewCustomerID;
        }
        public static bool UpdateCustomer(int? CustomerID, string CustomerName, string CustomerPhone, string CustomerEmail, byte[] CustomerImage)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_UpdateCustomer", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CustomerID", (object)CustomerID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CustomerName", CustomerName);
                        command.Parameters.AddWithValue("@CustomerPhone", CustomerPhone);
                        command.Parameters.AddWithValue("@CustomerEmail", CustomerEmail);

                        if (CustomerImage != null && CustomerImage.Length > 0)
                            command.Parameters.Add("@CustomerImage", SqlDbType.Image, CustomerImage.Length).Value = CustomerImage;
                        else
                            command.Parameters.Add("@CustomerImage", SqlDbType.Image).Value = DBNull.Value;

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
        public static bool DeleteCustomer(int? CustomerID)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_DeleteCustomer", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CustomerID", (object)CustomerID ?? DBNull.Value);
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
        public static bool GetCustomerInfoByID(int? CustomerID, ref string CustomerName, ref string CustomerPhone, ref string CustomerEmail, ref byte[] CustomerImage)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetCustomerInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CustomerID", (object)CustomerID ?? DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                CustomerName = (string)reader["CustomerName"];
                                CustomerPhone = (string)reader["CustomerPhone"];
                                CustomerEmail = (string)reader["CustomerEmail"];

                                if (reader["CustomerImage"] != DBNull.Value)
                                    CustomerImage = (byte[])reader["CustomerImage"];
                                else
                                    CustomerImage = null;
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
        public static bool GetCustomerInfoByName(string CustomerName, ref int? CustomerID, ref string CustomerPhone, ref string CustomerEmail, ref byte[] CustomerImage)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetCustomerInfoByCustomerName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CustomerName", CustomerName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                if (reader["CustomerID"] != DBNull.Value)
                                    CustomerID = (int?)reader["CustomerID"];
                                else
                                    CustomerID = null;

                                CustomerPhone = (string)reader["CustomerPhone"];
                                CustomerEmail = (string)reader["CustomerEmail"];

                                if (reader["CustomerImage"] != DBNull.Value)
                                    CustomerImage = (byte[])reader["CustomerImage"];
                                else
                                    CustomerImage = null;
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
        public static int Count()
        {
            return clsDataAccessHelper.Count("SP_GetCountOfCustomer");
        }
    }
}
