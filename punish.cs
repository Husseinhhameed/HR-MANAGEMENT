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
    public partial class punish : Form
    {
        string conn = ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString;
        public string p, u;

        public punish()
        {
            InitializeComponent();
        }

        private void punish_Load(object sender, EventArgs e)
        {
            label7.Visible = false;
            label9.Text = Searchbox.empname;

            textBox2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            label1.Text = Searchbox.SetValueForpid;
            SqlConnection searchr = new SqlConnection(conn);
            SqlDataAdapter sqlda;
            searchr.Open();
            sqlda = new SqlDataAdapter("Select * from punish where pid='" + label1.Text + "'", conn);
            searchr.Close();
            SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns[1].HeaderText = "عدد امرالعقوبة";
            this.dataGridView1.Columns[2].HeaderText = "التاريخ";
            this.dataGridView1.Columns[3].HeaderText = "سبب العقوبة";
            this.dataGridView1.Columns[4].HeaderText = "الملخص";
            this.dataGridView1.Columns["id"].Visible = false;
            this.dataGridView1.Columns["pid"].Visible = false;
            this.dataGridView1.Columns["pdfa"].Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("قم بادخال عدد امر العقوبة من فضلك");
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
                SqlCommand cmd = new SqlCommand("insert into punish values (@punishno, @punishdate, @punishreson, @descr, @pid, @pdfa)", addcon);


                cmd.Parameters.AddWithValue("@punishno", textBox3.Text);
                cmd.Parameters.AddWithValue("@punishdate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@punishreson", textBox1.Text);
                cmd.Parameters.AddWithValue("@descr", textBox4.Text);
                cmd.Parameters.AddWithValue("@pid", label1.Text);
                cmd.Parameters.AddWithValue("@pdfa", p);

                cmd.ExecuteNonQuery();

                addcon.Close();
                MessageBox.Show("تم اضافة امر اداري جديد للموظف");
                SqlConnection searchr = new SqlConnection(conn);
                SqlDataAdapter sqlda;
                searchr.Open();
                sqlda = new SqlDataAdapter("Select * from punish where pid='" + label1.Text + "'", conn);
                searchr.Close();
                SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                dataGridView1.DataSource = dt;
                this.dataGridView1.Columns[1].HeaderText = "عدد امرالعقوبة";
                this.dataGridView1.Columns[2].HeaderText = "التاريخ";
                this.dataGridView1.Columns[3].HeaderText = "سبب العقوبة";
                this.dataGridView1.Columns[4].HeaderText = "الملخص";
                this.dataGridView1.Columns["id"].Visible = false;
                this.dataGridView1.Columns["pid"].Visible = false;
                this.dataGridView1.Columns["pdfa"].Visible = false;
                textBox4.Text = "";
                textBox3.Text = "";
                textBox1.Text = "";
                pdfFiles.Clear();
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

                    System.IO.File.Move(sourceFileName, destinationFileName);
                    u = destinationFileName;

                }
                SqlConnection addcon = new SqlConnection(conn);
                addcon.Open();
                SqlCommand cmd = new SqlCommand("UPDATE punish SET punishno=@punishno, punishdate=@punishdate, punishreson=@punishreson, descr=@descr, pdfa=@pdfa " + "WHERE Id = @Id", addcon);

                cmd.Parameters.AddWithValue("@punishno", textBox3.Text);
                cmd.Parameters.AddWithValue("@punishdate", textBox2.Text);
                cmd.Parameters.AddWithValue("@punishreson", textBox1.Text);
                cmd.Parameters.AddWithValue("@descr", textBox4.Text);
                cmd.Parameters.AddWithValue("@Id", label2.Text);
                cmd.Parameters.AddWithValue("@pdfa", u);



                cmd.ExecuteNonQuery();

                addcon.Close();
                MessageBox.Show("تم تعديل معلومات الامر الاداري");
                SqlConnection searchr = new SqlConnection(conn);
                SqlDataAdapter sqlda;
                searchr.Open();
                sqlda = new SqlDataAdapter("Select * from punish where pid='" + label1.Text + "'", conn);
                searchr.Close();
                SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                dataGridView1.DataSource = dt;
                this.dataGridView1.Columns[1].HeaderText = "عدد امرالعقوبة";
                this.dataGridView1.Columns[2].HeaderText = "التاريخ";
                this.dataGridView1.Columns[3].HeaderText = "سبب العقوبة";
                this.dataGridView1.Columns[4].HeaderText = "الملخص";
                this.dataGridView1.Columns["id"].Visible = false;
                this.dataGridView1.Columns["pid"].Visible = false;
                this.dataGridView1.Columns["pdfa"].Visible = false;
                textBox4.Text = "";
                textBox3.Text = "";
                textBox1.Text = "";
                pdfFiles.Clear();
                textBox2.Visible = false;
                button4.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                label7.Visible = false;

            }
            else if (pdfFiles.Count == 0)
            {
                SqlConnection addcon = new SqlConnection(conn);
                addcon.Open();
                SqlCommand cmd = new SqlCommand("UPDATE punish SET punishno=@punishno, punishdate=@punishdate, punishreson=@punishreson, descr=@descr, pdfa=@pdfa " + "WHERE Id = @Id", addcon);

                cmd.Parameters.AddWithValue("@punishno", textBox3.Text);
                cmd.Parameters.AddWithValue("@punishdate", textBox2.Text);
                cmd.Parameters.AddWithValue("@punishreson", textBox1.Text);
                cmd.Parameters.AddWithValue("@descr", textBox4.Text);
                cmd.Parameters.AddWithValue("@Id", label2.Text);
                cmd.Parameters.AddWithValue("@pdfa", p);



                cmd.ExecuteNonQuery();

                addcon.Close();
                MessageBox.Show("تم تعديل معلومات الامر الاداري");
                SqlConnection searchr = new SqlConnection(conn);
                SqlDataAdapter sqlda;
                searchr.Open();
                sqlda = new SqlDataAdapter("Select * from punish where pid='" + label1.Text + "'", conn);
                searchr.Close();
                SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                dataGridView1.DataSource = dt;
                this.dataGridView1.Columns[1].HeaderText = "عدد امرالعقوبة";
                this.dataGridView1.Columns[2].HeaderText = "التاريخ";
                this.dataGridView1.Columns[3].HeaderText = "سبب العقوبة";
                this.dataGridView1.Columns[4].HeaderText = "الملخص";
                this.dataGridView1.Columns["id"].Visible = false;
                this.dataGridView1.Columns["pid"].Visible = false;
                this.dataGridView1.Columns["pdfa"].Visible = false;
                textBox4.Text = "";
                textBox3.Text = "";
                textBox1.Text = "";
                pdfFiles.Clear();
                textBox2.Visible = false;
                button4.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                label7.Visible = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("حذف البيانات", "حذف البيانات", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection addcon = new SqlConnection(conn);
                addcon.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM training WHERE Id = @Id", addcon);

                cmd.Parameters.AddWithValue("@Id", label2.Text);


                cmd.ExecuteNonQuery();

                addcon.Close();
                MessageBox.Show("تم حذف معلومات الامر الاداري");
                SqlConnection searchr = new SqlConnection(conn);
                SqlDataAdapter sqlda;
                searchr.Open();
                sqlda = new SqlDataAdapter("Select * from punish where pid='" + label1.Text + "'", conn);
                searchr.Close();
                SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                dataGridView1.DataSource = dt;
                this.dataGridView1.Columns[1].HeaderText = "عدد امرالعقوبة";
                this.dataGridView1.Columns[2].HeaderText = "التاريخ";
                this.dataGridView1.Columns[3].HeaderText = "سبب العقوبة";
                this.dataGridView1.Columns[4].HeaderText = "الملخص";
                this.dataGridView1.Columns["id"].Visible = false;
                this.dataGridView1.Columns["pid"].Visible = false;
                this.dataGridView1.Columns["pdfa"].Visible = false;
                textBox4.Text = "";
                textBox3.Text = "";
                textBox1.Text = "";
                textBox2.Visible = false;
                button4.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                label7.Visible = false;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            label2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            p = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

            textBox2.Visible = true;
            button4.Visible = false;
            button1.Visible = true;
            button2.Visible = true;

            dateTimePicker1.Visible = false;
            if (p == "")
            {
                label7.Visible = false;

            }
            else
            {
                label7.Visible = true;

            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("descr like '%" + textBox5.Text + "%'");

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

                //string pth = @"D:\New folder";
                //textBox5.Text = openFileDialog.FileName;
                //File.Copy(textBox5.Text,pth);

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(p);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
            button4.Visible = true;
            textBox2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = true;
            label1.Text = Searchbox.SetValueForpid;
            SqlConnection searchr = new SqlConnection(conn);
            SqlDataAdapter sqlda;
            searchr.Open();
            sqlda = new SqlDataAdapter("Select * from punish where pid='" + label1.Text + "'", conn);
            searchr.Close();
            SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns[1].HeaderText = "عدد امرالعقوبة";
            this.dataGridView1.Columns[2].HeaderText = "التاريخ";
            this.dataGridView1.Columns[3].HeaderText = "سبب العقوبة";
            this.dataGridView1.Columns[4].HeaderText = "الملخص";
            this.dataGridView1.Columns["id"].Visible = false;
            this.dataGridView1.Columns["pid"].Visible = false;
            this.dataGridView1.Columns["pdfa"].Visible = false;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("punishno like '%" + textBox6.Text + "%'");

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
