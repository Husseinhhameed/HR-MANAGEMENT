using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROTOCOLMANAGEMENT
{
    public partial class CV : Form
    {
        string conn = ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString;
        string imgLocation = "";
        public CV()
        {
            InitializeComponent();
        }

        private void CV_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label1.Text = Searchbox.SetValueForpid;
            SqlConnection searchr = new SqlConnection(conn);
            SqlDataAdapter sqlda;
            searchr.Open();
            sqlda = new SqlDataAdapter("Select * from cv where pid='" + label1.Text + "'", conn);
            searchr.Close();
            SqlCommandBuilder cb = new SqlCommandBuilder(sqlda);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            if (dt.Rows.Count == 0)
            {

                button3.Visible = true;
                button4.Visible = false;
            }
            if (dt.Rows.Count > 0)
            {
                button3.Visible = false;
                button4.Visible = true;
                byte[] ba = (byte[])dt.Rows[0]["cvphoto"];
                System.IO.MemoryStream ms = new System.IO.MemoryStream(ba);
                Image img = Image.FromStream(ms);
                pictureBox1.Image = img;
            }

            if (pictureBox1.Image == null)
            {
                button2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            
                SqlConnection addcon = new SqlConnection(conn);
                addcon.Open();
                SqlCommand cmd = new SqlCommand("insert into cv values ( @pid, @cvphoto)", addcon);
                MemoryStream stream = new MemoryStream();
                pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();

                cmd.Parameters.AddWithValue("@pid", label1.Text);

                cmd.Parameters.AddWithValue("@cvphoto", pic);


                cmd.ExecuteNonQuery();
                addcon.Close();
            MessageBox.Show("تم اضافة السيرة الذاتية", "السيرة الذاتية", MessageBoxButtons.OK);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection addcon = new SqlConnection(conn);
            addcon.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [cv] SET cvphoto=@pic WHERE pid ='" + label1.Text + "'", addcon);
            MemoryStream stream = new MemoryStream();
            pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] pic = stream.ToArray();

            cmd.Parameters.Add(new SqlParameter("@pic", pic));
            cmd.Parameters.Add(new SqlParameter("@pid", label1.Text));

            cmd.ExecuteNonQuery();
            addcon.Close();
            MessageBox.Show("تم تحديث السيرة الذاتية", "السيرة الذاتية", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Doc_PrintPage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
                doc.Print();
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
        }
    }
}
