using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DoAn.DTO;
using System.Security.Cryptography;

namespace DoAn.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }


        /*=============================================================*/


        public bool Login(string userName, string passWord)
        {            
            string query = "USP_Login @userName ='"+userName+"' , @passWord = '"+passWord+"'";
            DataTable result = DataProvaider.Instance.ExecuteQuery(query, new object[] { userName, passWord });
            return result.Rows.Count > 0;
        }

        public Account GetAccountByUserName(string username)
        {
            DataTable data = DataProvaider.Instance.ExecuteQuery("SELECT * FROM dbo.NguoiDung WHERE TenNguoiDung = '"
                                                + username + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        /*=============================================================*/


        public List<Account> GetListAccount()
        {
            List<Account> lst = new List<Account>();
            string query = "SELECT * FROM dbo.NguoiDung WHERE  DaNghi = 0  ";
            DataTable data = DataProvaider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Account bill = new Account(item);
                lst.Add(bill);
            }

            return lst;
        }

        /*=============================================================*/


        public string CreateMD5(string md5)
        {
            MD5 mh = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(md5);
            byte[] hash = mh.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        /*=============================================================*/


        public void UpdateAccount(string userName, string name , long sdt, string phai, string diachi, int type)
        {
            string query = "USP_UpdateAccount @userName ,  @name ,  @sdt  , @phai  , @diachi  , @type  ";
            DataTable result = DataProvaider.Instance.ExecuteQuery(query,new object[] {userName, name , sdt , phai ,diachi , type });
        }

        /*=============================================================*/


        public bool UpdateAccountByUser(string userName, string name, long sdt, string phai, string diachi,string matkhau)
        {
            string query = "UpdateAccountByUser @userName ,  @name ,  @sdt  , @phai  , @diachi , @matkhau ";
            int result = DataProvaider.Instance.ExecuteNonQuery(query, new object[] { userName, name, sdt, phai, diachi,matkhau });
            return result > 0;
        }

        /*=============================================================*/


        public void InsertAccount(string userName, string name, long sdt, string phai, string diachi, string matkhau , int type)
        {
            string query = "USP_InsertAccount @userName ,  @name ,  @sdt  , @phai  , @diachi , @matkhau  , @type  ";
            DataTable result = DataProvaider.Instance.ExecuteQuery(query, new object[] { userName, name, sdt, phai, diachi, matkhau ,type });
        }

        /*=============================================================*/


        public void DeleteAccount(string userName)
        {
            string query = "USP_DeleteAccount @userName";
            DataTable result = DataProvaider.Instance.ExecuteQuery(query, new object[] { userName });
        }

        /*=============================================================*/


        public void ResetAccount(string userName )
        {
            string query = "USP_ResetAccount @userName";
            DataTable result = DataProvaider.Instance.ExecuteQuery(query, new object[] { userName});
        }

        /*=============================================================*/


        public int UpDatePassWordAccount(string userName, string pass)
        {
            string query = "USP_UpDatePassWordAccount @userName , @pass";
            int result = DataProvaider.Instance.ExecuteNonQuery(query, new object[] { userName,pass });
            return result;
        }

        /*=============================================================*/


        public int checkOutPassWord(string userName, string pass)
        {
            string query = "USP_checkOutPassWord @userName , @pass";
            DataTable date = DataProvaider.Instance.ExecuteQuery(query, new object[] { userName, pass });
            if (date.Rows.Count > 0)
            {
                return 1;

            }
            return -1;
        }

    }
}
