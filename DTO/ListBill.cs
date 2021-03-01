using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DoAn.DTO
{
    class ListBill
    {
        private int id;
        private string tenBan;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int distcount;
        private float Tongtien;

        public float tongtien
        {
            get { return Tongtien; }
            set { Tongtien = value; }
        }


        public int Distcount
        {
            get { return distcount; }
            set { distcount = value; }
        }


        public DateTime? DateCheckOut
        {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }

        public DateTime? DateCheckIn
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }

        public string TenBan
        {
            get { return tenBan; }
            set { tenBan = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public ListBill(int id,string tenban, DateTime? dateCheckIn, DateTime? dateCheckOut, int giamgia, float tongtien)
        {
            this.Id = id;
            this.TenBan = tenban;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Distcount = giamgia;
            this.Tongtien = tongtien;
        }

        public ListBill(DataRow row)
        {
            this.Id = (int)row["idHoaDon"];
            this.TenBan = row["TenBan"].ToString();
            this.DateCheckIn = (DateTime?)row["DateCheckIn"];
            this.DateCheckOut = (DateTime?)row["DateCheckOut"];            
            this.Distcount = (int)row["GiamGia"];
            this.Tongtien = (float)Convert.ToDouble(row["Tongtien"]);
            
        }
    }
}
