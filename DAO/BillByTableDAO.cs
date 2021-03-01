using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoAn.DTO;
using System.Data;

namespace DoAn.DAO
{
    public class BillByTableDAO
    {
        private static BillByTableDAO instance;

        public static BillByTableDAO Instance
        {
            get { if(instance == null) instance = new BillByTableDAO(); return BillByTableDAO.instance; }
            private set { BillByTableDAO.instance = value; }
        }

        private BillByTableDAO() { }

        public List<BillByTable> GetListBillByTable(int id)
        {
            List<BillByTable> listBillByTable = new List<BillByTable>();
            string query = "SELECT f.TenMon, bi.SoLuong, f.DonGia,f.DonGia*bi.SoLuong AS thanhtien FROM dbo.ChiTietHoaDon AS bi, dbo.HoaDon AS b, dbo.MonAn AS f WHERE bi.idHoaDon = b.idHoaDon AND bi.idMonAn = f.idMonAn AND b.TrangThai = 0 AND b.idBanAn = '" + id + "'";
            DataTable data = DataProvaider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                BillByTable bbtable = new BillByTable(item);
                listBillByTable.Add(bbtable);

            }
            return listBillByTable;
        }
    }
}
