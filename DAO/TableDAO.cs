using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoAn.DTO;
using System.Data;

namespace DoAn.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if(instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        private TableDAO() { }

        public static int TableWidth = 80;
        public static int TableHight = 80;

        public List<Table> loadTableList()
        {
            List<Table> tablelist = new List<Table>();
            DataTable data = DataProvaider.Instance.ExecuteQuery("USP_GetTableList");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tablelist.Add(table);
            }
            return tablelist;
        }

        public void SwitchTable(int id1, int id2)
        {
            DataProvaider.Instance.ExecuteQuery("USP_SwitchTable @idTable1 , @idTable2 ", new object[] { id1, id2 });
        }
        public void InsertTable(string tenban, string trangthai)
        {
            string query = "USP_InsertTable @tenban , @trangthai ";
            DataProvaider.Instance.ExecuteNonQuery(query, new object[] { tenban, trangthai });
        }

        public void DeleteTable(string tenban)
        {
            string query = "USP_DeleteTable @tenban ";
            DataProvaider.Instance.ExecuteNonQuery(query, new object[] { tenban });
        }

        public void UpdateTable(string maban, string tenban, string trangthai)
        {
            string query = "USP_UpdateTable @maban , @tenban , @trangthai ";
            DataProvaider.Instance.ExecuteNonQuery(query, new object[] { maban , tenban ,trangthai });
        }
    }
}
