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
    public partial class editemployee : Form
    {
        string conn = ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString;

        public editemployee()
        {
            InitializeComponent();
        }

        private void editemployee_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
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

            comboBox1.Text = "";
            SqlConnection drcon = new SqlConnection(conn);

            try
            {
                drcon.Open();
                SqlCommand sc = new SqlCommand("select (Depname) from Departments", drcon);
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Depname", typeof(string));
                dt.Load(reader);
                comboBox1.ValueMember = "Depname";
                comboBox1.DataSource = dt;
                drcon.Close();
                ;
            }

            catch (Exception)
            {

            }
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
                    label1.Text = dt.Rows[0]["id"].ToString();
                    textBox4.Text = dt.Rows[0]["name"].ToString();
                    textBox3.Text = dt.Rows[0]["title"].ToString();
                    textBox2.Text = dt.Rows[0]["position"].ToString();
                    comboBox1.Text = dt.Rows[0]["depart"].ToString();
                    panel1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection addcon = new SqlConnection(conn);
            addcon.Open();
            SqlCommand cmd = new SqlCommand("UPDATE employees SET name=@name, title=@title, position=@position, depart=@depart " + "WHERE Id = @Id", addcon);

            cmd.Parameters.AddWithValue("@name", textBox4.Text);
            cmd.Parameters.AddWithValue("@title", textBox3.Text);
            cmd.Parameters.AddWithValue("@position", textBox2.Text);
            cmd.Parameters.AddWithValue("@depart", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Id", label1.Text);



            cmd.ExecuteNonQuery();

            addcon.Close();
            MessageBox.Show("تم تعديل معلومات الموظف");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("حذف البيانات", "حذف البيانات", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection addcon = new SqlConnection(conn);
                addcon.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM employees WHERE Id = @Id", addcon);

                cmd.Parameters.AddWithValue("@Id", label1.Text);


                cmd.ExecuteNonQuery();

                addcon.Close();
                MessageBox.Show("تم حذف الموظف");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }
    }
}