using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoAn
{
    public partial class frmBillExport : Form
    {
        public frmBillExport()
        {
            InitializeComponent();
        }   
        
        private string sMaHD;
        public string MaHD
        {
            get { return sMaHD; }
            set { sMaHD = value; }
        }

        private void frmBillExport_Load(object sender, EventArgs e)
        {
            //DataTable tblill = DataProvaider.Instance.ExecuteQuery(MaHD);
            //EXPORT.rpt_BillExport rpt_BillExport = new EXPORT.rpt_BillExport();
            //rpt_BillExport.SetDataSource(tblill);
            //crystalReportViewer1.ReportSource = rpt_BillExport;
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            DataTable tblill = DataProvaider.Instance.ExecuteQuery(crystalReportViewer1.ReportSource.ToString());
            EXPORT.ds_Bill rpt_BillExport = new EXPORT.ds_Bill();          
            crystalReportViewer1.ReportSource = rpt_BillExport;
        }
    }
}
