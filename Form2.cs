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
            
            if (Catalog.id == null)
            {

               

                db.da.InsertCommand = new SqlCommand("Insert into dbo.Catalog ([Id], [Title],[Author], [Genre],[Number of copies],[Publisher],[Publication date])" +
                    " Values(@id,@t,@a,@g,@nofc,@p,@pd);",db.con);
                db.da.InsertCommand.Parameters.Add("@id",SqlDbType.Int).Value = id.Text;
                db.da.InsertCommand.Parameters.Add("@t", SqlDbType.NChar).Value = title.Text;
                db.da.InsertCommand.Parameters.Add("@a", SqlDbType.NChar).Value = author.Text;
                db.da.InsertCommand.Parameters.Add("@g", SqlDbType.NChar).Value = genre.Text;
                db.da.InsertCommand.Parameters.Add("@nofc", SqlDbType.Int).Value = numOFcop.Text;
                db.da.InsertCommand.Parameters.Add("@p", SqlDbType.NChar).Value = publisher.Text;
                db.da.InsertCommand.Parameters.Add("@pd", SqlDbType.Int).Value = date.Text;

                db.con.Open();
                db.da.InsertCommand.ExecuteNonQuery();
                db.con.Close();
            }
            else
            {;
                db.da.UpdateCommand = new SqlCommand("UPDATE dbo.Catalog SET" +
                    " [Title] = @t ,[Author] = @a,[Genre] = @g,[Number of copies] = @nofc, [Publisher] = @p," +
                    "[Publication date] = @pd  WHERE  [Id] = @id;", db.con);
                db.da.UpdateCommand.Parameters.Add("@t", SqlDbType.NChar).Value = title.Text;
                db.da.UpdateCommand.Parameters.Add("@a", SqlDbType.NChar).Value = author.Text;
                db.da.UpdateCommand.Parameters.Add("@g", SqlDbType.NChar).Value = genre.Text;
                db.da.UpdateCommand.Parameters.Add("@nofc", SqlDbType.Int).Value = numOFcop.Text;
                db.da.UpdateCommand.Parameters.Add("@p", SqlDbType.NChar).Value = publisher.Text;
                db.da.UpdateCommand.Parameters.Add("@pd", SqlDbType.Int).Value = date.Text;
                db.da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int).Value = id.Text;

                db.con.Open();
                db.da.UpdateCommand.ExecuteNonQuery();
                db.con.Close();
            }
   
           

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
                db.ds.Clear();
                id.Text = Catalog.id;
                db.da.SelectCommand = new SqlCommand("SELECT * FROM dbo.Catalog WHERE [Id] =" + Catalog.id + ";", db.con);
                db.da.Fill(db.ds);
                db.bs.DataSource = db.ds.Tables[0];
                title.DataBindings.Add("Text", db.bs, "Title");
                author.DataBindings.Add("Text", db.bs, "Author");
                genre.DataBindings.Add("Text", db.bs, "Genre");
                numOFcop.DataBindings.Add("Text", db.bs, "Number of copies");
                publisher.DataBindings.Add("Text", db.bs, "Publisher");
                date.DataBindings.Add("Text", db.bs, "Publication date");

            }
        }
    }
}
