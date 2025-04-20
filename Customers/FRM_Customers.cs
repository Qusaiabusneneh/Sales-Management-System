using Busniess_Layer;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sales_Management.App.Customers
{
    public partial class FRM_Customers : Form
    {
        DataTable dtCustomer;
        BindingSource bindingSource;
        private void _LoadCustomers()
        {
            dtCustomer = clsCustomers.GetAllCustomers();
            bindingSource.DataSource = dtCustomer;
            DGVCustomers.DataSource = bindingSource;
        }

        public FRM_Customers()
        {
            InitializeComponent();
            bindingSource = new BindingSource();
            _LoadCustomers();
        }
        private void FRM_Customers_Load(object sender, EventArgs e)
        {
            _LoadCustomers();
            if (DGVCustomers.Columns.Count > 0)
            {
                DGVCustomers.Columns[0].HeaderText = "CustomerID";
                DGVCustomers.Columns[0].Width = 200;

                DGVCustomers.Columns[1].HeaderText = "CustomerName";
                DGVCustomers.Columns[1].Width = 350;

                DGVCustomers.Columns[2].HeaderText = "CustomerEmail";
                DGVCustomers.Columns[2].Width = 350;

                DGVCustomers.Columns[3].HeaderText = "CustomerPhone";
                DGVCustomers.Columns[3].Width = 350;

                DGVCustomers.Columns[4].HeaderText = "CustomerImage";
                DGVCustomers.Columns[4].Width = 400;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FRM_AddCustomer frm = new FRM_AddCustomer();
            frm.ShowDialog();
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            FRM_AddCustomer frm = new FRM_AddCustomer((int?)DGVCustomers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int? CustomerID = (int?)DGVCustomers.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("هل انت متاكد من حذف هذا العميل؟", "تحذير", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                == DialogResult.OK)
            {
                if (clsCustomers.DeleteCustomer(CustomerID))
                {
                    Dialog dialog = new Dialog("تم حذف العميل بنجاح");
                    dialog.Width = this.Width;
                    dialog.ShowDialog();
                }
                else
                {
                    Dialog dialog = new Dialog("حدث خطأ اثناء عملية الحذف");
                    dialog.Width = this.Width;
                    dialog.ShowDialog();
                }
            }
        }
        public void btnUpdate_Click(object sender, EventArgs e)
        {
            FRM_Customers_Load(null, null);
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
                string filterExpression = string.Format("CustomerName LIKE '%{0}%' OR " +
                                                        "CustomerEmail LIKE '%{0}%' OR " +
                                                        "CustomerPhone LIKE '%{0}%'",
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
