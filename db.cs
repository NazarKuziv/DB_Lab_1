using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace DB_Lab_1
{
     class db
    {
        static SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=D:\\ddpu\\СБДЗ\\Лаб\\DB_Lab_1\\bin\\Book_Catalog.mdf;" +
            "Integrated Security=True;Connect Timeout=30");
        public static SqlCommand cmd = new SqlCommand("", con);
        //public static DataSet ds;
        //public static SqlDataAdapter da;
        //public static BindingSource bs;
        //public static string sql;
        public static void openConnection()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    MessageBox.Show("The connection is " + con.State.ToString());

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Connection Failed:" + ex.Message);
            }
        }
        public static void closeConnection()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    MessageBox.Show("The connection is " + con.State.ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Close connection error:" + ex.Message);
            }
        }
        
    }
}
