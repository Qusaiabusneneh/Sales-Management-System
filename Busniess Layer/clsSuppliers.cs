using Data_Access_Layer;
using System.Data;

namespace Busniess_Layer
{
    public class clsSuppliers
    {
        private enum enMode { enAddNew, enUpdate };
        private enMode _Mode;
        public int? SupplierID { private set; get; }
        public string SupplierName { set; get; }
        public string SupplierPhone { set; get; }
        public string SupplierEmail { set; get; }
        public byte[] SupplierImage { set; get; }
        public clsSuppliers(int? SupplierID, string SupplierName, string SupplierPhone, string SupplierEmail, byte[] SupplierImage)
        {
            this.SupplierID = SupplierID;
            this.SupplierName = SupplierName;
            this.SupplierPhone = SupplierPhone;
            this.SupplierEmail = SupplierEmail;
            this.SupplierImage = SupplierImage;
            _Mode = enMode.enUpdate;
        }
        public clsSuppliers()
        {
            SupplierID = null;
            SupplierName = string.Empty;
            SupplierPhone = string.Empty;
            SupplierEmail = string.Empty;
            SupplierImage = null;
            _Mode = enMode.enAddNew;
        }
        public static DataTable GetAllSuppliers()
        {
            return clsSupplierDataAccess.GetAllSuppliers();
        }
        private bool _AddNewSuppplier()
        {
            this.SupplierID = clsSupplierDataAccess.AddNewSupplier(this.SupplierName, this.SupplierPhone, this.SupplierEmail, this.SupplierImage);
            return (this.SupplierID.HasValue);
        }
        private bool _UpdateSupplier()
        {
            return clsSupplierDataAccess.UpdateSupplier(this.SupplierID, this.SupplierName, this.SupplierPhone, this.SupplierEmail, this.SupplierImage);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAddNew:
                    {
                        if (_AddNewSuppplier())
                        {
                            _Mode = enMode.enUpdate;
                            return true;
                        }
                        else
                            return false;
                    }

                case enMode.enUpdate:
                    return _UpdateSupplier();
            }
            return false;
        }
        public static bool DeleteSupplier(int? SupplierID)
        {
            return clsSupplierDataAccess.DeleteSupplier(SupplierID);
        }
        public static clsSuppliers Find(int? SupplierID)
        {
            string SupplierName = string.Empty, SupplierPhone = string.Empty, SupplierEmail = string.Empty;
            byte[] SupplierImage = null;
            bool isFound = clsSupplierDataAccess.GetSupplierInfo(SupplierID, ref SupplierName, ref SupplierPhone, ref SupplierEmail, ref SupplierImage);
            if (isFound)
                return new clsSuppliers(SupplierID, SupplierName, SupplierPhone, SupplierEmail, SupplierImage);
            else
                return null;
        }
        public static clsSuppliers Find(string SupplierName)
        {
            int? SupplierID = null;
            string SupplierPhone = string.Empty, SupplierEmail = string.Empty;
            byte[] SupplierImage = null;
            bool isFound = clsSupplierDataAccess.GetSupplierInfo(SupplierName, ref SupplierID, ref SupplierPhone, ref SupplierEmail, ref SupplierImage);
            if (isFound)
                return new clsSuppliers(SupplierID, SupplierName, SupplierPhone, SupplierEmail, SupplierImage);
            else
                return null;
        }
        public static int Count()
        {
            return clsSupplierDataAccess.Count();
        }

    }
}
