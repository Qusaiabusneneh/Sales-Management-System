using Busniess_Layer;
using Sales_Management.App.Category;
using Sales_Management.App.Supppliers;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sales_Management.App.Purchases
{
    public partial class FRM_AddPurchases : Form
    {
        public delegate void RefreshComboBoxEventHandler();
        public static event RefreshComboBoxEventHandler OnPurchaseAdded;
        public event EventHandler PurchaseHandle;
        protected virtual void OnPurchaseUpdated() => PurchaseHandle?.Invoke(this, EventArgs.Empty);
        private enum enMode { enAddNew, enUpdate };
        private enMode _Mode = enMode.enAddNew;
        private int? _purchaseID;
        public int? purchaseID => _purchaseID;
        private clsPurchases _purchases;
        private double _Buy, _Sell, _Quantity, _TotalBuy, _TotalSell, _TotalEarnings;
        private void _FillCategoryComboBox()
        {
            cmbCategory.Items.Clear();
            DataTable dtCategory = clsCategory.GetAllCategory();
            foreach (DataRow row in dtCategory.Rows)
                cmbCategory.Items.Add(row["CategoryName"]);
        }
        private void _RefreshCategoryComboBox()
        {
            // Store current selection
            string currentSelection = cmbCategory.Text;

            // Reload suppliers
            _FillCategoryComboBox();

            if (!string.IsNullOrEmpty(currentSelection))
            {
                int index = cmbCategory.FindString(currentSelection);
                if (index != -1)
                    cmbCategory.SelectedIndex = index;
            }
        }
        private void _FillSuppliersCombBox()
        {
            cmbSupplier.Items.Clear();
            DataTable dtSupplier = clsSuppliers.GetAllSuppliers();
            foreach (DataRow row in dtSupplier.Rows)
                cmbSupplier.Items.Add(row["SupplierName"].ToString());
        }
        private void _RefreshSupplierComboBox()
        {
            // Store current selection
            string currentSelection = cmbSupplier.Text;

            // Reload suppliers
            _FillSuppliersCombBox();

            if (!string.IsNullOrEmpty(currentSelection))
            {
                int index = cmbSupplier.FindString(currentSelection);
                if (index != -1)
                    cmbSupplier.SelectedIndex = index;
            }

        }
        private void _ResetDefaultValue()
        {
            _FillCategoryComboBox();
            _FillSuppliersCombBox();

            if (_Mode == enMode.enAddNew)
            {
                btnAdd.Text = "اضافة";
                _purchases = new clsPurchases();
            }
            else
            {
                btnAdd.Text = "تعديل";
            }

            txtDetails.Text = "";
            txtBuy.Text = "";
            txtPurchasesName.Text = "";
            txtPurchasesType.Text = "";
            cmbCategory.SelectedIndex = 0;
            cmbSupplier.SelectedIndex = 0;
            lblTotalEarnings.Text = "0";
            lblTotalBuy.Text = "0";
            lblTotalSells.Text = "0";

        }
        private void _CalculateOperations()
        {
            _Sell = Convert.ToDouble(txtSell.Text);
            _Buy = Convert.ToDouble(txtBuy.Text);
            _Quantity = Convert.ToDouble(numericUpDown1.Value);
            _TotalBuy = _Buy * _Quantity;
            _TotalSell = _Sell * _Quantity;
            _TotalEarnings = _TotalSell - _TotalBuy;
            lblTotalBuy.Text = _TotalBuy.ToString();
            lblTotalSells.Text = _TotalSell.ToString();
            lblTotalEarnings.Text = _TotalEarnings.ToString();
        }
        private void _LoadData()
        {
            _purchases = clsPurchases.Find(_purchaseID);
            if (_purchases == null)
            {
                _ResetDefaultValue();
                Dialog dialog = new Dialog("لا يوجد معلومات عن هذه المتشريات");
                dialog.Width = this.Width;
                dialog.ShowDialog();
                return;
            }
            txtDetails.Text = _purchases.PurchaseDetails;
            txtBuy.Text = _purchases.PurchaseBuy.ToString();
            txtSell.Text = _purchases.PurchaseSell.ToString();
            txtPurchasesName.Text = _purchases.PurchaseName;
            txtPurchasesType.Text = _purchases.PurchaseType;
            _CalculateOperations();
            lblTotalBuy.Text = _purchases.PurchaseTotalBuy.ToString();
            lblTotalSells.Text = _purchases.PurchaseTotalSell.ToString();
            lblTotalEarnings.Text = _purchases.PurchaseTotalEarnings.ToString();
            cmbCategory.SelectedIndex = cmbCategory.FindString(_purchases.selectedCategoryInfo.CategoryName);
            cmbSupplier.SelectedItem = cmbSupplier.FindString(_purchases.selectedSupplierInfo.SupplierName);
            numericUpDown1.Text = _purchases.PurchaseQuantity.ToString();
            linkAddNewCategory.Enabled = false;
            linkAddNewSupplier.Enabled = false;
        }
        private bool CheckIsItemsIsFill()
        {
            if (txtDetails.Text == "" && txtBuy.Text == "" && txtPurchasesName.Text == "" && txtPurchasesType.Text == "" && txtSell.Text == "" &&
                cmbCategory.Text == "" && cmbSupplier.Text == "")
            {
                Dialog dialog = new Dialog("يرجى تعبئة جميع العناصر");
                dialog.Width = this.Width;
                dialog.ShowDialog();
                return false;
            }
            else
                return true;
        }
        public FRM_AddPurchases()
        {
            InitializeComponent();
            _Mode = enMode.enAddNew;

            // Subscribe to the supplier added event
            AddNewSuppliers.OnSupplierAdded += _RefreshSupplierComboBox;
            // Initial load of suppliers
            _FillSuppliersCombBox();

            // Subscribe to the category added event
            FRMAddCategory.OnCategoryAdded += _RefreshCategoryComboBox;
            // Initial load of category
            _FillCategoryComboBox();
        }
        public FRM_AddPurchases(int? purchaseID)
        {
            InitializeComponent();
            this._purchaseID = purchaseID;
            _Mode = enMode.enUpdate;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void linkAddNewCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FRMAddCategory frm = new FRMAddCategory();
            frm.ShowDialog();
        }
        private void linkAddNewSupplier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddNewSuppliers frm = new AddNewSuppliers();
            frm.ShowDialog();
        }
        private void FRM_AddPurchases_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if (_Mode == enMode.enUpdate)
                _LoadData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckIsItemsIsFill())
            {
                _purchases.PurchaseName = txtPurchasesName.Text;
                _purchases.PurchaseType = txtPurchasesType.Text;
                _purchases.PurchaseDetails = txtDetails.Text;
                _CalculateOperations();
                _purchases.PurchaseQuantity = (float)numericUpDown1.Value;
                _purchases.PurchaseBuy = float.Parse(txtBuy.Text);
                _purchases.PurchaseSell = float.Parse(txtSell.Text);
                _purchases.PurchaseTotalBuy = float.Parse(lblTotalBuy.Text);
                _purchases.PurchaseTotalSell = float.Parse(lblTotalSells.Text);
                _purchases.PurchaseTotalEarnings = float.Parse(lblTotalEarnings.Text);
                _purchases.CategoryID = clsCategory.Find(cmbCategory.Text).ID;
                _purchases.SupplierID = clsSuppliers.Find(cmbSupplier.Text).SupplierID;
                if (_purchases.Save())
                {
                    OnPurchaseAdded?.Invoke();
                    _Mode = enMode.enUpdate;
                    btnAdd.Text = "تعديل";
                    Dialog dialog = new Dialog("تم تخزين المعلومات بنجاح");
                    dialog.Width = this.Width;
                    dialog.Show();
                }
                else
                {
                    Dialog dialog = new Dialog("حدث خطأ اثناء تخزين المعلومات ");
                    dialog.Width = this.Width;
                    dialog.Show();
                }
            }
        }
        private void FRM_AddPurchases_FormClosing(object sender, FormClosingEventArgs e)
        {
            FRMAddCategory.OnCategoryAdded -= _RefreshCategoryComboBox;
            AddNewSuppliers.OnSupplierAdded -= _RefreshSupplierComboBox;
        }
    }
}
