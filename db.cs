using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace DB_Lab_1
{
     class db
    {
        public static SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=D:\\ddpu\\СБДЗ\\Лаб\\DB_Lab_1\\bin\\Book_Catalog.mdf;" +
            "Integrated Security=True;Connect Timeout=30");
        public static DataSet ds = new DataSet();
        public static SqlDataAdapter da = new SqlDataAdapter("",con);
        public static BindingSource bs = new BindingSource();
       
        
    }
}
