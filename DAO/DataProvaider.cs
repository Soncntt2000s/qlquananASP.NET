using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DoAn
{
    public class DataProvaider
    {

        private static DataProvaider instance;

        public static DataProvaider Instance
        {
            get {if(instance == null) instance = new DataProvaider();return DataProvaider.instance; }
            private set { DataProvaider.instance = value; }
        }

        private DataProvaider() { }
        private string connectionStr = @"Data Source=.\sqlexpress;Initial Catalog=QLQuanAn;Integrated Security=True";
        SqlConnection cn = new SqlConnection();


        /*=============================================================*/


        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connetion = new SqlConnection(connectionStr))
            {
                connetion.Open();
                SqlCommand command = new SqlCommand(query, connetion);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connetion.Close();
            }
            return data;
        }

        /*=============================================================*/


        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connetion = new SqlConnection(connectionStr))
            {
                connetion.Open();
                SqlCommand command = new SqlCommand(query, connetion);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connetion.Close();
            }
            return data;
        }

        /*=============================================================*/



        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connetion = new SqlConnection(connectionStr))
            {
                connetion.Open();
                SqlCommand command = new SqlCommand(query, connetion);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                connetion.Close();
            }
            return data;
        }

        
    }
}
