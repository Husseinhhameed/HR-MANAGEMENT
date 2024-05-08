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
    public partial class Login : Form
    {
        string conn = ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString;
        public static string usrn = "";

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("يرجى ادخال اسم المستخدم", "تصحيح الادخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (textBox2.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("يرجى ادخال كلمة المرور", "تصحيح الادخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            if (Isvalid())
            {
                
                string query = "Select * from users where username = '" + textBox1.Text.Trim() + "' AND  password = '" + textBox2.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dta = new DataTable();
                sda.Fill(dta);
                if (dta.Rows.Count == 1)
                {
                    usrn = textBox1.Text;
                     main mainform = new main();
                    this.Hide();
                    mainform.Show();
                }
                else if (dta.Rows.Count == 0)
                {
                    MessageBox.Show("اسم المستخدم او كلمة المرور غير صحيحة", "تصحيح الادخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }
        private bool Isvalid()
        {
            if (textBox1.Text.TrimStart() == string.Empty)
            {
                return false;
            }
            else if (textBox2.Text.TrimStart() == string.Empty)
            {
                return false;
            }
            return true;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
        }
    }
}
