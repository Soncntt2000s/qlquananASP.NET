using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DoAn.DTO
{
    public class Table
    {
        private int id;
        private string name;
        private string status;
        private int daXoaBan;

        public int DaXoaBan
        {
            get { return daXoaBan; }
            set { daXoaBan = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }


        public Table(int id, string name, string status, int daXoaBan)
        {
            this.Id = id;
            this.Name = name;
            this.Status = status;
            this.DaXoaBan = daXoaBan;
        }

        public Table(DataRow row)
        {
            this.Id = (int)row["idBan"];
            this.Name = row["TenBan"].ToString();
            this.Status = row["TrangThai"].ToString();
            this.DaXoaBan = (int)row["DaXoaBan"];
        }
    }
}
