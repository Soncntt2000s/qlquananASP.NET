using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DoAn.DTO
{
    public class Food
    {
        private int iD;
        private string ten;
        private int idCategory;
        private float price;
        private int daXoaMon;

        public int DaXoaMon
        {
            get { return daXoaMon; }
            set { daXoaMon = value; }
        }

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        public int IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; }
        }

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public Food(int id, string ten, int idCategory, float price, int daXoaMon)
        {
            this.ID = id;
            this.Ten = ten;
            this.IdCategory = idCategory;
            this.Price = price;
            this.DaXoaMon = daXoaMon;
        }

        public Food(DataRow row)
        {
            this.ID = (int)row["idMonAn"];
            this.Ten = row["TenMon"].ToString();
            this.IdCategory = (int)row["idThucDonMon"];
            this.Price = (int)Convert.ToDouble(row["DonGia"].ToString());
            this.DaXoaMon = (int)Convert.ToDouble(row["DaXoaMon"].ToString());
        }

        
    }
}
