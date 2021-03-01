using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DoAn.DTO;

namespace DoAn.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }
        private CategoryDAO() { }

        /*=============================================================*/


        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();
            string query = "SELECT * FROM dbo.ThucDonMonAn WHERE DaXoaThucDon = 0 ";
            DataTable data = DataProvaider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }
            return list ;
        }

        /*=============================================================*/


        public Category GetCategoryByID(int id)
        {
            Category category = null;
            string query = "SELECT * FROM dbo.ThucDonMonAn WHERE idThucDon = " + id ;
            DataTable data = DataProvaider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }
            return category;
        }

        /*=============================================================*/


        public int GetIdCategoryByName(string tendanhmuc)
        {            
            try
            {
                return (int)DataProvaider.Instance.ExecuteScalar("USP_GetIdCategoryByName @tendanhmuc ", new object[] { tendanhmuc });
            }
            catch
            {
                return -1;
            }

        }

        /*=============================================================*/


        public void InsertCategory(string tendanhmuc )
        {
            string query = "USP_InsertCategory @tendanhmuc ";
            DataProvaider.Instance.ExecuteNonQuery(query, new object[] { tendanhmuc });
        }

        /*=============================================================*/


        public void DeleteCategory(int iddanhmuc)
        {
            string query = "USP_DeleteCategory @madanhmuc ";
            DataProvaider.Instance.ExecuteNonQuery(query, new object[] { iddanhmuc });
        }

        /*=============================================================*/


        public void UpdateCategory(int iddanhmuc, string tendanhmuc)
        {
            string query = "USP_UpdateCategory @tendanhmuc , @madanhmuc ";
            DataProvaider.Instance.ExecuteNonQuery(query, new object[] { iddanhmuc, tendanhmuc });
        }

    }
}
