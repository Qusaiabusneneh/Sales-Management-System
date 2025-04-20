using Busniess_Layer;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sales_Management.App.Purchases
{
    public partial class FRM_Purchases : Form
    {
        private DataTable _dtPurchases = new DataTable();
        public BindingSource bindingSource;
        private void _LoadPurchases()
        {
            _dtPurchases = clsPurchases.GetAllPurchases();
            bindingSource.DataSource = _dtPurchases;
            DGVPurchases.DataSource = bindingSource;
        }

        public FRM_Purchases()
        {
            InitializeComponent();
            bindingSource = new BindingSource();
            _LoadPurchases();
        }

        private void FRM_Purchases_Load(object sender, EventArgs e)
        {
            _LoadPurchases();
            if (DGVPurchases.Columns.Count > 0)
            {
                DGVPurchases.Columns[0].HeaderText = "Purchase ID";
                DGVPurchases.Columns[0].Width = 100;

                DGVPurchases.Columns[1].HeaderText = "CategoryName";
                DGVPurchases.Columns[1].Width = 130;

                DGVPurchases.Columns[2].HeaderText = "SupplierName";
                DGVPurchases.Columns[2].Width = 130;

                DGVPurchases.Columns[3].HeaderText = "PurchaseName";
                DGVPurchases.Columns[3].Width = 130;

                DGVPurchases.Columns[4].HeaderText = "PurchaseType";
                DGVPurchases.Columns[4].Width = 130;

                DGVPurchases.Columns[5].HeaderText = "PurchaseDetails";
                DGVPurchases.Columns[5].Width = 130;

                DGVPurchases.Columns[6].HeaderText = "Purchase Buy";
                DGVPurchases.Columns[6].Width = 130;

                DGVPurchases.Columns[7].HeaderText = "Purchase Sell";
                DGVPurchases.Columns[7].Width = 130;

                DGVPurchases.Columns[8].HeaderText = "Purchase Quantity";
                DGVPurchases.Columns[8].Width = 130;

                DGVPurchases.Columns[9].HeaderText = "Purchase TotalSell";
                DGVPurchases.Columns[9].Width = 150;

                DGVPurchases.Columns[10].HeaderText = "Purchase TotalBuy";
                DGVPurchases.Columns[10].Width = 150;

                DGVPurchases.Columns[11].HeaderText = "Purchase TotalEngine";
                DGVPurchases.Columns[11].Width = 150;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FRM_AddPurchases frm = new FRM_AddPurchases();
            frm.ShowDialog();
            FRM_Purchases_Load(null, null);
        }

        public void btnUpdate_Click(object sender, EventArgs e)
        {
            FRM_Purchases_Load(null, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int? PurchaseID = (int?)DGVPurchases.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("هل انت متأكد من حذف هذا العنصر ؟", "jتحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsPurchases.DeletePurchase(PurchaseID))
                {
                    Dialog dialog = new Dialog("تم حذف العنصر بنجاح");
                    dialog.Width = this.Width;
                    dialog.Show();
                    FRM_Purchases_Load(null, null);
                }
                else
                {
                    Dialog dialog = new Dialog("حدث خطأ اثناء عملية الحذف");
                    dialog.Width = this.Width;
                    dialog.Show();
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            FRM_AddPurchases frm = new FRM_AddPurchases((int?)DGVPurchases.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            FRM_Purchases_Load(null, null);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    bindingSource.RemoveFilter();
                    return;
                }
                string filterExpression = string.Format("CategoryName LIKE  '%{0}%' OR " +
                                                        "SupplierName LIKE '%{0}%' OR " +
                                                        "PurchaseName LIKE '%{0}%' OR " +
                                                        "PurchaseType LIKE '%{0}%' OR " +
                                                        "PurchaseDetails LIKE '%{0}%'",
                                                        txtSearch.Text);
                bindingSource.Filter = filterExpression;
            }
            catch (Exception ex)
            {
                Dialog dialog = new Dialog($"حدث خطأ أثناء عملية البحث {ex.Message}");
            }
        }
    }
}
