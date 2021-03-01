using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoAn.DTO;
using System.Data;

namespace DoAn.DAO
{
    class ListFoodsDAO
    {
        private static ListFoodsDAO instance;

        public static ListFoodsDAO Instance
        {
            get { if (instance == null) instance = new ListFoodsDAO(); return ListFoodsDAO.instance; }
            private set { ListFoodsDAO.instance = value; }
        }

        private ListFoodsDAO() { }

        /*=============================================================*/


        public List<ListFood> GetFoods()
        {
            List<ListFood> list = new List<ListFood>();
            string query = "USP_GetListFood";
            DataTable data = DataProvaider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ListFood food = new ListFood(item);
                list.Add(food);
            }

            return list;
        }
    }
}
