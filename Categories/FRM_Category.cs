using Busniess_Layer;
using Sales_Management.App.Category;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sales_Management.App
{
    public partial class FRM_Category : Form
    {
        private DataTable _dtCategory;
        private BindingSource bindingSource;
        public FRM_Category()
        {
            InitializeComponent();
            bindingSource = new BindingSource();
            _LoadCategories();
        }
        private void _LoadCategories()
        {
            _dtCategory = clsCategory.GetAllCategory();
            bindingSource.DataSource = _dtCategory;
            DGVCategory.DataSource = bindingSource;
        }
        private void FRM_Category_Load(object sender, EventArgs e)
        {
            _LoadCategories();
            DGVCategory.Columns[0].HeaderText = "PurchaseID";
            DGVCategory.Columns[0].Width = 500;

            DGVCategory.Columns[1].HeaderText = "CategoryName";
            DGVCategory.Columns[1].Width = 500;

            DGVCategory.Columns[2].HeaderText = "CategoryImage";
            DGVCategory.Columns[2].Width = 500;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FRMAddCategory frm = new FRMAddCategory();
            frm.ShowDialog();
            FRM_Category_Load(null, null);
        }

        public void btnUpdate_Click(object sender, EventArgs e)
        {
            _dtCategory = clsCategory.GetAllCategory();
            DGVCategory.DataSource = _dtCategory;
            FRM_Category_Load(null, null);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int? CategoryID = (int?)DGVCategory.CurrentRow.Cells[0].Value;
            Toast toast = new Toast();
            Dialog dialog = new Dialog();
            try
            {
                if (MessageBox.Show("هل تريد حذف العنصر", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (clsCategory.DeleteCategory(CategoryID))
                    {
                        dialog.lblCaption.Text = "تم الحذف بنجاح";
                        toast.Show();
                        FRM_Category_Load(null, null);
                        this.Close();
                    }
                }
            }
            catch
            {
                dialog.Width = this.Width;
                dialog.lblCaption.Text = "العنصر غير موجود";
                dialog.Show();
            }
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            int? CategoryID = (int?)DGVCategory.CurrentRow.Cells[0].Value;
            FRMAddCategory frm = new FRMAddCategory(CategoryID);
            frm.Show();
            FRM_Category_Load(null, null);
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
                string filterExpression = $"CategoryName LIKE '%{txtSearch.Text}%'";
                bindingSource.Filter = filterExpression;
            }
            catch (Exception ex)
            {
                Dialog dialog = new Dialog($"حدث خطأ أثناء عملية البحث {ex.Message}");
            }
        }
    }
}
