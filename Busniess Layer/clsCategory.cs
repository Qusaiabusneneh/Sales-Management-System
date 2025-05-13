using Data_Access_Layer;
using System.Data;

namespace Busniess_Layer
{
    public class clsCategory
    {
        private enum enMode { enAdd, enUpdate };
        private enMode _Mode;
        public int? ID { set; get; }
        public string CategoryName { set; get; }
        public byte[] CategoryImage { set; get; }
        public clsCategory()
        {
            ID = null;
            CategoryName = string.Empty;
            CategoryImage = null;
            _Mode = enMode.enAdd;
        }
        public clsCategory(int? ID, string CategoryName, byte[] CategoryImage)
        {
            this.ID = ID;
            this.CategoryName = CategoryName;
            this.CategoryImage = CategoryImage;
            _Mode = enMode.enUpdate;
        }
        public static DataTable GetAllCategory()
        {
            return clsCategoryDataAccess.GetAllCategories();
        }
        private bool _AddNewCategory()
        {
            this.ID = clsCategoryDataAccess.AddNewCategory(this.CategoryName, this.CategoryImage);
            return (this.ID.HasValue);
        }
        private bool _UpdateCategory()
        {
            return clsCategoryDataAccess.UpdateCategory(this.ID, this.CategoryName, this.CategoryImage);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAdd:
                    {
                        if (_AddNewCategory())
                        {
                            _Mode = enMode.enUpdate;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.enUpdate:
                    {
                        return _UpdateCategory();
                    }
            }
            return false;
        }
        public static bool DeleteCategory(int? CategoryID)
        {
            return clsCategoryDataAccess.DeleteCategory(CategoryID);
        }
        public static clsCategory Find(int? CategoryID)
        {
            string CategoryName = "";
            byte[] CategoryImage = null;
            bool isFound = clsCategoryDataAccess.GetCategoryInfoByID(CategoryID, ref CategoryName, ref CategoryImage);
            if (isFound)
                return new clsCategory(CategoryID, CategoryName, CategoryImage);
            else
                return null;
        }
        public static clsCategory Find(string CategoryName)
        {
            int? CategoryID = null;
            byte[] CategoryImage = null;
            bool isFound = clsCategoryDataAccess.GetCategoryInfoByCategoryName(CategoryName, ref CategoryID, ref CategoryImage);
            if (isFound)
                return new clsCategory(CategoryID, CategoryName, CategoryImage);
            else
                return null;
        }
        public static int Count()
        {
            return clsCategoryDataAccess.Count();
        }
    }
}
