using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoAn.DTO;
using System.Data;

namespace DoAn.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }

        private BillInfoDAO() { }

        /*=============================================================*/


        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = DataProvaider.Instance.ExecuteQuery("SELECT * FROM dbo.ChiTietHoaDon WHERE idHoaDon = " + id);
            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }

        /*=============================================================*/


        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            DataProvaider.Instance.ExecuteNonQuery("USP_InsertBillInfo @idBill , @idFood , @count", new object[] { idBill, idFood, count });
        }
    }
}
