using Busniess_Layer;
using Sales_Management.App.Category;
using Sales_Management.App.Customers;
using Sales_Management.App.Purchases;
using Sales_Management.App.Sells;
using Sales_Management.App.Supppliers;
using System.Windows.Forms;

namespace Sales_Management.App
{
    public partial class FRM_Home : Form
    {
        public FRM_Home()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, System.EventArgs e)
        {
            FRMAddCategory frm = new FRMAddCategory();
            frm.Show();
        }

        private void btnSupplier_Click(object sender, System.EventArgs e)
        {
            AddNewSuppliers frm = new AddNewSuppliers();
            frm.Show();
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            FRM_AddPurchases frm = new FRM_AddPurchases();
            frm.Show();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            FRM_AddCustomer frm = new FRM_AddCustomer();
            frm.Show();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            FRM_AddSells frm = new FRM_AddSells();
            frm.Show();
        }

        public void FRM_Home_Load(object sender, System.EventArgs e)
        {
            lblCategoriesCounter.Text = clsCategory.Count().ToString();
            lblCustomersCounter.Text = clsCustomers.Count().ToString();
            lblPurchasesCounter.Text = clsPurchases.Count().ToString();
            lblSellsCounter.Text = clsSells.Count().ToString();
            lblSuppliersCounter.Text = clsSuppliers.Count().ToString();
        }
    }
}
