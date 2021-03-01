
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoAn.DTO;
using System.Data;

namespace DoAn.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            private set { FoodDAO.instance = value; }
        }

        private FoodDAO() { }

        /*=============================================================*/


        public List<Food> GetFoodByCategoryID(int id)
        {
            List<Food> list = new List<Food>();
            string query = "SELECT * FROM MonAn WHERE idThucDonMon =" + id ;
            DataTable data = DataProvaider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }

        /*=============================================================*/


        public List<Food> GetListFood()
        {
            List<Food> lst = new List<Food>();
            string query = "SELECT * FROM dbo.MonAn WHERE DaXoaMon = 0 ";
            DataTable data = DataProvaider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food bill = new Food(item);
                lst.Add(bill);
            }

            return lst;
        }

        /*=============================================================*/



        public void DeleteFoods(int idmonan)
        {
            string query = "USP_DeleteFoods @userName";
            DataTable result = DataProvaider.Instance.ExecuteQuery(query, new object[] { idmonan });
        }

        /*=============================================================*/


        public void UpdateFoods(int idmonan, string tenmon, int iddanhmuc ,float gia)
        {
            string query = "USP_UpdateFoods @idmonan ,  @tenmon ,  @iddanhmuc  , @gia ";
            DataTable result = DataProvaider.Instance.ExecuteQuery(query, new object[] { idmonan, tenmon, iddanhmuc, gia });
        }

        /*=============================================================*/


        public void InsertFoods( string tenmon, int iddanhmuc, float gia)
        {
            string query = "USP_InsertFoods   @tenmon ,  @iddanhmuc  , @gia ";
            DataTable result = DataProvaider.Instance.ExecuteQuery(query, new object[] { tenmon, iddanhmuc, gia });
        }

        /*=============================================================*/


        public List<Food> SearchFoodByName(string name)
        {
             List<Food> lst = new List<Food>();
             string query = string.Format("SELECT * FROM dbo.MonAn WHERE dbo.fuConvertToUnsign1(TenMon) LIKE N'%' + " +
                            "dbo.fuConvertToUnsign1(N'{0}') + '%'", name);
            DataTable data = DataProvaider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food bill = new Food(item);
                lst.Add(bill);
            }

            return lst;
        }

        
    }
}
