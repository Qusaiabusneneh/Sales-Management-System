using Data_Access_Layer;
using System.Data;

namespace Busniess_Layer
{
    public class clsCustomers
    {
        private enum enMode { enAdd, enUpdate }
        private enMode _Mode;
        public int? CustomerID { set; get; }
        public string CustomerName { set; get; }
        public string CustomerPhone { set; get; }
        public string CustomerEmail { set; get; }
        public byte[] CustomerImage { set; get; }
        public clsCustomers()
        {
            CustomerID = null;
            CustomerName = string.Empty;
            CustomerPhone = string.Empty;
            CustomerEmail = string.Empty;
            CustomerImage = null;
            _Mode = enMode.enAdd;
        }
        public clsCustomers(int? customerID, string customerName, string customerPhone, string customerEmail, byte[] customerImage)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            CustomerPhone = customerPhone;
            CustomerEmail = customerEmail;
            CustomerImage = customerImage;
            _Mode = enMode.enUpdate;
        }
        public static DataTable GetAllCustomers()
        {
            return clsCustomerDataAccess.GetAllCustomers();
        }
        private bool _AddNewCustomer()
        {
            this.CustomerID = clsCustomerDataAccess.AddNewCustomer(this.CustomerName, this.CustomerPhone, this.CustomerEmail, this.CustomerImage);
            return (this.CustomerID != null);
        }
        private bool _UpdateCustomer()
        {
            return clsCustomerDataAccess.UpdateCustomer(this.CustomerID, this.CustomerName, this.CustomerPhone, this.CustomerEmail, this.CustomerImage);
        }
        public bool Save()

        {
            switch (_Mode)
            {
                case enMode.enAdd:
                    {
                        if (_AddNewCustomer())
                        {
                            _Mode = enMode.enUpdate;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.enUpdate:
                    {
                        return _UpdateCustomer();
                    }
            }
            return false;
        }
        public static bool DeleteCustomer(int? CustomerID)
        {
            return clsCustomerDataAccess.DeleteCustomer(CustomerID);
        }
        public static clsCustomers Find(int? CustomerID)
        {
            string CustomerName = string.Empty, CustomerPhone = string.Empty, CustomerEmail = string.Empty;
            byte[] CustomerImage = null;
            bool isFound = clsCustomerDataAccess.GetCustomerInfoByID(CustomerID, ref CustomerName, ref CustomerPhone, ref CustomerEmail, ref CustomerImage);
            if (isFound)
                return new clsCustomers(CustomerID, CustomerName, CustomerPhone, CustomerPhone, CustomerImage);
            else
                return null;
        }

        public static clsCustomers Find(string CustomerName)
        {
            int? CustomerID = null;
            string CustomerPhone = string.Empty, CustomerEmail = string.Empty;
            byte[] CustomerImage = null;
            bool isFound = clsCustomerDataAccess.GetCustomerInfoByName(CustomerName, ref CustomerID, ref CustomerPhone, ref CustomerEmail, ref CustomerImage);
            if (isFound)
                return new clsCustomers(CustomerID, CustomerName, CustomerPhone, CustomerPhone, CustomerImage);
            else
                return null;
        }
        public static int Count()
        {
            return clsCustomerDataAccess.Count();
        }
    }
}
