using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class clsDataAccessHelper
    {
        public static int Count(string StoredPorcedure)
        {
            int counter = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(StoredPorcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int value))
                            counter = value;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            return counter;
        }
        public static string ComputeHashing(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashByte = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashByte).Replace("-", "").ToLower();
            }
        }
    }
}
