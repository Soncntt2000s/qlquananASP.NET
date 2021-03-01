using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DoAn.DTO
{
    public class Category
    {
        private int iD;
        private string name;
        private int daXoaThucDon;

        public int DaXoaThucDon
        {
            get { return daXoaThucDon; }
            set { daXoaThucDon = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public Category(int id, string name, int daXoaThucDon)
        {
            this.ID = id;
            this.Name = name;
            this.DaXoaThucDon = daXoaThucDon;
        }

        public Category(DataRow row)
        {
            this.ID = (int)row["idThucDon"];
            this.Name = row["LoaiThucPham"].ToString();
            this.DaXoaThucDon = (int)row["DaXoaThucDon"];
        }
    }
}
