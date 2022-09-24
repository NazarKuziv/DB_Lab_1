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
            db.openConnection();      

        }
        private void Catalog_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.closeConnection();
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
 
            id = listView.SelectedItems[0].Text;
            if (form2 == null)
                form2 = new Form2();
            form2.Show();
            form2.Activate();
            
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string queryString = "DELETE FROM dbo.Catalog WHERE [iD] = " + listView.SelectedItems[0].Text+";";
            db.cmd.CommandText = queryString;
            db.cmd.ExecuteNonQuery();
            UpdateListView();


        }
        public void UpdateListView()
        {
            listView.Items.Clear();
            string queryString = "SELECT * FROM dbo.Catalog;";
            db.cmd.CommandText = queryString;
            SqlDataReader reader = db.cmd.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem items = new ListViewItem(reader.GetValue(0).ToString());

                for (int i = 1; i < 7; i++)
                    items.SubItems.Add(reader.GetValue(i).ToString());

                listView.Items.Add(items);

            }
            reader.Close();
        }
        
        private void Search_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();
            string queryString = "SELECT * FROM dbo.Catalog WHERE ";
            switch (Search_by.Text)
            {
                case "Назвою":
                    {
                        queryString += "[Title] = '"+ searchBox.Text + "';";
                        SearchBook(queryString);
                        break;
                    }
                case "Автором":
                    {
                        queryString += "[Author] = '" + searchBox.Text + "';";
                        SearchBook(queryString);
                        break;
                    }
                case "Датою публікації":
                    {
                        queryString += "[Publication date] = " + searchBox.Text + ";";
                        SearchBook(queryString);
                        break;
                    }
                case "Видавцем":
                    {
                        queryString += "[Publisher] = '" + searchBox.Text + "';";
                        SearchBook(queryString);
                        break;
                    }
                case "Жанром":
                    {
                        queryString += "[Genre] = '" + searchBox.Text + "';";
                        SearchBook(queryString);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Введіть тараметр пошуку");
                        break;
                       
                    }

            }

           
        }
    
        public void SearchBook(string queryString)
        {
            db.cmd.CommandText = queryString;
            SqlDataReader reader = db.cmd.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem items = new ListViewItem(reader.GetValue(0).ToString());

                for (int i = 1; i < 7; i++)
                    items.SubItems.Add(reader.GetValue(i).ToString());

                listView.Items.Add(items);

            }
            reader.Close();
        }
    }
}
