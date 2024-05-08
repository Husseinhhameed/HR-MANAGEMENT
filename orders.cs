using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PROTOCOLMANAGEMENT
{
    public partial class orders : Form
    {
        string conn = ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString;
        public string p,u;
        public orders()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();


        private void orders_Load(object sender, EventArgs e)
        {
            label6.Visible = false;
            textBox3.Visible = false;
            button2.Visible = false;
            button1.Visible = false;
            label1.Text = Searchbox.SetValueForpid;

            label7.Text = Searchbox.empname;
            SqlConnection searchr = new SqlConnection(conn);
            SqlDataAdapter sqlda;
            searchr.Open();
            sqlda = new SqlDataAdapter("Select * from orders where pid='" + label1.Text + "'", conn);
            searchr.Close();
            SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns[1].HeaderText = "العدد";
            this.dataGridView1.Columns[2].HeaderText = "التاريخ";
            this.dataGridView1.Columns[3].HeaderText = "الملخص";
            this.dataGridView1.Columns["id"].Visible = false;
            this.dataGridView1.Columns["pid"].Visible = false;
            this.dataGridView1.Columns["pdfa"].Visible = false;


        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "")
            {
                MessageBox.Show("ادخل  عدد الأمر الاداري من فضلك", "عدد الأمر الاداري", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         else if (pdfFiles.Count() == 0)
            {
                MessageBox.Show("اضف صورة عن الامر الاداري من فضلك", "صورة الأمر الاداري", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                string installedPath = @"D:\New folder";

                //Check whether folder path is exist
                if (!System.IO.Directory.Exists(installedPath))
                {
                    // If not create new folder
                    System.IO.Directory.CreateDirectory(installedPath);
                }

                //Save pdf files in installedPath
                foreach (string sourceFileName in pdfFiles)
                {
                    string destinationFileName = System.IO.Path.Combine(installedPath, Path.GetFileName(sourceFileName));
                 
                        System.IO.File.Copy(sourceFileName, destinationFileName);
                        p = destinationFileName;
                    
                }
                SqlConnection addcon = new SqlConnection(conn);
                addcon.Open();
                SqlCommand cmd = new SqlCommand("insert into orders values (@orderno, @orderdate, @descr, @pid, @pdfa)", addcon);


                cmd.Parameters.AddWithValue("@orderno", textBox2.Text);
                cmd.Parameters.AddWithValue("@orderdate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@descr", textBox1.Text);
                cmd.Parameters.AddWithValue("@pid", label1.Text);
                cmd.Parameters.AddWithValue("@pdfa", p);



                cmd.ExecuteNonQuery();

                addcon.Close();
             
                MessageBox.Show("تم اضافة امر اداري جديد للموظف");
                SqlConnection searchr = new SqlConnection(conn);
                SqlDataAdapter sqlda;
                searchr.Open();
                sqlda = new SqlDataAdapter("Select * from orders where pid='" + label1.Text + "'", conn);
                searchr.Close();
                SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                dataGridView1.DataSource = dt;
                this.dataGridView1.Columns[1].HeaderText = "العدد";
                this.dataGridView1.Columns[2].HeaderText = "التاريخ";
                this.dataGridView1.Columns[3].HeaderText = "الملخص";
                this.dataGridView1.Columns["id"].Visible = false;
                this.dataGridView1.Columns["pid"].Visible = false;
                this.dataGridView1.Columns["pdfa"].Visible = false;
                pdfFiles.Clear();
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pdfFiles.Count == 1)
            {
                string installedPath = @"D:\New folder";
                //Check whether folder path is exist
                if (!System.IO.Directory.Exists(installedPath))
                {
                    // If not create new folder
                    System.IO.Directory.CreateDirectory(installedPath);
                }
                //Save pdf files in installedPath
                foreach (string sourceFileName in pdfFiles)
                {
                    string destinationFileName = System.IO.Path.Combine(installedPath, Path.GetFileName(sourceFileName));

                    System.IO.File.Copy(sourceFileName, destinationFileName);
                    u = destinationFileName;

                }


                SqlConnection addcon = new SqlConnection(conn);
                addcon.Open();
                SqlCommand cmd = new SqlCommand("UPDATE orders SET orderno = @orderno, orderdate = @orderdate, descr=@descr,pdfa=@pdfa " + "WHERE Id = @Id", addcon);


                cmd.Parameters.AddWithValue("@orderno", textBox2.Text);
                cmd.Parameters.AddWithValue("@orderdate", textBox3.Text);
                cmd.Parameters.AddWithValue("@descr", textBox1.Text);
                cmd.Parameters.AddWithValue("@Id", label2.Text);
                cmd.Parameters.AddWithValue("@pdfa", u);



                cmd.ExecuteNonQuery();

                addcon.Close();
                MessageBox.Show("تم تعديل معلومات الامر الاداري");
                SqlConnection searchr = new SqlConnection(conn);
                SqlDataAdapter sqlda;
                searchr.Open();
                sqlda = new SqlDataAdapter("Select * from orders where pid='" + label1.Text + "'", conn);
                searchr.Close();
                SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                dataGridView1.DataSource = dt;
                this.dataGridView1.Columns[1].HeaderText = "العدد";
                this.dataGridView1.Columns[2].HeaderText = "التاريخ";
                this.dataGridView1.Columns[3].HeaderText = "الملخص";
                this.dataGridView1.Columns["id"].Visible = false;
                this.dataGridView1.Columns["pid"].Visible = false;
                this.dataGridView1.Columns["pdfa"].Visible = false;
                pdfFiles.Clear();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Visible = false;
                button2.Visible = false;
                button1.Visible = false;
                button4.Visible = true;
                dateTimePicker1.Visible = true;
                label6.Visible = false;
            }
            else if (pdfFiles.Count == 0)
            {
                SqlConnection addcon = new SqlConnection(conn);
                addcon.Open();
                SqlCommand cmd = new SqlCommand("UPDATE orders SET orderno = @orderno, orderdate = @orderdate, descr=@descr,pdfa=@pdfa " + "WHERE Id = @Id", addcon);


                cmd.Parameters.AddWithValue("@orderno", textBox2.Text);
                cmd.Parameters.AddWithValue("@orderdate", textBox3.Text);
                cmd.Parameters.AddWithValue("@descr", textBox1.Text);
                cmd.Parameters.AddWithValue("@Id", label2.Text);
                cmd.Parameters.AddWithValue("@pdfa", p);



                cmd.ExecuteNonQuery();

                addcon.Close();
                MessageBox.Show("تم تعديل معلومات الامر الاداري");
                SqlConnection searchr = new SqlConnection(conn);
                SqlDataAdapter sqlda;
                searchr.Open();
                sqlda = new SqlDataAdapter("Select * from orders where pid='" + label1.Text + "'", conn);
                searchr.Close();
                SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                dataGridView1.DataSource = dt;
                this.dataGridView1.Columns[1].HeaderText = "العدد";
                this.dataGridView1.Columns[2].HeaderText = "التاريخ";
                this.dataGridView1.Columns[3].HeaderText = "الملخص";
                this.dataGridView1.Columns["id"].Visible = false;
                this.dataGridView1.Columns["pid"].Visible = false;
                this.dataGridView1.Columns["pdfa"].Visible = false;
                pdfFiles.Clear();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Visible = false;
                button2.Visible = false;
                button1.Visible = false;
                button4.Visible = true;
                dateTimePicker1.Visible = true;
                label6.Visible = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل ت}كد حذف هذا القيد؟ مع العلم لايمكن استرجاعه لاحقا", "حذف البيانات", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SqlConnection addcon = new SqlConnection(conn);
                addcon.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM orders WHERE Id = @Id", addcon);

                cmd.Parameters.AddWithValue("@Id", label2.Text);


                cmd.ExecuteNonQuery();

                addcon.Close();
                MessageBox.Show("تم حذف معلومات الامر الاداري");
                SqlConnection searchr = new SqlConnection(conn);
                SqlDataAdapter sqlda;
                searchr.Open();
                sqlda = new SqlDataAdapter("Select * from orders where pid='" + label1.Text + "'", conn);
                searchr.Close();
                SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                dataGridView1.DataSource = dt;
                this.dataGridView1.Columns[1].HeaderText = "العدد";
                this.dataGridView1.Columns[2].HeaderText = "التاريخ";
                this.dataGridView1.Columns[3].HeaderText = "الملخص";
                this.dataGridView1.Columns["id"].Visible = false;
                this.dataGridView1.Columns["pid"].Visible = false;
                this.dataGridView1.Columns["pid"].Visible = false;
                this.dataGridView1.Columns["pdfa"].Visible = false;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Visible = false;
                button2.Visible = false;
                button1.Visible = false;
                button4.Visible = true;
                dateTimePicker1.Visible = true;
                pdfFiles.Clear();
                label6.Visible = false;

            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            p= dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            label2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            textBox3.Visible = true;
            button2.Visible = true;
            button1.Visible = true;
            button4.Visible = false;
            dateTimePicker1.Visible = false;
            if (p == "")
            {
                label6.Visible = false;

            }
            else
            {
                label6.Visible = true;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("descr like '%" + textBox4.Text + "%'");
    
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        List<string> pdfFiles = new List<string>();

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pdfFiles = new List<string>();
                foreach (string fileName in openFileDialog.FileNames)
                    pdfFiles.Add(fileName);

               
                
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            label6.Visible = false;
            textBox3.Visible = false;
            button2.Visible = false;
            button1.Visible = false;
            label1.Text = Searchbox.SetValueForpid;
            SqlConnection searchr = new SqlConnection(conn);
            SqlDataAdapter sqlda;
            searchr.Open();
            sqlda = new SqlDataAdapter("Select * from orders where pid='" + label1.Text + "'", conn);
            searchr.Close();
            SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns[1].HeaderText = "العدد";
            this.dataGridView1.Columns[2].HeaderText = "التاريخ";
            this.dataGridView1.Columns[3].HeaderText = "الملخص";
            this.dataGridView1.Columns["id"].Visible = false;
            this.dataGridView1.Columns["pid"].Visible = false;
            this.dataGridView1.Columns["pdfa"].Visible = false;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("orderno like '%" + textBox5.Text + "%'");

        }

        private void label6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(p);
        }
    }
}
