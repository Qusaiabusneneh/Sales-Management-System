using System.IO;
namespace Busniess_Layer
{
    public class clsMethods
    {
        public static MemoryStream ma = new MemoryStream();
        public static byte[] by;

        public byte[] ConvertImageToByte()
        {
            return ma.ToArray();
        }

        public MemoryStream ConvertByteToImage()
        {
            if (by != null && by.Length > 0)
            {
                ma = new MemoryStream(by);
                return ma;
            }
            else
                return new MemoryStream(new byte[0]);   // Return an empty MemoryStream instead of null
        }
    }
}
