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
using System.IO;
using System.Configuration;

namespace PROTOCOLMANAGEMENT
{
    public partial class Addmember : Form
    {
        string conn = ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString;
        string imgLocation = "";
        public Addmember()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txname.Text == "")
            {
                MessageBox.Show("ادخل  الاسم من فضلك","اسم الموظف",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtitle.Text == "")
            {
                MessageBox.Show("ماهو العنوان الوظيفي للموظف؟", "العنوان الوظيفي", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txpositon.Text == "")
            {
                MessageBox.Show("زودنا بمنصب هذا الموظف", "المنصب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txpid.Text == "")
            {
                MessageBox.Show("ماهو الرقم الوظيفي الموحد؟", "الرقم الوظيفي", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("اختر حقل القسم  من فضلك");
            }
            else {
                DialogResult dialogResult = MessageBox.Show("هل اضفت صورة شخصية لهذا الموظف؟ انه ليس اجباريا ولكن اضافة صورة شخصية مستحسنة وتجعل النظام اكثر تكاملا", "الصورة الشخصية", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {


                    SqlConnection addcon = new SqlConnection(conn);
                    addcon.Open();
                    SqlCommand cmd = new SqlCommand("insert into employees values (@name, @title, @position, @depart, @pic, @pid)", addcon);
                    MemoryStream stream = new MemoryStream();
                    pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] pic = stream.ToArray();

                    cmd.Parameters.AddWithValue("@name", txname.Text);
                    cmd.Parameters.AddWithValue("@title", txtitle.Text);
                    cmd.Parameters.AddWithValue("@position", txpositon.Text);
                    cmd.Parameters.AddWithValue("@pid", txpid.Text);
                    cmd.Parameters.AddWithValue("@depart", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@pic", pic);


                    cmd.ExecuteNonQuery();
                    addcon.Close();
                    MessageBox.Show("تم اضافة الموظف الجديد لفريق العمل");
                    txname.Text = "";
                    txtitle.Text = "";
                    txpositon.Text = "";
                    txpid.Text = "";

                    comboBox1.Text = "";
                }
            }
        }

        private void Addmember_Load(object sender, EventArgs e)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }
        }

        private void txpid_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
