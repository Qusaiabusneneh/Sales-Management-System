using Busniess_Layer;
using Sales_Management.App.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sales_Management.App.Customers
{
    public partial class FRM_AddCustomer : Form
    {
        public delegate void RefreshComboBoxEventHandler();
        public static event RefreshComboBoxEventHandler OnCustomerAdd;
        public event EventHandler CustomerHandle;
        protected virtual void OnCsutomerUpdated() => CustomerHandle?.Invoke(this, EventArgs.Empty);
        private enum enMode { enAdd, enUpdate }
        private enMode _Mode = enMode.enAdd;
        private int? _customerID = null;
        public int? customerID => _customerID;
        private clsCustomers _customers;
        public FRM_AddCustomer()
        {
            InitializeComponent();
            _Mode = enMode.enAdd;
        }
        public FRM_AddCustomer(int? CustomerID)
        {
            InitializeComponent();
            this._customerID = CustomerID;
            _Mode = enMode.enUpdate;
        }
        private void _RefreshDefaultValue()
        {
            if (_Mode == enMode.enAdd)
            {
                _customers = new clsCustomers();
                lbHeader.Text = "اضافة عميل جديد";
            }
            else
            {
                lbHeader.Text = "تعديل معلومات العميل";
                btnAdd.Text = "تعديل";
            }
            txtCustomerEmail.Text = "";
            txtCustomerName.Text = "";
            txtCutomerPhone.Text = "";
            pbCustomer.Image = Resources.woman;
        }
        private void _LoadData()
        {
            _customers = clsCustomers.Find(_customerID);
            if (_customers == null)
            {
                Dialog dialog = new Dialog("لا يوجد هذا العميل");
                dialog.Width = this.Width;
                dialog.Show();
                return;
            }
            else
            {
                txtCustomerEmail.Text = _customers.CustomerEmail;
                txtCustomerName.Text = _customers.CustomerName;
                txtCutomerPhone.Text = _customers.CustomerPhone;
                if (_customers.CustomerImage != null && _customers.CustomerImage.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(_customers.CustomerImage))
                    {
                        pbCustomer.Image?.Dispose();
                        pbCustomer.Image = Image.FromStream(ms);
                    }
                }
                else
                    pbCustomer.Image = null;
            }
        }
        private static byte[] _ConvertImageToByteArray(Image img)
        {
            if (img == null) return null; // Handle empty images

            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Use JPEG or PNG format
                return ms.ToArray();
            }
        }
        private void _HandleImage()
        {
            if (pbCustomer.Image != null)
            {
                byte[] newImageData = _ConvertImageToByteArray(pbCustomer.Image);
                _customers.CustomerImage = newImageData;
            }
            else
            {
                pbCustomer.Image = Properties.Resources.woman;
                _customers.CustomerImage = null;

                //Dialog dialog = new Dialog("الرجاء إضافة صورة للعميل");
                //dialog.Show();
                //return;

            }
        }
        private bool _CheckToFillItems()
        {
            if (txtCustomerEmail.Text == "" && txtCustomerName.Text == "" && txtCutomerPhone.Text == "")
            {
                Dialog dialog = new Dialog("يرجى تعبئة معلومات العميل");
                dialog.Width = this.Width;
                dialog.Show();
                return true;
            }
            else
                return false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_CheckToFillItems())
                {
                    _customers.CustomerName = txtCustomerName.Text;
                    _customers.CustomerPhone = txtCutomerPhone.Text;
                    _customers.CustomerEmail = txtCustomerEmail.Text;
                    _HandleImage();
                    if (_customers.Save())
                    {
                        OnCustomerAdd?.Invoke();
                        _Mode = enMode.enUpdate;
                        Dialog dialog = new Dialog("تم تخزين معلومات العميل بنجاح");
                        dialog.Width = this.Width;
                        dialog.Show();
                        lbHeader.Text = "تعديل على معلومات العميل";
                        btnAdd.Text = "تعديل";
                    }
                    else
                    {
                        Dialog dialog = new Dialog("حدث خطأ اثناء تخزين معلومات العميل ");
                        dialog.Width = this.Width;
                        dialog.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Dialog dialog = new Dialog($"حدث خطأ: {ex.Message}");
                dialog.Width = this.Width;
                dialog.Show();
            }
        }

        private void FRM_AddCustomer_Load(object sender, EventArgs e)
        {
            _RefreshDefaultValue();
            if (_Mode == enMode.enUpdate)
                _LoadData();
        }
    }
}
