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
    public partial class dep : Form
    {
        string conn = ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString;

        public dep()
        {
            InitializeComponent();
        }

        private void dep_Load(object sender, EventArgs e)
        {
            SqlConnection searchr = new SqlConnection(conn);
            SqlDataAdapter sqlda;
            searchr.Open();
            sqlda = new SqlDataAdapter("Select Depname from Departments", conn);
            searchr.Close();
            SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns[0].HeaderText = "الأقسام";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("قم بادخال اسم القسم من فضلك");
            }

            else
            {
                SqlConnection addcon = new SqlConnection(conn);
                addcon.Open();
                SqlCommand cmd = new SqlCommand("insert into Departments values (@Depname)", addcon);


                cmd.Parameters.AddWithValue("@Depname", textBox1.Text);
               

                cmd.ExecuteNonQuery();

                addcon.Close();
                MessageBox.Show("تم اضافة قسم جديد");
                SqlConnection searchr = new SqlConnection(conn);
                SqlDataAdapter sqlda;
                searchr.Open();
                sqlda = new SqlDataAdapter("Select Depname from Departments ", conn);
                searchr.Close();
                SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
