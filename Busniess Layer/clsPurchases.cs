using Data_Access_Layer;
using System.Data;

namespace Busniess_Layer
{
    public class clsPurchases
    {
        private enum enMode { enAddNew, enUpdate }
        private enMode _Mode;
        public int? PurchaseID { set; get; }
        public int? CategoryID { set; get; }
        public int? SupplierID { set; get; }
        public string PurchaseName { set; get; }
        public string PurchaseType { set; get; }
        public string PurchaseDetails { set; get; }
        public float PurchaseBuy { set; get; }
        public float PurchaseSell { set; get; }
        public float PurchaseQuantity { set; get; }
        public float PurchaseTotalSell { set; get; }
        public float PurchaseTotalBuy { set; get; }
        public float PurchaseTotalEarnings { set; get; }
        public clsCategory selectedCategoryInfo { set; get; }
        public clsSuppliers selectedSupplierInfo { set; get; }
        public clsPurchases()
        {
            this.PurchaseID = null;
            this.CategoryID = null;
            this.SupplierID = null;
            this.PurchaseName = string.Empty;
            this.PurchaseType = string.Empty;
            this.PurchaseDetails = string.Empty;
            this.PurchaseBuy = 0;
            this.PurchaseSell = 0;
            this.PurchaseQuantity = 0;
            this.PurchaseTotalSell = 0;
            this.PurchaseTotalBuy = 0;
            this.PurchaseTotalEarnings = 0;
            _Mode = enMode.enAddNew;
        }
        public clsPurchases(int? purchaseID, int? categoryID, int? supplierID, string purchaseName, string purchaseType, string purchaseDetails,
            float purchaseBuy, float purchaseSell, float purchaseQuantity, float purchaseTotalSell, float purchaseTotalBuy, float purchaseTotalEarnings)
        {
            PurchaseID = purchaseID;
            CategoryID = categoryID;
            SupplierID = supplierID;
            PurchaseName = purchaseName;
            PurchaseType = purchaseType;
            PurchaseDetails = purchaseDetails;
            PurchaseBuy = purchaseBuy;
            PurchaseSell = purchaseSell;
            PurchaseQuantity = purchaseQuantity;
            PurchaseTotalSell = purchaseTotalSell;
            PurchaseTotalBuy = purchaseTotalBuy;
            PurchaseTotalEarnings = purchaseTotalEarnings;
            this.selectedCategoryInfo = clsCategory.Find(categoryID);
            this.selectedSupplierInfo = clsSuppliers.Find(supplierID);
            _Mode = enMode.enUpdate;
        }
        public static DataTable GetAllPurchases()
        {
            return clsPurchasesDataAccess.GetAllPurchase();
        }
        private bool _AddNewPurchase()
        {
            this.PurchaseID = clsPurchasesDataAccess.AddNewPurchase(this.CategoryID, this.SupplierID, this.PurchaseName, this.PurchaseType, this.PurchaseDetails,
                this.PurchaseBuy, this.PurchaseSell, this.PurchaseQuantity, this.PurchaseTotalSell, this.PurchaseTotalBuy, this.PurchaseTotalEarnings);
            return (this.PurchaseID.HasValue);
        }
        private bool _UpdatePruchase()
        {
            return clsPurchasesDataAccess.UpdatePurchase(this.PurchaseID, this.CategoryID, this.SupplierID, this.PurchaseName, this.PurchaseType,
                                                        this.PurchaseDetails, this.PurchaseBuy, this.PurchaseSell, this.PurchaseQuantity,
                                                        this.PurchaseTotalSell, this.PurchaseTotalBuy, this.PurchaseTotalEarnings);
        }
        public static bool DeletePurchase(int? PurchaseID)
        {
            return clsPurchasesDataAccess.DeletePurchase(PurchaseID);
        }
        public static clsPurchases Find(int? PurchaseID)
        {
            int? SupplierID = null;
            int? CategoryID = null;
            string purchaseName = string.Empty, purchaseType = string.Empty, purchaseDetails = string.Empty;
            float purchaseBuy = 0, purchaseSell = 0, purchaseQuantity = 0, purchaseTotalSell = 0, purchaseTotalBuy = 0, purchaseTotalEarnings = 0;
            bool isFound = clsPurchasesDataAccess.GetPurchaseInfoByID(PurchaseID, ref CategoryID, ref SupplierID, ref purchaseName, ref purchaseType,
                                                                    ref purchaseDetails, ref purchaseBuy, ref purchaseSell, ref purchaseQuantity,
                                                                    ref purchaseTotalSell, ref purchaseTotalBuy, ref purchaseTotalEarnings);
            if (isFound)
            {
                return new clsPurchases(PurchaseID, CategoryID, SupplierID, purchaseName, purchaseType, purchaseDetails, purchaseBuy, purchaseSell,
                                        purchaseQuantity, purchaseTotalSell, purchaseTotalBuy, purchaseTotalEarnings);
            }
            else
                return null;

        }
        public static clsPurchases Find(string purchaseName)
        {
            int? SupplierID = null;
            int? CategoryID = null;
            int? PurchaseID = null;
            string purchaseType = string.Empty, purchaseDetails = string.Empty;
            float purchaseBuy = 0, purchaseSell = 0, purchaseQuantity = 0, purchaseTotalSell = 0, purchaseTotalBuy = 0, purchaseTotalEarnings = 0;
            bool isFound = clsPurchasesDataAccess.GetPurchaseInfoByPurchaseName(purchaseName, ref PurchaseID, ref CategoryID, ref SupplierID, ref purchaseType,
                                                                    ref purchaseDetails, ref purchaseBuy, ref purchaseSell, ref purchaseQuantity,
                                                                    ref purchaseTotalSell, ref purchaseTotalBuy, ref purchaseTotalEarnings);
            if (isFound)
            {
                return new clsPurchases(PurchaseID, CategoryID, SupplierID, purchaseName, purchaseType, purchaseDetails, purchaseBuy, purchaseSell,
                                        purchaseQuantity, purchaseTotalSell, purchaseTotalBuy, purchaseTotalEarnings);
            }
            else
                return null;

        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAddNew:
                    {
                        if (_AddNewPurchase())
                        {
                            _Mode = enMode.enUpdate;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.enUpdate:
                    {
                        return _UpdatePruchase();
                    }
            }
            return false;
        }
        public static int Count()
        {
            return clsPurchasesDataAccess.Count();
        }
    }
}
