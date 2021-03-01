using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DoAn.DTO
{
    public class Account 
    {
        private string tenNguoiDung;
        private string tenHienThi;
        private long sDT;
        private string phai;
        private string diaChi;
        private string matKhau;
        private int type;

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string Phai
        {
            get { return phai; }
            set { phai = value; }
        }

        public long SDT
        {
            get { return sDT; }
            set { sDT = value; }
        }

        public string TenHienThi
        {
            get { return tenHienThi; }
            set { tenHienThi = value; }
        }

        public string TenNguoiDung
        {
            get { return tenNguoiDung; }
            set { tenNguoiDung = value; }
        }
        public Account(string tenNguoiDung, string tenHienThi, long sDT, string phai, string diaChi, string matKhau, int type)
        {
            this.TenNguoiDung = tenNguoiDung;
            this.TenHienThi = TenHienThi;
            this.SDT = sDT;
            this.Phai = phai;
            this.DiaChi = diaChi;
            this.MatKhau = matKhau;
            this.Type = type;
        }

        public Account(DataRow row)
        {
            this.TenNguoiDung = row["TenNguoiDung"].ToString();
            this.TenHienThi = row["TenHienThi"].ToString();
            var checkSDT = row["SDT"];
            if(checkSDT != null)
                this.SDT = (long)Convert.ToDouble(checkSDT);
            var checkPhai = row["Phai"].ToString();
            if (checkPhai != "")
                this.Phai = checkPhai;
            var checkDiaChi = row["DiaChi"].ToString();
            if (checkDiaChi != "")
                this.DiaChi = checkDiaChi;
            this.MatKhau = row["MatKhau"].ToString();
            this.Type = (int)row["Type"];
        }
    }
}
