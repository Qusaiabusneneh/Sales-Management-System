using Busniess_Layer;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace Sales_Management.App.Category
{
    public partial class FRMAddCategory : Form
    {
        private enum enMode { enAddNew, enUpdate }
        private enMode _Mode = enMode.enAddNew;
        private clsCategory _category;
        //private clsMethods _methods=new clsMethods();
        Toast toast;
        Dialog dialog;
        private int? _categoryID = null;
        public int? CategoryID => _categoryID;

        public delegate void RefreshComboBoxEventHandler();
        public static event RefreshComboBoxEventHandler OnCategoryAdded;
        public FRMAddCategory()
        {
            InitializeComponent();
            this._Mode = enMode.enAddNew;
        }
        public FRMAddCategory(int? categoryID)
        {
            InitializeComponent();
            this._categoryID = categoryID;
            this._Mode = enMode.enUpdate;
        }
        private void _ResetDefaultData()
        {
            if (_Mode == enMode.enAddNew)
            {
                lblTitle.Text = "اضافة عنصر جديد";
                _category = new clsCategory();
            }

            else
                lblTitle.Text = "تعديل على معلومات الصنف";

            txtNameCategory.Text = "";
            pbCategory.Image = null;
        }
        public static byte[] ConvertImageToByteArray(Image img)
        {
            if (img == null) return null; // ✅ Handle empty images

            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Use JPEG or PNG format
                return ms.ToArray();
            }
        }
        private void _LoadData()
        {
            try
            {
                _category = clsCategory.Find(_categoryID);
                if (_category == null)
                {
                    dialog = new Dialog("حدث خطأ");
                    _ResetDefaultData();
                    return;
                }

                txtNameCategory.Text = _category.CategoryName;

                if (_category.CategoryImage != null && _category.CategoryImage.Length > 0)
                {
                    // Create a new MemoryStream and copy the data
                    using (MemoryStream ms = new MemoryStream(_category.CategoryImage)) // ✅ Directly use byte[]
                    {
                        pbCategory.Image?.Dispose(); // Dispose old image if exists
                        pbCategory.Image = Image.FromStream(ms);
                    }
                }
                else
                    pbCategory.Image = null;
            }

            catch (Exception ex)
            {
                dialog = new Dialog($"حدث خطأ أثناء حفظ التعديلات {ex.Message}");
                dialog.Show();
            }
        }
        private bool _CheckToFillInfo()
        {
            if (txtNameCategory.Text == "")
            {
                dialog = new Dialog();
                dialog.Width = this.Width;
                dialog.lblCaption.Text = "اسم الصنف مطلوب";
                dialog.Show();
                return true;
            }
            else
                return false;
        }
        private void _HandleImage()
        {
            // Handle image conversion safely
            if (pbCategory.Image != null)
            {
                byte[] newImageData = ConvertImageToByteArray(pbCategory.Image);
                _category.CategoryImage = newImageData;
            }
            else
            {
                pbCategory.Image = Properties.Resources.programmer;
                _category.CategoryImage = null;

                //Dialog dialog = new Dialog("الرجاء إضافة صورة للمورد");
                //dialog.Show();
                //return;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!_CheckToFillInfo())
            {
                _category.CategoryName = txtNameCategory.Text;
                _HandleImage();
                if (_category.Save())
                {
                    // After successful save, trigger the refresh event
                    OnCategoryAdded?.Invoke();
                    _Mode = enMode.enUpdate;
                    lblTitle.Text = "تعديل على معلومات الصنف";
                    btnAdd.Text = "تعديل";
                    dialog = new Dialog("تم تخزين معلومات الصنف بنجاح");
                    dialog.Width = this.Width;
                    dialog.Show();
                }
                else
                {
                    dialog = new Dialog("حدث خطأ اثناء عملية التخزين");
                    dialog.Width = this.Width;
                    dialog.Show();

                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FRMAddCategory_Load(object sender, EventArgs e)
        {
            _ResetDefaultData();
            if (_Mode == enMode.enUpdate)
                _LoadData();
        }
    }
}
