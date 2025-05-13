using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public class clsCategoryDataAccess
    {
        public static DataTable GetAllCategories()
        {
            DataTable _dtCategory = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetAllCategories", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                _dtCategory.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _dtCategory;
        }
        public static int? AddNewCategory(string CategoryName, byte[] categoryImage)
        {
            int? NewCategoryID = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_AddNewCategory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CategoryName", CategoryName);

                        // Handle null for categoryImage
                        if (categoryImage != null && categoryImage.Length > 0)
                        {
                            command.Parameters.Add("@categoryImage", SqlDbType.Image, categoryImage.Length).Value = categoryImage;
                        }
                        else
                        {
                            command.Parameters.Add("@categoryImage", SqlDbType.Image).Value = DBNull.Value;
                        }

                        SqlParameter ReturnParam = new SqlParameter("@NewCategoryID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(ReturnParam);
                        command.ExecuteNonQuery();
                        NewCategoryID = (int?)ReturnParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return NewCategoryID;
        }
        public static bool DeleteCategory(int? CategoryID)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_DeleteCategory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CategoryID", (object)CategoryID ?? DBNull.Value);
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
        public static bool UpdateCategory(int? CategoryID, string CategoryName, byte[] CategoryImage)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_UpdateCategory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CategoryID", (object)CategoryID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CategoryName", CategoryName);

                        if (CategoryImage != null && CategoryImage.Length > 0)
                            command.Parameters.Add("@CategoryImage", SqlDbType.Image, CategoryImage.Length).Value = CategoryImage;
                        else
                            command.Parameters.Add("@CategoryImage", SqlDbType.Image).Value = DBNull.Value;

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
        public static bool GetCategoryInfoByID(int? CategoryID, ref string CategoryName, ref byte[] CategoryImage)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetCategoryInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CategoryID", (object)CategoryID ?? DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                CategoryName = (string)reader["CategoryName"];

                                if (reader["CategoryImage"] != DBNull.Value)
                                    CategoryImage = (byte[])reader["CategoryImage"];
                                else
                                    CategoryImage = null;
                            }
                            else
                                reader.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error + : " + ex.Message);
            }
            return isFound;
        }
        public static bool GetCategoryInfoByCategoryName(string CategoryName, ref int? CategoryID, ref byte[] CategoryImage)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_GetCategoryInfoByCategoryName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CategoryName", CategoryName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                CategoryID = (reader["ID"] != DBNull.Value ? (int?)reader["ID"] : null);

                                if (reader["CategoryImage"] != DBNull.Value)
                                    CategoryImage = (byte[])reader["CategoryImage"];
                                else
                                    CategoryImage = null;
                            }
                            else
                                reader.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error + : " + ex.Message);
            }
            return isFound;
        }
        public static int Count()
        {
            return clsDataAccessHelper.Count("SP_GetCountOfCategories");
        }
    }
}
