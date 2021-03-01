namespace DoAn
{
    partial class frmAccount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.cbb_TTPhai = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.panel29 = new System.Windows.Forms.Panel();
            this.btn_DoiMatKhau = new System.Windows.Forms.Button();
            this.txt_TTMatKhau = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.panel28 = new System.Windows.Forms.Panel();
            this.txt_TTDiaChi = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.txt_TTSDT = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.txt_TenHT = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.txt_TenTK = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_TTMatKhauMoi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_TTNLMatKhauMoi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel13.SuspendLayout();
            this.panel29.SuspendLayout();
            this.panel28.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Update
            // 
            this.btn_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.Location = new System.Drawing.Point(271, 10);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(74, 36);
            this.btn_Update.TabIndex = 4;
            this.btn_Update.Text = "Cập nhật";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Thoat.Location = new System.Drawing.Point(453, 10);
            this.btn_Thoat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(74, 36);
            this.btn_Thoat.TabIndex = 5;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(151, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 29);
            this.label5.TabIndex = 13;
            this.label5.Text = "Thông tin tài khoản";
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.cbb_TTPhai);
            this.panel13.Controls.Add(this.label24);
            this.panel13.Controls.Add(this.label25);
            this.panel13.Location = new System.Drawing.Point(9, 247);
            this.panel13.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(538, 54);
            this.panel13.TabIndex = 11;
            // 
            // cbb_TTPhai
            // 
            this.cbb_TTPhai.DisplayMember = "Nam";
            this.cbb_TTPhai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_TTPhai.FormattingEnabled = true;
            this.cbb_TTPhai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbb_TTPhai.Location = new System.Drawing.Point(186, 23);
            this.cbb_TTPhai.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbb_TTPhai.Name = "cbb_TTPhai";
            this.cbb_TTPhai.Size = new System.Drawing.Size(342, 21);
            this.cbb_TTPhai.TabIndex = 3;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(3, 23);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(50, 17);
            this.label24.TabIndex = 2;
            this.label24.Text = "Phái :";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(3, 23);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(0, 17);
            this.label25.TabIndex = 2;
            // 
            // panel29
            // 
            this.panel29.Controls.Add(this.btn_DoiMatKhau);
            this.panel29.Controls.Add(this.btn_Thoat);
            this.panel29.Controls.Add(this.btn_Update);
            this.panel29.Location = new System.Drawing.Point(9, 562);
            this.panel29.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(536, 59);
            this.panel29.TabIndex = 10;
            // 
            // btn_DoiMatKhau
            // 
            this.btn_DoiMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DoiMatKhau.Location = new System.Drawing.Point(350, 10);
            this.btn_DoiMatKhau.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_DoiMatKhau.Name = "btn_DoiMatKhau";
            this.btn_DoiMatKhau.Size = new System.Drawing.Size(99, 37);
            this.btn_DoiMatKhau.TabIndex = 6;
            this.btn_DoiMatKhau.Text = "Đổi mật khẩu";
            this.btn_DoiMatKhau.UseVisualStyleBackColor = true;
            this.btn_DoiMatKhau.Click += new System.EventHandler(this.btn_DoiMatKhau_Click);
            // 
            // txt_TTMatKhau
            // 
            this.txt_TTMatKhau.Location = new System.Drawing.Point(186, 20);
            this.txt_TTMatKhau.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_TTMatKhau.Name = "txt_TTMatKhau";
            this.txt_TTMatKhau.Size = new System.Drawing.Size(342, 20);
            this.txt_TTMatKhau.TabIndex = 0;
            this.txt_TTMatKhau.UseSystemPasswordChar = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(3, 20);
            this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(84, 17);
            this.label28.TabIndex = 2;
            this.label28.Text = "Mật khẩu :";
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.txt_TTDiaChi);
            this.panel28.Controls.Add(this.label27);
            this.panel28.Location = new System.Drawing.Point(9, 306);
            this.panel28.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(538, 61);
            this.panel28.TabIndex = 6;
            // 
            // txt_TTDiaChi
            // 
            this.txt_TTDiaChi.Location = new System.Drawing.Point(186, 23);
            this.txt_TTDiaChi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_TTDiaChi.Name = "txt_TTDiaChi";
            this.txt_TTDiaChi.Size = new System.Drawing.Size(342, 20);
            this.txt_TTDiaChi.TabIndex = 0;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(3, 23);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(68, 17);
            this.label27.TabIndex = 2;
            this.label27.Text = "Địa chỉ :";
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.txt_TTSDT);
            this.panel18.Controls.Add(this.label26);
            this.panel18.Location = new System.Drawing.Point(9, 181);
            this.panel18.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(538, 61);
            this.panel18.TabIndex = 7;
            // 
            // txt_TTSDT
            // 
            this.txt_TTSDT.Location = new System.Drawing.Point(186, 23);
            this.txt_TTSDT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_TTSDT.Name = "txt_TTSDT";
            this.txt_TTSDT.Size = new System.Drawing.Size(342, 20);
            this.txt_TTSDT.TabIndex = 0;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(3, 23);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(104, 17);
            this.label26.TabIndex = 2;
            this.label26.Text = "Số điện thoại";
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.txt_TenHT);
            this.panel15.Controls.Add(this.label8);
            this.panel15.Location = new System.Drawing.Point(9, 115);
            this.panel15.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(538, 61);
            this.panel15.TabIndex = 8;
            // 
            // txt_TenHT
            // 
            this.txt_TenHT.Location = new System.Drawing.Point(186, 23);
            this.txt_TenHT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_TenHT.Name = "txt_TenHT";
            this.txt_TenHT.Size = new System.Drawing.Size(342, 20);
            this.txt_TenHT.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 23);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Tên hiển thị : ";
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.txt_TenTK);
            this.panel16.Controls.Add(this.label18);
            this.panel16.Location = new System.Drawing.Point(9, 50);
            this.panel16.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(538, 61);
            this.panel16.TabIndex = 9;
            // 
            // txt_TenTK
            // 
            this.txt_TenTK.Location = new System.Drawing.Point(186, 23);
            this.txt_TenTK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_TenTK.Name = "txt_TenTK";
            this.txt_TenTK.ReadOnly = true;
            this.txt_TenTK.Size = new System.Drawing.Size(342, 20);
            this.txt_TenTK.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(3, 23);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(123, 17);
            this.label18.TabIndex = 2;
            this.label18.Text = "Tên tài khoản  :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_TTMatKhau);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Location = new System.Drawing.Point(9, 372);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 58);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_TTMatKhauMoi);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(9, 436);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(536, 58);
            this.panel2.TabIndex = 3;
            // 
            // txt_TTMatKhauMoi
            // 
            this.txt_TTMatKhauMoi.Location = new System.Drawing.Point(186, 20);
            this.txt_TTMatKhauMoi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_TTMatKhauMoi.Name = "txt_TTMatKhauMoi";
            this.txt_TTMatKhauMoi.Size = new System.Drawing.Size(342, 20);
            this.txt_TTMatKhauMoi.TabIndex = 0;
            this.txt_TTMatKhauMoi.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhập lại mới :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txt_TTNLMatKhauMoi);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(9, 499);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(536, 58);
            this.panel3.TabIndex = 3;
            // 
            // txt_TTNLMatKhauMoi
            // 
            this.txt_TTNLMatKhauMoi.Location = new System.Drawing.Point(186, 20);
            this.txt_TTNLMatKhauMoi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_TTNLMatKhauMoi.Name = "txt_TTNLMatKhauMoi";
            this.txt_TTNLMatKhauMoi.Size = new System.Drawing.Size(342, 20);
            this.txt_TTNLMatKhauMoi.TabIndex = 0;
            this.txt_TTNLMatKhauMoi.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nhập lại mật khẩu mới :";
            // 
            // frmAccount
            // 
            this.AcceptButton = this.btn_Update;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Thoat;
            this.ClientSize = new System.Drawing.Size(568, 609);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel29);
            this.Controls.Add(this.panel28);
            this.Controls.Add(this.panel18);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.panel16);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin cá nhân";
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel29.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.ComboBox cbb_TTPhai;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel panel29;
        private System.Windows.Forms.TextBox txt_TTMatKhau;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Panel panel28;
        private System.Windows.Forms.TextBox txt_TTDiaChi;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.TextBox txt_TTSDT;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.TextBox txt_TenHT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.TextBox txt_TenTK;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_TTMatKhauMoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_TTNLMatKhauMoi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_DoiMatKhau;
    }
}