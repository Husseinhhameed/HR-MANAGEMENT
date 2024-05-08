using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROTOCOLMANAGEMENT
{
    public partial class Searchbox : Form
    {
        string conn = ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString;
        public static string SetValueForpid = "";
        public static string empname = "";
        class Global
        {
            public static string UserID;

        }
        public Searchbox()
        {
            InitializeComponent();
        }

      
        

        private void Searchbox_Load(object sender, EventArgs e)
        {

            panel1.Visible = false;
            textBox1.AutoSize = false;

            string conn = ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            string squery = "select name from employees";
            SqlCommand cd = new SqlCommand(squery, sqlcon);
            sqlcon.Open();
            SqlDataReader sdr = cd.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
            while (sdr.Read())
            {
                autotext.Add(sdr.GetString(0));
            }
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteCustomSource = autotext;
            sqlcon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("ادخل اسما من اجل البحث عنه لطفا");
            }
            else
            {
                SqlConnection searchr = new SqlConnection(conn);
                SqlDataAdapter sqlda;
                searchr.Open();
                sqlda = new SqlDataAdapter("Select * from employees where name=N'" + textBox1.Text + "'", conn);
                searchr.Close();
                SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("لم يتم العثور على موظف بهذا الاسم");
                }
                else
                {
                    Global.UserID = dt.Rows[0]["id"].ToString();
                    label1.Text = dt.Rows[0]["name"].ToString();
                    label3.Text = dt.Rows[0]["title"].ToString();
                    label4.Text = dt.Rows[0]["position"].ToString();
                    label5.Text = dt.Rows[0]["depart"].ToString();
                    label6.Text = dt.Rows[0]["pid"].ToString();
                    byte[] ba = (byte[])dt.Rows[0]["pic"];
                    SetValueForpid = dt.Rows[0]["pid"].ToString();
                    empname= dt.Rows[0]["name"].ToString();
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(ba);
                    Image img = Image.FromStream(ms);
                    pictureBox1.Image = img;
                    panel1.Visible = true;
                   
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            
        }
    }
}
