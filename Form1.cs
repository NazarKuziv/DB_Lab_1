using System;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace DB_Lab_1
{
    public partial class Catalog : Form
    {
        static public Form2 form2 = null;
        public static string id = null;

        public Catalog()
        {
            InitializeComponent(); 
            

        }


        private void Catalog_Load(object sender, EventArgs e)
        {
                

        }
        private void Catalog_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Show_Click(object sender, EventArgs e)
        {  
                UpdateListView();

        }
        
        private void Add_Click(object sender, EventArgs e)
        {
            if (form2 == null)
                form2 = new Form2();
            form2.Show();
            form2.Activate();
            
        
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            
            id = dg.SelectedRows[0].Cells[0].Value.ToString();
            if (form2 == null)
                form2 = new Form2();
            form2.Show();
            form2.Activate();
            
        }

        private void Delete_Click(object sender, EventArgs e)
        {

            
            db.da.DeleteCommand =new SqlCommand("DELETE FROM dbo.Catalog WHERE [iD] = @id;", db.con);
            db.da.DeleteCommand.Parameters.Add("@id",System.Data.SqlDbType.Int).Value = dg.SelectedRows[0].Cells[0].Value.ToString();
            db.con.Open();
            db.da.DeleteCommand.ExecuteNonQuery();
            db.con.Close();
            UpdateListView();


        }
        public void UpdateListView()
        {

            db.ds.Clear();
            db.da.SelectCommand = new SqlCommand("SELECT * FROM dbo.Catalog;", db.con);
            db.da.Fill(db.ds);
            dg.DataSource = db.ds.Tables[0];

            
        }

        private void Search_Click(object sender, EventArgs e)
        {
            db.ds.Clear();
            string queryString = "SELECT * FROM dbo.Catalog WHERE [Title] = @t OR [Author] = @a;";
            db.da.SelectCommand = new SqlCommand(queryString, db.con);
            db.da.SelectCommand.Parameters.Add("@t",System.Data.SqlDbType.NChar).Value = searchBox.Text;
            db.da.SelectCommand.Parameters.Add("@a", System.Data.SqlDbType.NChar).Value = searchBox.Text;
            db.da.Fill(db.ds);
            dg.DataSource = db.ds.Tables[0];

        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
