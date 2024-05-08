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
    public partial class empstatist : Form
    {
        string conn = ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString;

        public empstatist()
        {
            InitializeComponent();
        }

        private void empstatist_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.textBox1.AutoSize = false;
            this.textBox1.Size = new System.Drawing.Size(230, 25);

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
                    label1.Text = dt.Rows[0]["pid"].ToString();
                    SqlConnection staticst = new SqlConnection(conn);
                    SqlDataAdapter orders;
                    staticst.Open();
                    orders = new SqlDataAdapter("Select * from orders where pid='" + label1.Text + "'", conn);
                    staticst.Close();
                    DataTable ord = new DataTable();
                    orders.Fill(ord);
                    int a = ord.Rows.Count;
                    label3.Text = a.ToString();

                    SqlConnection sqlthank = new SqlConnection(conn);
                    SqlDataAdapter thank;
                    sqlthank.Open();
                    thank = new SqlDataAdapter("Select * from thanks where pid='" + label1.Text + "'", conn);
                    staticst.Close();
                    DataTable thn = new DataTable();
                    thank.Fill(thn);
                    int b = thn.Rows.Count;
                    label4.Text = b.ToString();

                    SqlConnection sqlvac = new SqlConnection(conn);
                    SqlDataAdapter vacation;
                    sqlvac.Open();
                    vacation = new SqlDataAdapter("Select * from vacations where pid='" + label1.Text + "'", conn);
                    sqlvac.Close();
                    DataTable vac = new DataTable();
                    vacation.Fill(vac);
                    int c = vac.Rows.Count;
                    label6.Text = c.ToString();

                    SqlConnection sqltr = new SqlConnection(conn);
                    SqlDataAdapter train;
                    sqltr.Open();
                    train = new SqlDataAdapter("Select * from training where pid='" + label1.Text + "'", conn);
                    sqltr.Close();
                    DataTable tr = new DataTable();
                    train.Fill(tr);
                    int d = tr.Rows.Count;
                    label5.Text = d.ToString();

                    SqlConnection sqpun = new SqlConnection(conn);
                    SqlDataAdapter punish;
                    sqpun.Open();
                    punish = new SqlDataAdapter("Select * from punish where pid='" + label1.Text + "'", conn);
                    sqpun.Close();
                    DataTable pu = new DataTable();
                    punish.Fill(pu);
                    int ep = pu.Rows.Count;
                    label14.Text = ep.ToString();


                    SqlConnection sqldisp = new SqlConnection(conn);
                    SqlDataAdapter disp;
                    sqldisp.Open();
                    disp = new SqlDataAdapter("Select * from dip where pid='" + label1.Text + "'", conn);
                    sqldisp.Close();
                    DataTable distp = new DataTable();
                    disp.Fill(distp);
                    int g = distp.Rows.Count;
                    label7.Text = g.ToString();

                    chart1.Series["الاوامر الادارية"].Points.AddXY("الاوامر الادارية", a);
                    chart1.Series["شكر وتقدير"].Points.AddXY("شكر وتقدير", b);
                    chart1.Series["الاجازات"].Points.AddXY("الاجازات", c);
                    chart1.Series["الدورات التدريبية"].Points.AddXY("الدورات التدريبية", d);
                    chart1.Series["العقوبات"].Points.AddXY("العقوبات", ep);
                    chart1.Series["الايفادات"].Points.AddXY("الايفادات", g);


                    panel1.Visible = true;
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
