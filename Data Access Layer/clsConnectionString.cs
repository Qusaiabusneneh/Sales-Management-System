using System.Configuration;
namespace Data_Access_Layer
{
    public class clsConnectionString
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    }
}
