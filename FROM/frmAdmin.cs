using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DoAn.DAO;
using System.Windows.Forms;
using DoAn.DTO;

namespace DoAn
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
            LoadDateTimePickerBill();
            LoadListBillByDate(dpk_NgayVao.Value, dpk_NgayRa.Value);
            LoadInFrom();
            
        }

        #region medthods
        void LoadInFrom()
        {
            LoadDataAccount();
            LoadListFoods();
            LoadListTable();
            LoadListCategory();
        }

        /*=============================================================*/


        void XoaTrang()
        {
            txt_TenTaiKhoan.Text = "";
            txt_TenHienThi.Text = "";
            txt_SDT.Text = "";
            cbb_Phai.SelectedIndex = 0;
            txt_DiaChi.Text = "";
            txt_MatKhau.Text = "";
            cbb_LoaiTaiKhoan.SelectedIndex = 0;
            txt_TenBan.Text = "";
            cbb_TrangThai.SelectedIndex = 0;
            txt_idBanAn.Text = "";
            txt_idDanhMuc.Text = "";
            txt_TenDanhMuc.Text = "";
            txt_ID.Text = "";
            txt_TenMon.Text = "";
            txt_Gia.Text = "";
        }

        /*=============================================================*/


        void LoadDataAccount()
        {
            lst_Account.Items.Clear();
            List<Account> lst = AccountDAO.Instance.GetListAccount();
            foreach (Account item in lst)
            {
                ListViewItem lstItem = new ListViewItem(item.TenNguoiDung.ToString());
                lstItem.SubItems.Add(item.TenHienThi.ToString());
                lstItem.SubItems.Add(item.SDT.ToString());
                lstItem.SubItems.Add(item.Phai.ToString());
                lstItem.SubItems.Add(item.DiaChi.ToString());
                lstItem.SubItems.Add(item.MatKhau.ToString());
                lstItem.SubItems.Add(item.Type.ToString());
                lst_Account.Items.Add(lstItem);
            }
            XoaTrang();            
        }

        /*=============================================================*/


        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Today;
            dpk_NgayVao.Value = new DateTime(today.Year,today.Month,1);
            dpk_NgayRa.Value = dpk_NgayVao.Value.AddMonths(1).AddDays(-1);
        }

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            lst_Bill.Items.Clear();
            float danhthu = 0;
            List<ListBill> lst = ListBillDAO.Instance.GetListBillByDate(checkIn, checkOut.AddDays(1));
            foreach (ListBill item in lst)
            {
                ListViewItem lstItem = new ListViewItem(item.Id.ToString());
                lstItem.SubItems.Add(item.TenBan.ToString());
                lstItem.SubItems.Add(item.DateCheckIn.ToString());
                lstItem.SubItems.Add(item.DateCheckOut.ToString());
                lstItem.SubItems.Add(item.Distcount.ToString());
                lstItem.SubItems.Add(item.tongtien.ToString());
                danhthu += item.tongtien;
                lst_Bill.Items.Add(lstItem);
            }
            txt_Danhthu.Text = danhthu.ToString();
        }

        /*=============================================================*/


        void LoadListFoods()
        {
            lst_Foods.Items.Clear();
            List<Food> lst = FoodDAO.Instance.GetListFood();
            foreach (Food item in lst)
            {
                ListViewItem lstItem = new ListViewItem(item.ID.ToString());
                lstItem.SubItems.Add(item.Ten.ToString());
                lstItem.SubItems.Add(item.IdCategory.ToString());
                lstItem.SubItems.Add(item.Price.ToString());
                lst_Foods.Items.Add(lstItem);
            }
            cbb_Category.DataSource = CategoryDAO.Instance.GetListCategory();
            cbb_Category.DisplayMember = "name";
            XoaTrang();
        }

        /*=============================================================*/


        void LoadListCategory()
        {
            lst_Category.Items.Clear();
            List<Category> lst = CategoryDAO.Instance.GetListCategory();
            foreach (Category item in lst)
            {
                ListViewItem lstItem = new ListViewItem(item.ID.ToString());
                lstItem.SubItems.Add(item.Name.ToString());
                lst_Category.Items.Add(lstItem);
            }
            XoaTrang();
        }

        /*=============================================================*/


        void LoadListTable()
        {
            lst_TableFoods.Items.Clear();
            List<Table> lst = TableDAO.Instance.loadTableList();
            foreach (Table item in lst)
            {
                ListViewItem lstItem = new ListViewItem(item.Id.ToString());
                lstItem.SubItems.Add(item.Name.ToString());
                lstItem.SubItems.Add(item.Status.ToString());
                lst_TableFoods.Items.Add(lstItem);
            }
            XoaTrang();            
        }


        #endregion

        #region event
            #region ListBill
            private void btn_ViewBill_Click(object sender, EventArgs e)
            {
                LoadListBillByDate(dpk_NgayVao.Value, dpk_NgayRa.Value);
            }

            #endregion

            #region ListFoods
            private void lst_Foods_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
            {

                var item = e.Item;
                txt_ID.Text = item.Text;
                txt_TenMon.Text = item.SubItems[1].Text;
                int id = Convert.ToInt32(item.SubItems[2].Text);
                Category category = CategoryDAO.Instance.GetCategoryByID(id);
                var count = cbb_Category.Items.Count;
                //cbb_Category.SelectedIndex = category.ID ;
                txt_Gia.Text = item.SubItems[3].Text;
            }

            /*=============================================================*/


            private void btn_Them_Click(object sender, EventArgs e)
            {
                //int idmonan = (int)Convert.ToDouble(txt_ID.Text);
                string tenmon = txt_TenMon.Text;
                string danhmuc = cbb_Category.Text;
                int iddanhmuc = CategoryDAO.Instance.GetIdCategoryByName(danhmuc);
                if (iddanhmuc == -1) MessageBox.Show("Dã xãy ra lỗi khi chọn danh mục!", "Thông báo", MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                else
                {
                    float gia = (float)Convert.ToDouble(txt_Gia.Text);
                    FoodDAO.Instance.InsertFoods(tenmon, iddanhmuc, gia);
                    LoadListFoods();
                }
            }

            /*=============================================================*/


            private void btn_Xoa_Click(object sender, EventArgs e)
            {
                int idmonan = (int)Convert.ToDouble(txt_ID.Text);
                FoodDAO.Instance.DeleteFoods(idmonan);
                LoadListFoods();
            }

            /*=============================================================*/


            private void btn_Sua_Click(object sender, EventArgs e)
            {
                int idmonan = (int)Convert.ToDouble(txt_ID.Text);
                string tenmon = txt_TenMon.Text;
                string danhmuc = cbb_Category.Text;
                int iddanhmuc = CategoryDAO.Instance.GetIdCategoryByName(danhmuc);
                float gia = (float)Convert.ToDouble(txt_Gia.Text);
                FoodDAO.Instance.UpdateFoods(idmonan, tenmon, iddanhmuc, gia);
                LoadListFoods();
            }

            /*=============================================================*/


            private void btn_Xem_Click(object sender, EventArgs e)
            {
                LoadListFoods();
            }

            /*=============================================================*/


            private void btn_Tim_Click(object sender, EventArgs e)
            {
                string name = txt_MonCanTim.Text;
                lst_Foods.Items.Clear();
                List<Food> lst = FoodDAO.Instance.SearchFoodByName(name);
                foreach (Food item in lst)
                {
                    ListViewItem lstItem = new ListViewItem(item.ID.ToString());
                    lstItem.SubItems.Add(item.Ten.ToString());
                    lstItem.SubItems.Add(item.IdCategory.ToString());
                    lstItem.SubItems.Add(item.Price.ToString());
                    lst_Foods.Items.Add(lstItem);
                }
                cbb_Category.DataSource = CategoryDAO.Instance.GetListCategory();
                cbb_Category.DisplayMember = "name";
                txt_MonCanTim.Text = "";
            }

            #endregion

            #region ListCategory
            private void lst_Category_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
            {
                var item = e.Item;
                txt_idDanhMuc.Text = item.Text;
                txt_TenDanhMuc.Text = item.SubItems[1].Text;
            }

            /*=============================================================*/


            private void btn_ThemCategory_Click(object sender, EventArgs e)
            {
                string tendanhmuc = txt_TenDanhMuc.Text;
                if (tendanhmuc == "")
                {
                    MessageBox.Show("Bạn chưa điền tên danh mục!", "Thông báo");
                    return;
                }
                CategoryDAO.Instance.InsertCategory(tendanhmuc);
                LoadListCategory();
                LoadListCategory();
            }

            /*=============================================================*/



            private void btn_XoaCategory_Click(object sender, EventArgs e)
            {
                int madanhmuc = (int)Convert.ToDouble(txt_idDanhMuc.Text);
                if (madanhmuc.ToString() == "")
                {
                    MessageBox.Show("Bạn chưa chọn danh mục cần xóa!", "Thông báo");
                    return;
                }
                CategoryDAO.Instance.DeleteCategory(madanhmuc);
                LoadListCategory();
            }

            /*=============================================================*/



            private void btn_SuaCategory_Click(object sender, EventArgs e)
            {
                int madanhmuc = Convert.ToInt32(txt_idDanhMuc.Text);
                string tendanhmuc = txt_TenDanhMuc.Text;
                if (tendanhmuc == "")
                {
                    MessageBox.Show("Bạn chưa điền tên danh mục!", "Thông báo");
                    return;
                }
                if (madanhmuc.ToString() == "")
                {
                    MessageBox.Show("Bạn chưa chọn danh mục cần sửa!", "Thông báo");
                    return;
                }
                LoadListCategory();
                CategoryDAO.Instance.UpdateCategory(madanhmuc, tendanhmuc);
                LoadListCategory();
            }

            /*=============================================================*/


            private void btn_XemCategory_Click(object sender, EventArgs e)
            {
                LoadListCategory();

            }
            #endregion

            #region ListTable
            private void lst_TableFoods_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
            {
                var item = e.Item;
                txt_idBanAn.Text = item.Text;
                txt_TenBan.Text = item.SubItems[1].Text;
                cbb_TrangThai.Text = item.SubItems[2].Text;
            }

            /*=============================================================*/


            private void btn_ThemBan_Click(object sender, EventArgs e)
            {
                string tenban = txt_TenBan.Text;
                string trangthai = cbb_TrangThai.Text;
                if (tenban == "")
                {
                    MessageBox.Show("Bạn chưa điền tên bàn!", "Thông báo");
                    return;
                }
                if (trangthai == "")
                {
                    MessageBox.Show("Bạn chưa chọn trạng thái!", "Thông báo");
                    return;
                }
                TableDAO.Instance.InsertTable(tenban, trangthai);
                LoadListTable();
            }

            /*=============================================================*/


            private void btn_XoaBan_Click(object sender, EventArgs e)
            {
                string tenban = txt_TenBan.Text;
                if (tenban == "")
                {
                    MessageBox.Show("Bạn chưa chọn bàn cần xóa!", "Thông báo");
                    return;
                }
                TableDAO.Instance.DeleteTable(tenban);
                LoadListTable();
            }

            /*=============================================================*/


            private void btn_SuaBan_Click(object sender, EventArgs e)
            {
                string maban = txt_idBanAn.Text;
                string tenban = txt_TenBan.Text;
                string trangthai = cbb_TrangThai.Text;
                if (tenban == "")
                {
                    MessageBox.Show("Bạn chưa điền tên bàn!", "Thông báo");
                    return;
                }
                if (trangthai == "")
                {
                    MessageBox.Show("Bạn chưa chọn trạng thái!", "Thông báo");
                    return;
                }
                if (maban == "")
                {
                    MessageBox.Show("Bạn chưa chọn bàn cần xóa!", "Thông báo");
                    return;
                }
                TableDAO.Instance.UpdateTable(maban, tenban, trangthai);
                LoadListTable();

            }

            /*=============================================================*/


            private void btn_XemBan_Click(object sender, EventArgs e)
            {
                LoadListTable();
            }

            #endregion

            #region ListAccount
            private void lst_Account_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
            {
                var item = e.Item;
                txt_TenTaiKhoan.Text = item.Text;
                txt_TenHienThi.Text = item.SubItems[1].Text;
                txt_SDT.Text = item.SubItems[2].Text;
                cbb_Phai.Text = item.SubItems[3].Text;
                txt_DiaChi.Text = item.SubItems[4].Text;
                //txt_MatKhau.Text = item.SubItems[5].Text;
                cbb_LoaiTaiKhoan.Text = item.SubItems[6].Text;

            }

            /*=============================================================*/


            private void btn_ThemAccount_Click(object sender, EventArgs e)
            {
                string id = txt_TenTaiKhoan.Text;
                string name = txt_TenHienThi.Text;
                long sdt = (long)Convert.ToDouble(txt_SDT.Text);
                string phai = cbb_Phai.Text;
                if (phai == "")
                {
                    MessageBox.Show("Bạn chưa chọn phái!");
                    return;
                }
                string diachi = txt_DiaChi.Text;
                string matkhau = AccountDAO.Instance.CreateMD5(txt_MatKhau.Text);
                int type = Convert.ToInt32(cbb_LoaiTaiKhoan.Text);
                if (type.ToString() == "")
                {
                    MessageBox.Show("Bạn chưa chọn phái!");
                    return;
                }

                AccountDAO.Instance.InsertAccount(id, name, sdt, phai, diachi, matkhau, type);
                LoadDataAccount();
            }

            /*=============================================================*/


            private void btn_XoaAccount_Click(object sender, EventArgs e)
            {
                string id = txt_TenTaiKhoan.Text;
                AccountDAO.Instance.DeleteAccount(id);
                LoadDataAccount();
            }

            /*=============================================================*/


            private void btn_SuaAccount_Click(object sender, EventArgs e)
            {
                string id = txt_TenTaiKhoan.Text;
                string name = txt_TenHienThi.Text;
                long sdt = (long)Convert.ToDouble(txt_SDT.Text);
                string phai = cbb_Phai.Text;
                if (phai == "")
                {
                    MessageBox.Show("Bạn chưa chọn phái!");
                    return;
                }
                string diachi = txt_DiaChi.Text;
                string type = cbb_LoaiTaiKhoan.Text;
                if (type == "")
                {
                    MessageBox.Show("Bạn chưa chọn phái!");
                    return;
                }
                AccountDAO.Instance.UpdateAccount(id, name, sdt, phai, diachi, (int)Convert.ToDouble(type));
                LoadDataAccount();
            }

            /*=============================================================*/



            private void btn_ResetAccount_Click(object sender, EventArgs e)
            {
                XoaTrang();
            }

            /*=============================================================*/


            private void btn_DatLai_Click(object sender, EventArgs e)
            {
                string id = txt_TenTaiKhoan.Text;
                AccountDAO.Instance.ResetAccount(id);
                LoadDataAccount();
            }

        #endregion

        #endregion

        private void frmAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
       


        

        
      

        

        
        


        
        

        

      

        
       

       

   