using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DoAn.DTO;
using DoAn.DAO;

namespace DoAn
{
    public partial class frmAccount : Form
    {

        private bool checkUpdatePassWord = false;
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }
        public class AccountEvent : EventArgs
        {
            private Account acc;

            public Account Acc
            {
                get { return acc; }
                set { acc = value; }
            }

            public AccountEvent(Account acc)
            {
                this.Acc = acc;
            }
        }
        

        public frmAccount(Account acc)
        {
            
            InitializeComponent();
            this.LoginAccount = acc;
            Account loginAccount = AccountDAO.Instance.GetAccountByUserName(acc.TenNguoiDung);
            ChangeAccount(loginAccount); 
            khoatxt(checkUpdatePassWord);
        }
        #region methods
        void ChangeAccount(Account menber)
        {
            txt_TenHT.Select();
            txt_TenTK.Text = menber.TenNguoiDung;
            txt_TenHT.Text = menber.TenHienThi;
            txt_TTSDT.Text = menber.SDT.ToString();
            cbb_TTPhai.Text = menber.Phai;
            txt_TTDiaChi.Text = menber.DiaChi;
            txt_TTMatKhau.Text = "";

        }

        /*=============================================================*/


        private void XoaTrang()
        {
            txt_TTMatKhau.Text = "";
            txt_TTMatKhauMoi.Text = "";
            txt_TTNLMatKhauMoi.Text = "";
        }

        /*=============================================================*/


        private void khoatxt(bool checkUpdate)
        {
            txt_TenTK.Enabled = false;
            txt_TTMatKhauMoi.Enabled = checkUpdate;
            txt_TTNLMatKhauMoi.Enabled = checkUpdate;
            checkUpdatePassWord = checkUpdate;
            txt_TenHT.Enabled = !checkUpdate;
            txt_TTSDT.Enabled = !checkUpdate;
            txt_TTDiaChi.Enabled = !checkUpdate;
            cbb_TTPhai.Enabled = !checkUpdate;
            txt_TTDiaChi.Enabled = !checkUpdate;
        }

        #endregion

        #region events
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            btn_Update.Enabled = true;
            this.Close();
        }

        /*=============================================================*/


        private void btn_Update_Click(object sender, EventArgs e)
        {
            string username = txt_TenTK.Text;
            string name = txt_TenHT.Text;
            long sdt = (long)Convert.ToDouble(txt_TTSDT.Text);
            string phai = cbb_TTPhai.Text;
            if (phai == "")
            {
                MessageBox.Show("Bạn chưa chọn phái!");
                return;
            }
            string diachi = txt_TTDiaChi.Text;
            string matkhau = AccountDAO.Instance.CreateMD5(txt_TTMatKhau.Text);
            if (AccountDAO.Instance.UpdateAccountByUser(username, name, sdt, phai, diachi, matkhau))
            {
                MessageBox.Show("Cập nhật thành công.", "Thông báo");
                updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(username)));
            }
            else MessageBox.Show("Cập nhật thất bại.", "Thông báo");
        }

        /*=============================================================*/


        private void btn_DoiMatKhau_Click(object sender, EventArgs e)
        {
            if (checkUpdatePassWord == false)
            {
                khoatxt(true);
                btn_Update.Enabled = false;
            }
            else
            {
                string id = txt_TenTK.Text;
                string OutPass = AccountDAO.Instance.CreateMD5(txt_TTMatKhau.Text);
                string NewPass = AccountDAO.Instance.CreateMD5(txt_TTMatKhauMoi.Text);
                string NewPass2 = AccountDAO.Instance.CreateMD5(txt_TTNLMatKhauMoi.Text);
                if (txt_TTMatKhau.Text == "")
                {
                    MessageBox.Show("Chưa nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_TTMatKhau.Focus();
                    return;
                }
                if (txt_TTMatKhauMoi.Text == "")
                {
                    MessageBox.Show("Chưa nhập mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_TTMatKhauMoi.Focus();
                    return;
                }
                if (txt_TTNLMatKhauMoi.Text == "")
                {
                    MessageBox.Show("Chưa nhập lại mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_TTNLMatKhauMoi.Focus();
                    return;
                }
                if (NewPass != NewPass2)
                {
                    MessageBox.Show("Mật khẩu mới không trùng nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    XoaTrang();
                }
                else
                {
                    int a = AccountDAO.Instance.checkOutPassWord(id, OutPass);
                    if (a > 0)
                    {
                        if (AccountDAO.Instance.UpDatePassWordAccount(id, NewPass) < 0)
                        {
                            MessageBox.Show("Đổi mật khẩu thất bại!", "Thông báo");
                            XoaTrang();
                        }
                        else
                        {
                            MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");
                            XoaTrang();
                            btn_Update.Enabled = true;
                            khoatxt(false);
                        }
                    }
                    else MessageBox.Show("Mật khẩu không đúng!", "Thông báo");
                }
            }
        }

        #endregion      

    }
}
