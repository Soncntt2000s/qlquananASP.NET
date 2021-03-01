using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DoAn.DTO;

namespace DoAn.DAO
{
    class ListBillDAO
    {
        private static ListBillDAO instance;

        public static ListBillDAO Instance
        {
            get { if (instance == null) instance = new ListBillDAO(); return ListBillDAO.instance; }
            private set { ListBillDAO.instance = value; }
        }

        private ListBillDAO() { }

        /*=============================================================*/


        public List<ListBill> GetListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            List<ListBill> lst = new List<ListBill>();
                string query = "USP_GetListBillByDate @checkIn , @checkOut";
                DataTable data = DataProvaider.Instance.ExecuteQuery(query,new object[] { checkIn, checkOut });
                foreach (DataRow item in data.Rows)
                {
                    ListBill bill = new ListBill(item);
                    lst.Add(bill);
                }

                return lst;
        }
    }
}
