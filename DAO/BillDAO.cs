using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoAn.DTO;
using System.Data;

namespace DoAn.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO() { }

        /*=============================================================*/


        public int GetUncheckBillIdbyTableID(int id)
        {
            DataTable date = DataProvaider.Instance.ExecuteQuery("SELECT * FROM dbo.HoaDon WHERE idBanAn = " + id + " AND TrangThai = 0");
            if (date.Rows.Count > 0)
            {
                Bill bill = new Bill(date.Rows[0]);
                return bill.Id;

            }
            return -1;
        }

        /*=============================================================*/


        public void CheckOut(int id, int discount, float totalprice)
        {
            string query = "UPDATE dbo.HoaDon SET DateCheckOut = GETDATE(), TrangThai = 1, GiamGia = " + discount + ", TongTien = "+ totalprice + " WHERE idBanAn = " + id;
            DataProvaider.Instance.ExecuteNonQuery(query);
        }

        /*=============================================================*/



        public void InsertBill(int id)
        {
            DataProvaider.Instance.ExecuteNonQuery("EXEC USP_InsertBill @idTable",new object[]{id});
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvaider.Instance.ExecuteScalar("SELECT MAX(idHoaDon) from HoaDon");
            }
            catch
            {
                return 1;
            }
        }

        
        
    }
}
