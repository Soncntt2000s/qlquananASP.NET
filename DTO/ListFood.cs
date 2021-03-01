using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DoAn.DTO
{
    class ListFood
    {
        private int iD;
        private string ten;
        private int idCategory;
        private string foodCategory;

        public string FoodCategory
        {
            get { return foodCategory; }
            set { foodCategory = value; }
        }
        private float price;

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

        public ListFood(int id, string ten, int idCategory,string foodcategory, float price)
        {
            this.ID = id;
            this.Ten = ten;
            this.IdCategory = idCategory;
            this.FoodCategory = foodcategory;
            this.Price = price;
        }

        public ListFood(DataRow row)
        {
            this.ID = (int)row["Mã món ăn"];
            this.Ten = row["Tên món"].ToString();
            //this.IdCategory = (int)row["Mã danh mục"];
            this.FoodCategory = row["Danh mục"].ToString();
            this.Price = (int)Convert.ToDouble(row["Đơn giá"].ToString());
        }
    }
}
