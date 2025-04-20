using Busniess_Layer;
using Sales_Management.App.Customers;
using Sales_Management.App.Purchases;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sales_Management.App.Sells
{
    public partial class FRM_AddSells : Form
    {
        private enum enMode { enAdd, enUpdate }
        private enMode _Mode = enMode.enAdd;
        private int? _sellID = null;
        public int? sellID => _sellID;
        private clsSells _sell;
        private double _QuantityPrevious, _QuantityNew, _QuantityRequiment;
        public FRM_AddSells()
        {
            InitializeComponent();
            _Mode = enMode.enAdd;

            // Subscribe to the purchase added event
            FRM_AddPurchases.OnPurchaseAdded += _RefreshPurchaseComboBox;
            // Initial load of purchase
            _FillPurchaseComboBox();

            // Subscribe to the customer added event
            FRM_AddCustomer.OnCustomerAdd += _RereshCustomerComboBox;
            // Initial load of customer
            _FillCustomerComboBox();
        }
        public FRM_AddSells(int? sellID)
        {
            InitializeComponent();
            this._sellID = sellID;
            _Mode = enMode.enUpdate;
        }
        private void _FillCustomerComboBox()
        {
            cmbCustomer.Items.Clear();
            DataTable dtCustomer = clsCustomers.GetAllCustomers();
            foreach (DataRow row in dtCustomer.Rows)
                cmbCustomer.Items.Add(row["CustomerName"]);
        }
        private void _RereshCustomerComboBox()
        {
            // Store current selection
            string currentSelected = cmbCustomer.Text;

            // Reload Customers
            _FillCustomerComboBox();

            if (!string.IsNullOrEmpty(currentSelected))
            {
                int index = cmbCustomer.FindString(currentSelected);
                if (index != -1)
                    cmbCustomer.SelectedIndex = index;
            }
        }
        private void _FillPurchaseComboBox()
        {
            cmbPurchase.Items.Clear();
            DataTable dtPurchase = clsPurchases.GetAllPurchases();
            foreach (DataRow row in dtPurchase.Rows)
                cmbPurchase.Items.Add(row["PurchaseName"]);
        }
        private void _RefreshPurchaseComboBox()
        {
            string currentSelection = cmbPurchase.Text;
            _FillPurchaseComboBox();
            if (!string.IsNullOrEmpty(currentSelection))
            {
                int index = cmbPurchase.FindString(currentSelection);
                if (index != -1)
                    cmbPurchase.SelectedIndex = index;
            }
        }
        private void _RefreshDefaultValue()
        {
            _FillPurchaseComboBox();
            _FillCustomerComboBox();
            if (_Mode == enMode.enAdd)
            {
                _sell = new clsSells();
                btnAdd.Text = "أضافة";
            }
            else
            {
                btnAdd.Text = "تعديل";
            }
            txtSell.Text = "";
            cmbPurchase.SelectedIndex = 0;
            cmbCustomer.SelectedIndex = 0;
            _ClearLabels();
        }
        private bool _FillItems()
        {
            if (txtSell.Text == "" && numericUpDown1.Value < 1)
            {
                Dialog dialog = new Dialog("يرجى تعبيئة جميع العناصر");
                dialog.Width = this.Width;
                dialog.Show();
                return true;
            }
            else
                return false;
        }
        private bool _CaculateOperations()
        {
            _QuantityPrevious = Convert.ToDouble(lblQuantity.Text);
            _QuantityNew = Convert.ToDouble(numericUpDown1.Value);
            _QuantityRequiment = _QuantityPrevious - _QuantityNew;
            if (_QuantityRequiment >= 0)
            {
                _sell.SellPrice = (float)Convert.ToDouble(txtSell.Text);
                _sell.Quantity = (int)numericUpDown1.Value;
                _sell.TotalPrice = (float)(Convert.ToDouble(txtSell.Text) * Convert.ToDouble(numericUpDown1.Text));
                _sell.SellDate = DateTime.Now;
                _sell.selectedPurchaseInfo.PurchaseQuantity = (float)_QuantityRequiment;
                _sell.selectedPurchaseInfo.PurchaseTotalBuy = (float)(Convert.ToDouble(lblTotalBuy.Text) * _QuantityRequiment);
                _sell.selectedPurchaseInfo.PurchaseTotalSell = (float)((Convert.ToDouble(lblTotalSells.Text) * _QuantityRequiment));
                _sell.selectedPurchaseInfo.PurchaseTotalEarnings = _sell.selectedPurchaseInfo.PurchaseTotalSell - _sell.selectedPurchaseInfo.PurchaseTotalBuy;
                _sell.selectedPurchaseInfo.Save();
                _sell.PurchaseID = clsPurchases.Find(cmbPurchase.Text).PurchaseID;
                _sell.CustomerID = clsCustomers.Find(cmbCustomer.Text).CustomerID;
                return true;
            }
            else
            {
                lblCheckQuantity.Visible = true;
                btnAdd.Enabled = false;
                return false;
            }
        }
        private void _ClearLabels()
        {
            lblQuantity.Text = "0";
            lblTotalBuy.Text = "0";
            lblTotalSells.Text = "0";
        }
        private void _LoadData()
        {
            _sell = clsSells.Find(_sellID);
            if (_sell == null)
            {
                _RefreshDefaultValue();
                Dialog dialog = new Dialog("لا يوجد معلومات عن هذه المبيعات");
                dialog.Width = this.Width;
                dialog.ShowDialog();
                return;
            }
            txtSell.Text = _sell.SellPrice.ToString();
            _CaculateOperations();
            numericUpDown1.Text = _sell.Quantity.ToString();
            cmbPurchase.SelectedIndex = cmbPurchase.FindString(_sell.selectedPurchaseInfo.PurchaseName);
            cmbCustomer.SelectedIndex = cmbCustomer.FindString(_sell.selectedCustomersInfo.CustomerName);
            linkAddNewPurchase.Enabled = false;
            linkAddNewCustomer.Enabled = false;
        }
        private void linkAddNewCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FRM_AddPurchases frm = new FRM_AddPurchases();
            frm.ShowDialog();
        }
        private void cmbPurchase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPurchase.SelectedItem != null)
                {
                    int? PurchaseID = null;
                    if (cmbPurchase.SelectedItem != null)
                    {
                        PurchaseID = clsPurchases.Find(cmbPurchase.Text).PurchaseID;
                    }
                    _sell.selectedPurchaseInfo = clsPurchases.Find(PurchaseID);
                    if (_sell.selectedPurchaseInfo != null)
                    {
                        lblTotalBuy.Text = _sell.selectedPurchaseInfo.PurchaseBuy.ToString();
                        lblTotalSells.Text = _sell.selectedPurchaseInfo.PurchaseSell.ToString();
                        lblQuantity.Text = _sell.selectedPurchaseInfo.PurchaseQuantity.ToString();
                        txtSell.Text = _sell.selectedPurchaseInfo.PurchaseSell.ToString();
                    }
                    else
                        _ClearLabels();

                }
                else
                    _ClearLabels();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading purchase information : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ClearLabels();
            }
        }
        private void linkAddNewCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FRM_AddCustomer frm = new FRM_AddCustomer();
            frm.ShowDialog();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!_FillItems())
            {
                if (_CaculateOperations())
                {
                    if (_sell.Save())
                    {
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
        }
        private void FRM_AddSells_Load(object sender, EventArgs e)
        {
            _RefreshDefaultValue();
            if (_Mode == enMode.enUpdate)
                _LoadData();
            cmbPurchase_SelectedIndexChanged(null, null);
        }
        private void FRM_AddSells_FormClosing(object sender, FormClosingEventArgs e)
        {
            FRM_AddPurchases.OnPurchaseAdded -= _RefreshPurchaseComboBox;
            FRM_AddCustomer.OnCustomerAdd -= _RereshCustomerComboBox;
        }

    }
}
