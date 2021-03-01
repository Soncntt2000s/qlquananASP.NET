using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;


namespace DoAn.DTO
{
    public class Bill
    {
        private int id;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int distcount;
        private int thanhtoan;
        private float Tongtien;

        public float tongtien
        {
            get { return Tongtien; }
            set { Tongtien = value; }
        }

        public int Thanhtoan
        {
            get { return thanhtoan; }
            set { thanhtoan = value; }
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
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Bill(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int giamgia, int thanhtoan,float tongtien)
        {
            this.Id = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Distcount = giamgia;
            this.Thanhtoan = thanhtoan;
            this.Tongtien = tongtien;
        }

        public Bill(DataRow row)
        {
            this.Id = (int)row["idHoaDon"];
            this.DateCheckIn = (DateTime?)row["DateCheckIn"];
            //var DateCheckOutTemp = (DateTime?)row["DateCheckOut"];
            //if (DateCheckOutTemp.ToString() != "")
            //{
            //    this.DateCheckOut = (DateTime?)DateCheckOutTemp;
            //}
            this.Distcount = (int)row["GiamGia"];
            this.Thanhtoan = (int)row["TrangThai"];
            var ThanhtoanTemp = (int)row["TrangThai"];
            if (ThanhtoanTemp.ToString() != "0")
            {
                this.Tongtien = (int)row["Tongtien"];
            }
            
        }

    }
}
