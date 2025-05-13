using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public class clsSellsDataAccess
    {
        public static DataTable GetAllSells()
        {
            DataTable dtSell = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetAllSells", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtSell.Load(reader);
                            }
                            else
                                reader.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            return dtSell;
        }
        public static int? AddNewSell(int? CustomerID, int? PurchaseID, float Price, int Quantity, DateTime SellDate, float TotalPrice)
        {
            int? NewSellID = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_AddNewSell", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CustomerID", (object)CustomerID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PurchaseID", (object)PurchaseID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Price", Price);
                        command.Parameters.AddWithValue("@Quantity", Quantity);
                        command.Parameters.AddWithValue("@SellDate", SellDate);
                        command.Parameters.AddWithValue("@TotalPrice", TotalPrice);
                        SqlParameter ReturnVal = new SqlParameter("@NewSellID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(ReturnVal);
                        command.ExecuteNonQuery();
                        NewSellID = (int?)ReturnVal.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            return NewSellID;
        }
        public static bool DeleteSell(int? SellID)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_DeleteSell", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SellID", (object)SellID ?? DBNull.Value);
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
        public static bool UpdateSell(int? SellID, int? CustomerID, int? PurchaseID, float Price, int Quantity, DateTime SellDate, float TotalPrice)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_UpdateSell", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SellID", (object)SellID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CustomerID", (object)CustomerID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CustomerID", (object)PurchaseID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Price", Price);
                        command.Parameters.AddWithValue("@Quantity", Quantity);
                        command.Parameters.AddWithValue("@SellDate", SellDate);
                        command.Parameters.AddWithValue("@TotalPrice", TotalPrice);
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
        public static bool GetSellInfoByID(int? SellID, ref int? CustomerID, ref int? PurchaseID, ref float Price, ref int Quantity, ref DateTime SellDate, ref float TotalPrice)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetSellInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SellID", (object)SellID ?? DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                if (reader["CustomerID"] != null)
                                    CustomerID = (int?)reader["CustomerID"];
                                else
                                    CustomerID = null;

                                if (reader["PurchaseID"] != null)
                                    PurchaseID = (int?)reader["PurchaseID"];
                                else
                                    PurchaseID = null;

                                if (reader["SellDate"] != null)
                                    SellDate = (DateTime)reader["SellDate"];
                                else
                                    SellDate = DateTime.MinValue;

                                Price = reader["Price"] != DBNull.Value ? Convert.ToSingle(reader["Price"]) : 0f;
                                TotalPrice = reader["TotalPrice"] != DBNull.Value ? Convert.ToSingle(reader["TotalPrice"]) : 0f;
                                Quantity = (int)(reader["Quantity"] != DBNull.Value ? Convert.ToSingle(reader["Quantity"]) : 0f);
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
            return clsDataAccessHelper.Count("SP_GetCountOfSells");
        }
    }
}
