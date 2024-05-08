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
    public partial class statistics : Form
    {
        string conn = ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString;

        public statistics()
        {
            InitializeComponent();
        }

        private void statistics_Load(object sender, EventArgs e)
        {
            SqlConnection searchr = new SqlConnection(conn);
            SqlDataAdapter sqlda, sqlemp, sqlorder, sqlthanks, sqltrain, sqlvac, sqlpun;
            searchr.Open();
            sqlda = new SqlDataAdapter("Select * from Departments ", conn);
            sqlemp = new SqlDataAdapter("Select * from employees ", conn);
            sqlorder = new SqlDataAdapter("Select * from orders ", conn);
            sqlthanks = new SqlDataAdapter("Select * from thanks ", conn);
            sqltrain = new SqlDataAdapter("Select * from training ", conn);
            sqlvac = new SqlDataAdapter("Select * from vacations ", conn);
            sqlpun = new SqlDataAdapter("Select * from punish ", conn);

            searchr.Close();
            SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
            DataTable dep = new DataTable();
            sqlda.Fill(dep);
            int a = dep.Rows.Count;
            label1.Text = a.ToString();
            SqlCommandBuilder ca = new SqlCommandBuilder(sqlemp);
            DataTable emp = new DataTable();
            sqlemp.Fill(emp);
            int b = emp.Rows.Count;
            label2.Text = b.ToString();
            SqlCommandBuilder cc = new SqlCommandBuilder(sqlorder);
            DataTable ord = new DataTable();
            sqlorder.Fill(ord);
            int c = ord.Rows.Count;
            label3.Text = c.ToString();
            SqlCommandBuilder dd = new SqlCommandBuilder(sqlthanks);
            DataTable thn = new DataTable();
            sqlorder.Fill(thn);
            int d = thn.Rows.Count;
            label4.Text = d.ToString();
            SqlCommandBuilder ee = new SqlCommandBuilder(sqltrain);
            DataTable trn = new DataTable();
            sqltrain.Fill(trn);
            int t = trn.Rows.Count;
            label5.Text = t.ToString();
            SqlCommandBuilder vv = new SqlCommandBuilder(sqlvac);
            DataTable vac = new DataTable();
            sqlvac.Fill(vac);
            int v = vac.Rows.Count;
            label6.Text = v.ToString();
            SqlCommandBuilder pp = new SqlCommandBuilder(sqlpun);
            DataTable pun = new DataTable();
            sqlpun.Fill(pun);
            int p = pun.Rows.Count;
            label14.Text = p.ToString();
            chart1.Series["عدد الاقسام"].Points.AddXY("عدد الاقسام",a);
            chart1.Series["عدد الموظفين"].Points.AddXY("عدد الموظفين", b);
            chart1.Series["الاوامر الادارية"].Points.AddXY("الاوامر الادارية", c);
            chart1.Series["شكر وتقدير"].Points.AddXY("شكر وتقدير", d);
            chart1.Series["اجازات"].Points.AddXY("اجازات", v);
            chart1.Series["دورات"].Points.AddXY("دورات", t);
            chart1.Series["عقوبات"].Points.AddXY("عقوبات", p);



        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
