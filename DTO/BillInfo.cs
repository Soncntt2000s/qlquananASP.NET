using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DoAn.DTO
{
    public class BillInfo
    {
        private int iDFood;
        private int count;
        private int iDBill;
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public int IDBill
        {
            get { return iDBill; }
            set { iDBill = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public int IDFood
        {
            get { return iDFood; }
            set { iDFood = value; }
        }

        public BillInfo(int id, int idBill, int idFood, int count)
        {
            this.ID = id;
            this.IDBill = iDBill;
            this.IDFood = iDFood;
            this.Count = count;
        }

        public BillInfo(DataRow row)
        {
            this.ID = (int)row["idChiTiet"];
            this.IDBill = (int)row["idHoaDon"];
            this.IDFood = (int)row["idMonAn"];
            this.Count = (int)row["SoLuong"];        
        }
    }
}
