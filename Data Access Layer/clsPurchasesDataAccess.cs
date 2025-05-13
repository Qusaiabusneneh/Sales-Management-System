using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public class clsPurchasesDataAccess
    {
        public static DataTable GetAllPurchase()
        {
            DataTable dtPurchase = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetAllPurchases", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtPurchase.Load(reader);
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
            return dtPurchase;
        }
        public static int? AddNewPurchase(int? CategoryID, int? SupplierID, string PurchaseName, string PurchaseType, string PurchaseDetails,
                                        float PurchaseBuy, float PurchaseSell, float PurchaseQuantity, float PurchaseTotalSell,
                                        float PurchaseTotalBuy, float PurchaseTotalEarnings)
        {
            int? NewPurchaseID = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_AddNewPurchases", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CategoryID", (object)CategoryID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SupplierID", (object)SupplierID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PurchaseName", PurchaseName);
                        command.Parameters.AddWithValue("@PurchaseType", PurchaseType);
                        command.Parameters.AddWithValue("@PurchaseDetails", PurchaseDetails);
                        command.Parameters.AddWithValue("@PurchaseBuy", PurchaseBuy);
                        command.Parameters.AddWithValue("@PurchaseSell", PurchaseSell);
                        command.Parameters.AddWithValue("@PurchaseQuantity", PurchaseQuantity);
                        command.Parameters.AddWithValue("@PurchaseTotalSell", PurchaseTotalSell);
                        command.Parameters.AddWithValue("@PurchaseTotalBuy", PurchaseTotalBuy);
                        command.Parameters.AddWithValue("@PurchaseTotalEarnings", PurchaseTotalEarnings);
                        SqlParameter ReturnVal = new SqlParameter("@NewPurchaseID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(ReturnVal);
                        command.ExecuteNonQuery();
                        NewPurchaseID = (int?)ReturnVal.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            return NewPurchaseID;
        }
        public static bool UpdatePurchase(int? PurchaseID, int? CategoryID, int? SupplierID, string PurchaseName, string PurchaseType, string PurchaseDetails,
                                        float PurchaseBuy, float PurchaseSell, float PurchaseQuantity, float PurchaseTotalSell,
                                        float PurchaseTotalBuy, float PurchaseTotalEarnings)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_UpdatePurchase", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PurchaseID", (object)PurchaseID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CategoryID", (object)CategoryID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SupplierID", (object)SupplierID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PurchaseName", PurchaseName);
                        command.Parameters.AddWithValue("@PurchaseType", PurchaseType);
                        command.Parameters.AddWithValue("@PurchaseDetails", PurchaseDetails);
                        command.Parameters.AddWithValue("@PurchaseBuy", PurchaseBuy);
                        command.Parameters.AddWithValue("@PurchaseSell", PurchaseSell);
                        command.Parameters.AddWithValue("@PurchaseQuantity", PurchaseQuantity);
                        command.Parameters.AddWithValue("@PurchaseTotalSell", PurchaseTotalSell);
                        command.Parameters.AddWithValue("@PurchaseTotalBuy", PurchaseTotalBuy);
                        command.Parameters.AddWithValue("@PurchaseTotalEarnings", PurchaseTotalEarnings);
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
        public static bool DeletePurchase(int? PurchaseID)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_DeletePurchase", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PurchaseID", (object)PurchaseID ?? DBNull.Value);
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
        public static bool GetPurchaseInfoByID(int? PurchaseID, ref int? CategoryID, ref int? SupplierID, ref string PurchaseName, ref string PurchaseType,
                                                ref string PurchaseDetails, ref float PurchaseBuy, ref float PurchaseSell, ref float PurchaseQuantity,
                                                ref float purchaseTotalSell, ref float PurchaseTotalBuy, ref float PurchaseTotalEarnings)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetPurchaseInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PurchaseID", (object)PurchaseID ?? DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                // Handle nullable integers
                                if (reader["CategoryID"] != DBNull.Value)
                                    CategoryID = (int?)reader["CategoryID"];
                                else
                                    CategoryID = null;

                                if (reader["SupplierID"] != DBNull.Value)
                                    SupplierID = (int?)reader["SupplierID"];
                                else
                                    SupplierID = null;

                                // Handle strings with null check
                                PurchaseName = reader["PurchaseName"] != DBNull.Value ? reader["PurchaseName"].ToString() : string.Empty;
                                PurchaseType = reader["PurchaseType"] != DBNull.Value ? reader["PurchaseType"].ToString() : string.Empty;
                                PurchaseDetails = reader["PurchaseDetails"] != DBNull.Value ? reader["PurchaseDetails"].ToString() : string.Empty;

                                // Handle float values with safe conversion
                                PurchaseBuy = reader["PurchaseBuy"] != DBNull.Value ? Convert.ToSingle(reader["PurchaseBuy"]) : 0f;
                                PurchaseSell = reader["PurchaseSell"] != DBNull.Value ? Convert.ToSingle(reader["PurchaseSell"]) : 0f;
                                PurchaseQuantity = reader["PurchaseQuantity"] != DBNull.Value ? Convert.ToSingle(reader["PurchaseQuantity"]) : 0f;
                                purchaseTotalSell = reader["purchaseTotalSell"] != DBNull.Value ? Convert.ToSingle(reader["purchaseTotalSell"]) : 0f;
                                PurchaseTotalBuy = reader["PurchaseTotalBuy"] != DBNull.Value ? Convert.ToSingle(reader["PurchaseTotalBuy"]) : 0f;
                                PurchaseTotalEarnings = reader["PurchaseTotalEarnings"] != DBNull.Value ? Convert.ToSingle(reader["PurchaseTotalEarnings"]) : 0f;
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

        public static bool GetPurchaseInfoByPurchaseName(string PurchaseName, ref int? PurchasesID, ref int? CategoryID, ref int? SupplierID, ref string PurchaseType,
                                        ref string PurchaseDetails, ref float PurchaseBuy, ref float PurchaseSell, ref float PurchaseQuantity,
                                        ref float purchaseTotalSell, ref float PurchaseTotalBuy, ref float PurchaseTotalEarnings)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetPurchaseInfoByPurchaseName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PurchaseName", PurchaseName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                // Handle nullable integers

                                if (reader["PurchasesID"] != DBNull.Value)
                                    PurchasesID = (int?)reader["PurchasesID"];
                                else
                                    PurchasesID = null;

                                if (reader["CategoryID"] != DBNull.Value)
                                    CategoryID = (int?)reader["CategoryID"];
                                else
                                    CategoryID = null;

                                if (reader["SupplierID"] != DBNull.Value)
                                    SupplierID = (int?)reader["SupplierID"];
                                else
                                    SupplierID = null;

                                // Handle strings with null check
                                PurchaseType = reader["PurchaseType"] != DBNull.Value ? reader["PurchaseType"].ToString() : string.Empty;
                                PurchaseDetails = reader["PurchaseDetails"] != DBNull.Value ? reader["PurchaseDetails"].ToString() : string.Empty;

                                // Handle float values with safe conversion
                                PurchaseBuy = reader["PurchaseBuy"] != DBNull.Value ? Convert.ToSingle(reader["PurchaseBuy"]) : 0f;
                                PurchaseSell = reader["PurchaseSell"] != DBNull.Value ? Convert.ToSingle(reader["PurchaseSell"]) : 0f;
                                PurchaseQuantity = reader["PurchaseQuantity"] != DBNull.Value ? Convert.ToSingle(reader["PurchaseQuantity"]) : 0f;
                                purchaseTotalSell = reader["purchaseTotalSell"] != DBNull.Value ? Convert.ToSingle(reader["purchaseTotalSell"]) : 0f;
                                PurchaseTotalBuy = reader["PurchaseTotalBuy"] != DBNull.Value ? Convert.ToSingle(reader["PurchaseTotalBuy"]) : 0f;
                                PurchaseTotalEarnings = reader["PurchaseTotalEarnings"] != DBNull.Value ? Convert.ToSingle(reader["PurchaseTotalEarnings"]) : 0f;
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
            return clsDataAccessHelper.Count("SP_GetCountOfPurchases");
        }
    }
}
