using Data_Access_Layer;
using System;
using System.Data;

namespace Busniess_Layer
{
    public class clsSells
    {
        private enum enMode { enAdd, enUpdate }
        private enMode _Mode;
        public int? SellID { get; private set; }
        public int? CustomerID { set; get; }
        public int? PurchaseID { set; get; }
        public int Quantity { set; get; }
        public float SellPrice { set; get; }
        public float TotalPrice { set; get; }
        public DateTime SellDate { set; get; }
        public clsPurchases selectedPurchaseInfo { set; get; }
        public clsCustomers selectedCustomersInfo { set; get; }
        public clsSells()
        {
            this.SellID = null;
            this.CustomerID = null;
            this.PurchaseID = null;
            this.Quantity = 0;
            this.SellPrice = 0;
            this.TotalPrice = 0;
            this.SellDate = DateTime.Now;
            _Mode = enMode.enAdd;
        }
        public clsSells(int? sellID, int? customerID, int? purchaseID, int quantity, float sellPrice, float totalPrice, DateTime sellDate)
        {
            SellID = sellID;
            CustomerID = customerID;
            PurchaseID = purchaseID;
            Quantity = quantity;
            SellPrice = sellPrice;
            TotalPrice = totalPrice;
            SellDate = sellDate;
            this.selectedPurchaseInfo = clsPurchases.Find(purchaseID);
            this.selectedCustomersInfo = clsCustomers.Find(customerID);
            _Mode = enMode.enUpdate;
        }
        public static DataTable GetAllSells()
        {
            return clsSellsDataAccess.GetAllSells();
        }
        private bool _AddNewSell()
        {
            this.SellID = clsSellsDataAccess.AddNewSell(this.CustomerID, this.PurchaseID, this.SellPrice, this.Quantity, this.SellDate, this.TotalPrice);
            return this.SellID != null;
        }
        private bool _UpdateSell()
        {
            return clsSellsDataAccess.UpdateSell(this.SellID, this.CustomerID, this.PurchaseID, this.SellPrice, this.Quantity, this.SellDate, this.TotalPrice);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAdd:
                    {
                        if (_AddNewSell())
                        {
                            _Mode = enMode.enUpdate;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.enUpdate:
                    {
                        return _UpdateSell();
                    }
            }
            return false;
        }
        public static bool DeleteSell(int? SellID)
        {
            return clsSellsDataAccess.DeleteSell(SellID);
        }
        public static clsSells Find(int? SellID)
        {
            int? CustomerID = null;
            int? PurchaseID = null;
            int Quantity = 0;
            float SellPrice = 0;
            float TotalPrice = 0;
            DateTime SellDate = DateTime.Now;
            bool isFound = clsSellsDataAccess.GetSellInfoByID(SellID, ref CustomerID, ref PurchaseID, ref SellPrice, ref Quantity, ref SellDate, ref TotalPrice);
            if (isFound)
            {
                return new clsSells(SellID, CustomerID, PurchaseID, Quantity, SellPrice, TotalPrice, SellDate);
            }
            else
                return null;
        }
        public static int Count()
        {
            return clsSellsDataAccess.Count();
        }
    }
}
