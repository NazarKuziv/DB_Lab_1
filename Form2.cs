using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace DB_Lab_1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Catalog.id = null;
            Catalog.form2 = null;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            string queryString;
            if (Catalog.id == null)
            {
                queryString = "Insert into dbo.Catalog ([Id], [Title], " +
                "[Author], [Genre],[Number of copies],[Publisher],[Publication date])" +
                " Values(" + id.Text + "," +
                "'" + title.Text + "'," +
                "'" + author.Text + "'," +
                "'" + genre.Text + "'," +
                numOFcop.Text + "," +
                "'" + publisher.Text + "'," +
                date.Text + ");";
            }
            else
            {
                queryString = "UPDATE dbo.Catalog SET" +
                    " [Title] ='" +title.Text + "',"+
                    "[Author] = '" + author.Text + "'," +
                    "[Genre] = '" + genre.Text + "'," +
                    "[Number of copies] = " + numOFcop.Text + "," +
                    "[Publisher] = '" + publisher.Text + "'," +
                    "[Publication date] = " + date.Text +
                    "WHERE  [Id] = "+id.Text+";";
            }
   
            db.cmd.CommandText = queryString;
            db.cmd.ExecuteNonQuery();

            Catalog.id = null;
            this.Close();
            

        }

        private void off_Click(object sender, EventArgs e)
        {
            Catalog.id = null;
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (Catalog.id != null)
            {
                id.Text = Catalog.id;
                string queryString = "SELECT * FROM dbo.Catalog WHERE [Id] ="+Catalog.id+";";
                db.cmd.CommandText = queryString;
                SqlDataReader reader = db.cmd.ExecuteReader();
                reader.Read();
                title.Text = reader.GetValue(1).ToString();
                author.Text = reader.GetValue(2).ToString();
                genre.Text = reader.GetValue(3).ToString();
                numOFcop.Text = reader.GetValue(4).ToString();
                publisher.Text = reader.GetValue(5).ToString();
                date.Text = reader.GetValue(6).ToString();
                reader.Close();

            }
        }
    }
}
