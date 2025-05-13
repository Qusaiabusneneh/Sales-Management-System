using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public class clsSupplierDataAccess
    {
        public static DataTable GetAllSuppliers()
        {
            DataTable dtSuppliers = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetAllSuppliers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtSuppliers.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            return dtSuppliers;
        }
        public static int? AddNewSupplier(string SupplierName, string SuppplierPhone, string SupplierEmail, byte[] SupplierImage)
        {
            int? NewSupplierID = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_AddNewSupplier", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SupplierName", SupplierName);
                        command.Parameters.AddWithValue("@SuppplierPhone", SuppplierPhone);
                        command.Parameters.AddWithValue("@SupplierEmail", SupplierEmail);

                        // Handle null for supplierImage
                        if (SupplierImage != null)
                        {
                            command.Parameters.AddWithValue("@SupplierImage", SupplierImage);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@SupplierImage", DBNull.Value);
                        }

                        SqlParameter ReturnParam = new SqlParameter("@NewSupplierID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(ReturnParam);
                        command.ExecuteNonQuery();
                        NewSupplierID = (int?)ReturnParam.Value;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            return NewSupplierID;
        }
        public static bool UpdateSupplier(int? SupplierID, string SupplierName, string SupplierPhone, string SupplierEmail, byte[] SupplierImage)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_UpdateSupplierInfo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SupplierID", (object)SupplierID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SupplierName", SupplierName);
                        command.Parameters.AddWithValue("@SupplierPhone", SupplierPhone);
                        command.Parameters.AddWithValue("@SupplierEmail", SupplierEmail);

                        if (SupplierImage != null && SupplierImage.Length > 0)
                            command.Parameters.Add("@SupplierImage", SqlDbType.Image, SupplierImage.Length).Value = SupplierImage;
                        else
                            command.Parameters.Add("@SupplierImage", SqlDbType.Image).Value = DBNull.Value;

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
        public static bool DeleteSupplier(int? SupplierID)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_DeleteSupplier", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SupplierID", (object)SupplierID ?? DBNull.Value);
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
        public static bool GetSupplierInfo(int? SupplierID, ref string SupplierName, ref string SupplierPhone, ref string SupplierEmail,
            ref byte[] SupplierImage)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetSupplierInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SupplierID", SupplierID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                SupplierName = (string)reader["SupplierName"];
                                SupplierPhone = (string)reader["SupplierPhone"];
                                SupplierEmail = (string)reader["SupplierEmail"];
                                if (reader["SupplierImage"] != DBNull.Value)
                                    SupplierImage = (byte[])reader["SupplierImage"];
                                else
                                    SupplierImage = null;
                            }
                            else
                                reader.Close();
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
        public static bool GetSupplierInfo(string SupplierName, ref int? SupplierID, ref string SupplierPhone, ref string SupplierEmail,
            ref byte[] SupplierImage)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetSupplierInfoBySupplierName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SupplierName", SupplierName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                SupplierID = (reader["SupplierID"] != DBNull.Value ? (int?)reader["SupplierID"] : null);

                                SupplierPhone = (string)reader["SupplierPhone"];
                                SupplierEmail = (string)reader["SupplierEmail"];

                                if (reader["SupplierImage"] != DBNull.Value)
                                    SupplierImage = (byte[])reader["SupplierImage"];
                                else
                                    SupplierImage = null;
                            }
                            else
                                reader.Close();
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
            return clsDataAccessHelper.Count("SP_GetCountOfSuppliers");
        }

    }
}
