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
    public partial class usermanag : Form
    {
        string conn = ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString;

        public usermanag()
        {
            InitializeComponent();
        }

        private void usermanag_Load(object sender, EventArgs e)
        {
            button3.Visible = false;
            button1.Visible = false;
            SqlConnection searchr = new SqlConnection(conn);
            SqlDataAdapter sqlda;
            searchr.Open();
            sqlda = new SqlDataAdapter("Select * from users", conn);
            searchr.Close();
            SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns[0].HeaderText = "اسم المستخدم";
            this.dataGridView1.Columns[1].HeaderText = "كلمة السر";

            this.dataGridView1.Columns["Id"].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("قم بادخال عدد كتاب الشكروالتقدير من فضلك");
            }

            else if (textBox3.Text == "")
            {
                MessageBox.Show("قم بادخال عدد كتاب الشكروالتقدير من فضلك");
            }
            else
            {
                SqlConnection addcon = new SqlConnection(conn);
                addcon.Open();
                SqlCommand cmd = new SqlCommand("insert into users values (@username, @password)", addcon);


                cmd.Parameters.AddWithValue("@username", textBox2.Text);
                cmd.Parameters.AddWithValue("@password", textBox3.Text);

                cmd.ExecuteNonQuery();

                addcon.Close();
                MessageBox.Show("تم اضافة مستخدم جديد لنظام الادارة");
                SqlConnection searchr = new SqlConnection(conn);
                SqlDataAdapter sqlda;
                searchr.Open();
                sqlda = new SqlDataAdapter("Select * from users ", conn);
                searchr.Close();
                SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                dataGridView1.DataSource = dt;
                this.dataGridView1.Columns[0].HeaderText = "اسم المستخدم";
                this.dataGridView1.Columns[1].HeaderText = "كلمة السر";
                this.dataGridView1.Columns["Id"].Visible = false;
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            label2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            button3.Visible = true;
            button1.Visible = true;
            button2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection addcon = new SqlConnection(conn);
            addcon.Open();
            SqlCommand cmd = new SqlCommand("UPDATE users SET username = @username, password = @password " + "WHERE Id = @Id", addcon);


            cmd.Parameters.AddWithValue("@username", textBox2.Text);
            cmd.Parameters.AddWithValue("@password", textBox3.Text);
            cmd.Parameters.AddWithValue("@Id", label2.Text);

            cmd.ExecuteNonQuery();

            addcon.Close();
            MessageBox.Show("تم تحديث معلومات المستخدم");
            SqlConnection searchr = new SqlConnection(conn);
            SqlDataAdapter sqlda;
            searchr.Open();
            sqlda = new SqlDataAdapter("Select * from users ", conn);
            searchr.Close();
            SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns[0].HeaderText = "اسم المستخدم";
            this.dataGridView1.Columns[1].HeaderText = "كلمة السر";

            this.dataGridView1.Columns["Id"].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تؤكد حذف المستخدم من النظام؟", "حذف المستخدم", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection addcon = new SqlConnection(conn);
                addcon.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE Id = @Id", addcon);

                cmd.Parameters.AddWithValue("@Id", label2.Text);


                cmd.ExecuteNonQuery();

                addcon.Close();
                MessageBox.Show("تم حذف المستخدم");
                SqlConnection searchr = new SqlConnection(conn);
                SqlDataAdapter sqlda;
                searchr.Open();
                sqlda = new SqlDataAdapter("Select * from users ", conn);
                searchr.Close();
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                dataGridView1.DataSource = dt;
                this.dataGridView1.Columns[0].HeaderText = "اسم المستخدم";
                this.dataGridView1.Columns[1].HeaderText = "كلمة السر";

                this.dataGridView1.Columns["Id"].Visible = false;
            }
        }
    }
}
