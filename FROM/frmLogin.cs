using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DoAn.DAO;
using DoAn.DTO;

namespace DoAn
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*=============================================================*/

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn thực sự muốn thoát trương trình ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }


        /*=============================================================*/


        private void btn_login_Click(object sender, EventArgs e)
        {
            string user = txt_User.Text;
            string pass = AccountDAO.Instance.CreateMD5(txt_PassWord.Text);
            if (Login(user, pass))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(user);
                frmMain frm = new frmMain(loginAccount);
                this.Hide();
                frm.ShowDialog();
                this.Show();
                txt_User.Text = "";
                txt_PassWord.Text = "";
                txt_User.Focus();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặt mật khẩu !!!","Thông báo",MessageBoxButtons.OK);
            }
        
        }

        /*=============================================================*/


        bool Login(string userName, string passWord)
        {

            return AccountDAO.Instance.Login(userName , passWord);
        }

    }
}
