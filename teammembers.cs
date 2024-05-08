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
    public partial class teammembers : Form
    {
        string conn = ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString;

        public teammembers()
        {
            InitializeComponent();
        }

        private void teammembers_Load(object sender, EventArgs e)
        {
            SqlConnection searchr = new SqlConnection(conn);
            SqlDataAdapter sqlda;
            searchr.Open();
            sqlda = new SqlDataAdapter("Select name,title,position,depart from employees ", conn);
            searchr.Close();
            SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Sort(this.dataGridView1.Columns["depart"], ListSortDirection.Ascending);
            this.dataGridView1.Columns[0].HeaderText = "الاسم";
            this.dataGridView1.Columns[1].HeaderText = "العنوان الوظيفي";
            this.dataGridView1.Columns[2].HeaderText = "المنصب";
            this.dataGridView1.Columns[3].HeaderText = "القسم";

            comboBox1.Text = "";
            SqlConnection drcon = new SqlConnection(conn);

            try
            {
                drcon.Open();
                SqlCommand sc = new SqlCommand("select (Depname) from Departments", drcon);
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dc = new DataTable();
                dc.Columns.Add("Depname", typeof(string));
                dc.Load(reader);
                comboBox1.ValueMember = "Depname";
                comboBox1.DataSource = dc;
                drcon.Close();
                ;
            }

            catch (Exception)
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

    

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection searchr = new SqlConnection(conn);
            SqlDataAdapter sqlda;
            searchr.Open();
            sqlda = new SqlDataAdapter("Select name,title,position,depart from employees where depart=N'" + comboBox1.Text + "'", conn);
            searchr.Close();
            SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
            DataTable dm = new DataTable();
            sqlda.Fill(dm);
            dataGridView1.DataSource = dm;
            this.dataGridView1.Columns[1].HeaderText = "الاسم";
            this.dataGridView1.Columns[2].HeaderText = "العنوان الوظيفي";
            this.dataGridView1.Columns[3].HeaderText = "المنصب";
            //this.dataGridView1.Columns[4].HeaderText = "القسم";
        }
    }
}
