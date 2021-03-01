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
using System.Globalization;

namespace DoAn
{
    public partial class frmMain : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type);  }
        }

        public frmMain(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            frmAccount frm = new frmAccount(loginAccount);
            frm.UpdateAccount += frm_UpdateAccount;
            loadTable();
            LoadCategory();
            LoadComboboxTable(cbb_SwitchTable);
        }
        public frmMain()
        {
            InitializeComponent();
        }
        
        #region Method
        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            AccountToolStripMenuItem.Text += " ( " + loginAccount.TenHienThi + " )";
        }

        /*=============================================================*/


        void LoadCategory()
        {
            List<Category> ListCategory = CategoryDAO.Instance.GetListCategory();
            cbb_Category.DataSource = ListCategory;
            cbb_Category.DisplayMember = "name";
        }

        /*=============================================================*/


        void LoadFoodListByCategoryID(int id)
        {
            
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbb_Food.DataSource = listFood;
            cbb_Food.DisplayMember = "ten";
        }

        /*=============================================================*/


        void loadTable()
        {
            flp_Table.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.loadTableList();
            foreach(Table item in tableList)
            {
                Button btn = new Button(){ Width = TableDAO.TableWidth,Height = TableDAO.TableHight};
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click+=btn_Click;
                btn.Tag = item;
                switch(item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.LightPink;
                        break;
                    default:
                        btn.BackColor = Color.LightGreen;
                        break;
                }
                flp_Table.Controls.Add(btn);
            }
        }

        /*=============================================================*/


        void ShowBill(int id)
        {
            lst_ViewBill.Items.Clear();
            float totalPrice = 0;
            List<BillByTable> listBillInfo = BillByTableDAO.Instance.GetListBillByTable(id);
            foreach (BillByTable item in listBillInfo)
            {
                ListViewItem lstItem = new ListViewItem(item.FoodName.ToString());
                lstItem.SubItems.Add(item.Count.ToString());
                lstItem.SubItems.Add(item.Price.ToString());
                lstItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lst_ViewBill.Items.Add(lstItem);
            }
            //CultureInfo culture = new CultureInfo("vi-VN");
            //txt_TongTien.Text = totalPrice.ToString("c", culture);
            if (totalPrice.ToString() == "")
                txt_TongTien.Text = "0";
            else
                txt_TongTien.Text = totalPrice.ToString();
            nmd_Discount.Value = 0;
            loadTable();
        
        }

        /*=============================================================*/


        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.loadTableList();
            cb.DisplayMember = "Name";
        }

        /*=============================================================*/

        void frm_UpdateAccount(object sender, DoAn.frmAccount.AccountEvent e)
        {
            AccountToolStripMenuItem.Text = "Tài khoản ( " + e.Acc.TenHienThi + " )";
        }

        #endregion

        #region Events
        void btn_Click(Object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).Id;
            lst_ViewBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
        /*=============================================================*/


        private void cbb_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cbb = sender as ComboBox;
            if (cbb.SelectedItem == null)
            {
                return;
            }
            Category selected = cbb.SelectedItem as Category;
            id = selected.ID;
            
            LoadFoodListByCategoryID(id);
        }
        /*=============================================================*/


        private void btn_ChuyenBan_Click(object sender, EventArgs e)
        {
            int id1 = (lst_ViewBill.Tag as Table).Id;
            int id2 = (cbb_SwitchTable.SelectedItem as Table).Id;
            int checkbill = BillDAO.Instance.GetUncheckBillIdbyTableID(id2);
            if (id1 == id2)
            {
                MessageBox.Show(string.Format("Bạn không thể chuyển từ bàn {0} sang chính bàn {1} được! \n Xin chọn hãy chọn bàn khác!"
                    ,id1,id2),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                if (checkbill != -1)
                {
                    if (MessageBox.Show((cbb_SwitchTable.SelectedItem as Table).Name + " đang có người bạn có thực sự muốn tiếp tục " +
                        "thực hiển chuyển bàn hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == System.Windows.Forms.DialogResult.Yes)
                    {
                        TableDAO.Instance.SwitchTable(id1, id2);
                        loadTable();
                    }
                }
                else
                {
                    if (MessageBox.Show(string.Format("Bạn có thực sự muốn chuyển bàn {0} sang bàn {1} hay không ?", 
                        (lst_ViewBill.Tag as Table).Id, (cbb_SwitchTable.SelectedItem as Table).Id), "Thông báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {

                        TableDAO.Instance.SwitchTable(id1, id2);
                        loadTable();
                    }
                }
            }
        }

        /*=============================================================*/


        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccount frm = new frmAccount(loginAccount);
            this.Hide();
            frm.UpdateAccount += frm_UpdateAccount;
            frm.ShowDialog();
            this.Show();
        }

        /*=============================================================*/


        

        private void btn_them_Click(object sender, EventArgs e)
        {
            Table table = lst_ViewBill.Tag as Table;
            int idBill;
            int foodID = (cbb_Food.SelectedItem as Food).ID;
            int count = (int)nmd_Count.Value;
            if (table == null)
            {
                MessageBox.Show("Bạn chưa chọn bàn !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                idBill = BillDAO.Instance.GetUncheckBillIdbyTableID(table.Id);
                if (count < 0)
                {
                    MessageBox.Show("Số Lượng bạn nhập sai!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                { 
                    if (count == 0)
                    {
                        MessageBox.Show("Bạn chưa nhập vào số lượng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (idBill == -1)
                        {
                            BillDAO.Instance.InsertBill(table.Id);
                            BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
                        }
                        else
                        {
                            BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
                        }
                    }
                }

                ShowBill(table.Id);
            }            
        }

        /*=============================================================*/


        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            Table table = lst_ViewBill.Tag as Table;
            int idBill = BillDAO.Instance.GetUncheckBillIdbyTableID(table.Id);
            int discount = (int)nmd_Discount.Value;
            float totalprice;
            if (nmd_Discount.Value != 0)
                totalprice = float.Parse(txt_TongTienGiamGia.Text);
            else
                totalprice = float.Parse(txt_TongTien.Text);
            if (idBill != -1)
            {
                if (MessageBox.Show("Bạn có chắc thanh toán hóa đơn cho bàn " + table.Name, "Thông báo xác nhận ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    MessageBox.Show("Thanh toán thành công ! Xin mời xem chi tiết phiếu", "Xác nhận ");
                    frmBillExport frm = new frmBillExport();
                    frm.ShowDialog();                  
                    BillDAO.Instance.CheckOut(table.Id, discount, totalprice);
                    ShowBill(table.Id);
                }
            }
            else
            {
                MessageBox.Show(table.Name + " trống không thể thực hiện thanh toán !", "Thông báo");
            }
        }

        /*=============================================================*/



        private void tmi_Dangxuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*=============================================================*/


        private void nmd_Discount_ValueChanged(object sender, EventArgs e)
        {
            float tongtien = float.Parse(txt_TongTien.Text);
            int giamgia = (int)nmd_Discount.Value;
            tongtien = tongtien - (tongtien / 100 * giamgia);
            txt_TongTienGiamGia.Text = tongtien.ToString();

        }

        /*=============================================================*/


        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_thanhtoan_Click(this, new EventArgs());
        }

        /*=============================================================*/


        private void chuyểnBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_ChuyenBan_Click(this, new EventArgs());
        }

        /*=============================================================*/


        private void thêmMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_them_Click(this, new EventArgs());
        }

        /*=============================================================*/


        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmin frm = new frmAdmin();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            loadTable();
        }

        #endregion

        private void hướngDẫnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, System.IO.Path.Combine(Application.StartupPath, "help.chm"));
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
