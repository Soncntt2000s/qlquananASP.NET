using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DoAn.DTO
{
    public class BillByTable
    {
        private int count;
        private string foodName;
        private float price;
        private float totalPrice;

        public float TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        public string FoodName
        {
            get { return foodName; }
            set { foodName = value; }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public BillByTable(int id, string foodName, float price, float totaPrice)
        {
            this.Count = count;
            this.FoodName = foodName;
            this.Price = price;
            this.TotalPrice = totaPrice;
        }

        public BillByTable(DataRow row)
        {
            this.Count = (int)row["SoLuong"];
            this.FoodName = row["TenMon"].ToString();
            this.Price = (int)Convert.ToDouble(row["DonGia"].ToString());
            this.TotalPrice = (int)Convert.ToDouble(row["thanhtien"].ToString());
        }
    }
}
