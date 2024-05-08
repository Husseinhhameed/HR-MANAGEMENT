using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROTOCOLMANAGEMENT
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Pnlfrmloader_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.pnlformloader.Controls.Clear();
            Addmember Addmember_Vrb = new Addmember() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Addmember_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlformloader.Controls.Add(Addmember_Vrb);
            Addmember_Vrb.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void main_Load(object sender, EventArgs e)
        {
           label1.Text= Login.usrn.Trim();
            panel3.Visible = false;
            this.pnlformloader.Controls.Clear();
            Maincoices Maincoices_Vrb = new Maincoices() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Maincoices_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlformloader.Controls.Add(Maincoices_Vrb);
            Maincoices_Vrb.Show();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
           
        }

        private void pnlformloader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel3.Visible = true;
             panel3.Height = button1.Height;
            panel3.Top = button1.Top;
            panel3.Left = button1.Left;
            button1.BackColor = Color.FromArgb(46, 51, 73);
            button2.BackColor = Color.FromArgb(24, 30, 54);
            button3.BackColor = Color.FromArgb(24, 30, 54);
            button4.BackColor = Color.FromArgb(24, 30, 54);
            button5.BackColor = Color.FromArgb(24, 30, 54);
            button6.BackColor = Color.FromArgb(24, 30, 54);
            button7.BackColor = Color.FromArgb(24, 30, 54);
            button8.BackColor = Color.FromArgb(24, 30, 54);
            button9.BackColor = Color.FromArgb(24, 30, 54);


            this.pnlformloader.Controls.Clear();
            Addmember Addmember_Vrb = new Addmember() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Addmember_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlformloader.Controls.Add(Addmember_Vrb);
            Addmember_Vrb.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;

            panel3.Height = button2.Height;
            panel3.Top = button2.Top;
            panel3.Left = button2.Left;
            button2.BackColor = Color.FromArgb(46, 51, 73);
            button1.BackColor = Color.FromArgb(24, 30, 54);
            button3.BackColor = Color.FromArgb(24, 30, 54);
            button4.BackColor = Color.FromArgb(24, 30, 54);
            button5.BackColor = Color.FromArgb(24, 30, 54);
            button6.BackColor = Color.FromArgb(24, 30, 54);
            button7.BackColor = Color.FromArgb(24, 30, 54);
            button8.BackColor = Color.FromArgb(24, 30, 54);
            button9.BackColor = Color.FromArgb(24, 30, 54);

            this.pnlformloader.Controls.Clear();
            
            Searchbox Searchbox_Vrb = new Searchbox() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Searchbox_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlformloader.Controls.Add(Searchbox_Vrb);
            Searchbox_Vrb.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Searchbox.SetValueForpid == "")
            {
                panel3.Visible = true;

                panel3.Height = button3.Height;
                panel3.Top = button3.Top;
                panel3.Left = button3.Left;
                button3.BackColor = Color.FromArgb(46, 51, 73);
                button1.BackColor = Color.FromArgb(24, 30, 54);
                button2.BackColor = Color.FromArgb(24, 30, 54);
                button4.BackColor = Color.FromArgb(24, 30, 54);
                button5.BackColor = Color.FromArgb(24, 30, 54);
                button6.BackColor = Color.FromArgb(24, 30, 54);
                button7.BackColor = Color.FromArgb(24, 30, 54);
                button8.BackColor = Color.FromArgb(24, 30, 54);
                button9.BackColor = Color.FromArgb(24, 30, 54);

                this.pnlformloader.Controls.Clear();
                notfound notfound_Vrb = new notfound() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                notfound_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.pnlformloader.Controls.Add(notfound_Vrb);
                notfound_Vrb.Show();
            }
            else
            {
                panel3.Visible = true;

                panel3.Height = button3.Height;
                panel3.Top = button3.Top;
                panel3.Left = button3.Left;
                button3.BackColor = Color.FromArgb(46, 51, 73);
                button1.BackColor = Color.FromArgb(24, 30, 54);
                button2.BackColor = Color.FromArgb(24, 30, 54);
                button4.BackColor = Color.FromArgb(24, 30, 54);
                button5.BackColor = Color.FromArgb(24, 30, 54);
                button6.BackColor = Color.FromArgb(24, 30, 54);
                button7.BackColor = Color.FromArgb(24, 30, 54);
                button8.BackColor = Color.FromArgb(24, 30, 54);
                button9.BackColor = Color.FromArgb(24, 30, 54);

                this.pnlformloader.Controls.Clear();
                CV CV_Vrb = new CV() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                CV_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.pnlformloader.Controls.Add(CV_Vrb);
                CV_Vrb.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Searchbox.SetValueForpid == "")
            {
                panel3.Visible = true;

                panel3.Height = button4.Height;
                panel3.Top = button4.Top;
                panel3.Left = button4.Left;
                button4.BackColor = Color.FromArgb(46, 51, 73);
                button1.BackColor = Color.FromArgb(24, 30, 54);
                button2.BackColor = Color.FromArgb(24, 30, 54);
                button3.BackColor = Color.FromArgb(24, 30, 54);
                button5.BackColor = Color.FromArgb(24, 30, 54);
                button6.BackColor = Color.FromArgb(24, 30, 54);
                button7.BackColor = Color.FromArgb(24, 30, 54);
                button8.BackColor = Color.FromArgb(24, 30, 54);
                button9.BackColor = Color.FromArgb(24, 30, 54);

                this.pnlformloader.Controls.Clear();
                notfound notfound_Vrb = new notfound() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                notfound_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.pnlformloader.Controls.Add(notfound_Vrb);
                notfound_Vrb.Show();
            }
            else
            {
                panel3.Visible = true;

                panel3.Height = button4.Height;
                panel3.Top = button4.Top;
                panel3.Left = button4.Left;
                button4.BackColor = Color.FromArgb(46, 51, 73);
                button1.BackColor = Color.FromArgb(24, 30, 54);
                button2.BackColor = Color.FromArgb(24, 30, 54);
                button3.BackColor = Color.FromArgb(24, 30, 54);
                button5.BackColor = Color.FromArgb(24, 30, 54);
                button6.BackColor = Color.FromArgb(24, 30, 54);
                button7.BackColor = Color.FromArgb(24, 30, 54);
                button8.BackColor = Color.FromArgb(24, 30, 54);
                button9.BackColor = Color.FromArgb(24, 30, 54);

                this.pnlformloader.Controls.Clear();
                orders orders_Vrb = new orders() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                orders_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.pnlformloader.Controls.Add(orders_Vrb);
                orders_Vrb.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Searchbox.SetValueForpid == "")
            {
                panel3.Visible = true;

                panel3.Height = button5.Height;
                panel3.Top = button5.Top;
                panel3.Left = button5.Left;
                button5.BackColor = Color.FromArgb(46, 51, 73);
                button1.BackColor = Color.FromArgb(24, 30, 54);
                button2.BackColor = Color.FromArgb(24, 30, 54);
                button3.BackColor = Color.FromArgb(24, 30, 54);
                button4.BackColor = Color.FromArgb(24, 30, 54);
                button6.BackColor = Color.FromArgb(24, 30, 54);
                button7.BackColor = Color.FromArgb(24, 30, 54);
                button8.BackColor = Color.FromArgb(24, 30, 54);
                button9.BackColor = Color.FromArgb(24, 30, 54);

                this.pnlformloader.Controls.Clear();
                notfound notfound_Vrb = new notfound() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                notfound_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.pnlformloader.Controls.Add(notfound_Vrb);
                notfound_Vrb.Show();
            }
            else
            {
                panel3.Visible = true;

                panel3.Height = button5.Height;
                panel3.Top = button5.Top;
                panel3.Left = button5.Left;
                button5.BackColor = Color.FromArgb(46, 51, 73);
                button1.BackColor = Color.FromArgb(24, 30, 54);
                button2.BackColor = Color.FromArgb(24, 30, 54);
                button3.BackColor = Color.FromArgb(24, 30, 54);
                button4.BackColor = Color.FromArgb(24, 30, 54);
                button6.BackColor = Color.FromArgb(24, 30, 54);
                button7.BackColor = Color.FromArgb(24, 30, 54);
                button8.BackColor = Color.FromArgb(24, 30, 54);
                button9.BackColor = Color.FromArgb(24, 30, 54);

                this.pnlformloader.Controls.Clear();
                thanks thanks_Vrb = new thanks() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                thanks_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.pnlformloader.Controls.Add(thanks_Vrb);
                thanks_Vrb.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Searchbox.SetValueForpid == "")
            {
                panel3.Visible = true;

                panel3.Height = button6.Height;
                panel3.Top = button6.Top;
                panel3.Left = button6.Left;
                button6.BackColor = Color.FromArgb(46, 51, 73);
                button1.BackColor = Color.FromArgb(24, 30, 54);
                button2.BackColor = Color.FromArgb(24, 30, 54);
                button3.BackColor = Color.FromArgb(24, 30, 54);
                button4.BackColor = Color.FromArgb(24, 30, 54);
                button5.BackColor = Color.FromArgb(24, 30, 54);
                button7.BackColor = Color.FromArgb(24, 30, 54);
                button8.BackColor = Color.FromArgb(24, 30, 54);
                button9.BackColor = Color.FromArgb(24, 30, 54);

                this.pnlformloader.Controls.Clear();
                notfound notfound_Vrb = new notfound() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                notfound_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.pnlformloader.Controls.Add(notfound_Vrb);
                notfound_Vrb.Show();
            }
            else
            {
                panel3.Visible = true;

                panel3.Height = button6.Height;
                panel3.Top = button6.Top;
                panel3.Left = button6.Left;
                button6.BackColor = Color.FromArgb(46, 51, 73);
                button1.BackColor = Color.FromArgb(24, 30, 54);
                button2.BackColor = Color.FromArgb(24, 30, 54);
                button3.BackColor = Color.FromArgb(24, 30, 54);
                button4.BackColor = Color.FromArgb(24, 30, 54);
                button5.BackColor = Color.FromArgb(24, 30, 54);
                button7.BackColor = Color.FromArgb(24, 30, 54);
                button8.BackColor = Color.FromArgb(24, 30, 54);
                button9.BackColor = Color.FromArgb(24, 30, 54);

                this.pnlformloader.Controls.Clear();
                vacations vacations_Vrb = new vacations() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                vacations_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.pnlformloader.Controls.Add(vacations_Vrb);
                vacations_Vrb.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Searchbox.SetValueForpid == "")
            {
                panel3.Visible = true;

                panel3.Height = button7.Height;
                panel3.Top = button7.Top;
                panel3.Left = button7.Left;
                button7.BackColor = Color.FromArgb(46, 51, 73);
                button1.BackColor = Color.FromArgb(24, 30, 54);
                button2.BackColor = Color.FromArgb(24, 30, 54);
                button3.BackColor = Color.FromArgb(24, 30, 54);
                button4.BackColor = Color.FromArgb(24, 30, 54);
                button5.BackColor = Color.FromArgb(24, 30, 54);
                button6.BackColor = Color.FromArgb(24, 30, 54);
                button8.BackColor = Color.FromArgb(24, 30, 54);
                button9.BackColor = Color.FromArgb(24, 30, 54);

                this.pnlformloader.Controls.Clear();
                notfound notfound_Vrb = new notfound() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                notfound_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.pnlformloader.Controls.Add(notfound_Vrb);
                notfound_Vrb.Show();
            }
            else
            {
                panel3.Visible = true;

                panel3.Height = button7.Height;
                panel3.Top = button7.Top;
                panel3.Left = button7.Left;
                button7.BackColor = Color.FromArgb(46, 51, 73);
                button1.BackColor = Color.FromArgb(24, 30, 54);
                button2.BackColor = Color.FromArgb(24, 30, 54);
                button3.BackColor = Color.FromArgb(24, 30, 54);
                button4.BackColor = Color.FromArgb(24, 30, 54);
                button5.BackColor = Color.FromArgb(24, 30, 54);
                button6.BackColor = Color.FromArgb(24, 30, 54);
                button8.BackColor = Color.FromArgb(24, 30, 54);
                button9.BackColor = Color.FromArgb(24, 30, 54);

                this.pnlformloader.Controls.Clear();
                training training_Vrb = new training() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                training_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.pnlformloader.Controls.Add(training_Vrb);
                training_Vrb.Show();
            }
            
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            panel3.Visible = false;
            button1.BackColor = Color.FromArgb(24, 30, 54);
            button2.BackColor = Color.FromArgb(24, 30, 54);
            button3.BackColor = Color.FromArgb(24, 30, 54);
            button4.BackColor = Color.FromArgb(24, 30, 54);
            button5.BackColor = Color.FromArgb(24, 30, 54);
            button6.BackColor = Color.FromArgb(24, 30, 54);
            button7.BackColor = Color.FromArgb(24, 30, 54);
            button8.BackColor = Color.FromArgb(24, 30, 54);
            button9.BackColor = Color.FromArgb(24, 30, 54);

            this.pnlformloader.Controls.Clear();
            Maincoices Maincoices_Vrb = new Maincoices() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Maincoices_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlformloader.Controls.Add(Maincoices_Vrb);
            Maincoices_Vrb.Show();
            checkBox1.Checked = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Searchbox.SetValueForpid == "")
            {
                panel3.Visible = true;

                panel3.Height = button8.Height;
                panel3.Top = button8.Top;
                panel3.Left = button8.Left;
                button8.BackColor = Color.FromArgb(46, 51, 73);
                button1.BackColor = Color.FromArgb(24, 30, 54);
                button2.BackColor = Color.FromArgb(24, 30, 54);
                button3.BackColor = Color.FromArgb(24, 30, 54);
                button4.BackColor = Color.FromArgb(24, 30, 54);
                button5.BackColor = Color.FromArgb(24, 30, 54);
                button6.BackColor = Color.FromArgb(24, 30, 54);
                button7.BackColor = Color.FromArgb(24, 30, 54);
                button9.BackColor = Color.FromArgb(24, 30, 54);

                this.pnlformloader.Controls.Clear();
                notfound notfound_Vrb = new notfound() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                notfound_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.pnlformloader.Controls.Add(notfound_Vrb);
                notfound_Vrb.Show();
            }
            else
            {
                panel3.Visible = true;

                panel3.Height = button8.Height;
                panel3.Top = button8.Top;
                panel3.Left = button8.Left;
                button8.BackColor = Color.FromArgb(46, 51, 73);
                button1.BackColor = Color.FromArgb(24, 30, 54);
                button2.BackColor = Color.FromArgb(24, 30, 54);
                button3.BackColor = Color.FromArgb(24, 30, 54);
                button4.BackColor = Color.FromArgb(24, 30, 54);
                button5.BackColor = Color.FromArgb(24, 30, 54);
                button6.BackColor = Color.FromArgb(24, 30, 54);
                button7.BackColor = Color.FromArgb(24, 30, 54);
                button9.BackColor = Color.FromArgb(24, 30, 54);

                this.pnlformloader.Controls.Clear();
                punish punish_Vrb = new punish() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                punish_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.pnlformloader.Controls.Add(punish_Vrb);
                punish_Vrb.Show();
            }
        }

        private void button1_Leave(object sender, EventArgs e)
        {

        }

        private void button2_Leave(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.pnlformloader.Controls.Clear();
                statistics statistics_Vrb = new statistics() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                statistics_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.pnlformloader.Controls.Add(statistics_Vrb);
                statistics_Vrb.Show();
            }
            else
            {
                panel3.Visible = false;
                button1.BackColor = Color.FromArgb(24, 30, 54);
                button2.BackColor = Color.FromArgb(24, 30, 54);
                button3.BackColor = Color.FromArgb(24, 30, 54);
                button4.BackColor = Color.FromArgb(24, 30, 54);
                button5.BackColor = Color.FromArgb(24, 30, 54);
                button6.BackColor = Color.FromArgb(24, 30, 54);
                button7.BackColor = Color.FromArgb(24, 30, 54);
                button8.BackColor = Color.FromArgb(24, 30, 54);
                button9.BackColor = Color.FromArgb(24, 30, 54);

                this.pnlformloader.Controls.Clear();
                Maincoices Maincoices_Vrb = new Maincoices() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                Maincoices_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.pnlformloader.Controls.Add(Maincoices_Vrb);
                Maincoices_Vrb.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click_2(object sender, EventArgs e)
        {
            if (Searchbox.SetValueForpid == "")
            {
                panel3.Visible = true;

                panel3.Height = button9.Height;
                panel3.Top = button9.Top;
                panel3.Left = button9.Left;
                button9.BackColor = Color.FromArgb(46, 51, 73);
                button1.BackColor = Color.FromArgb(24, 30, 54);
                button2.BackColor = Color.FromArgb(24, 30, 54);
                button3.BackColor = Color.FromArgb(24, 30, 54);
                button4.BackColor = Color.FromArgb(24, 30, 54);
                button5.BackColor = Color.FromArgb(24, 30, 54);
                button6.BackColor = Color.FromArgb(24, 30, 54);
                button7.BackColor = Color.FromArgb(24, 30, 54);
                button8.BackColor = Color.FromArgb(24, 30, 54);


                this.pnlformloader.Controls.Clear();
                notfound notfound_Vrb = new notfound() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                notfound_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.pnlformloader.Controls.Add(notfound_Vrb);
                notfound_Vrb.Show();
            }
            else
            {
                panel3.Visible = true;

                panel3.Height = button9.Height;
                panel3.Top = button9.Top;
                panel3.Left = button9.Left;
                button9.BackColor = Color.FromArgb(46, 51, 73);
                button1.BackColor = Color.FromArgb(24, 30, 54);
                button2.BackColor = Color.FromArgb(24, 30, 54);
                button3.BackColor = Color.FromArgb(24, 30, 54);
                button4.BackColor = Color.FromArgb(24, 30, 54);
                button5.BackColor = Color.FromArgb(24, 30, 54);
                button6.BackColor = Color.FromArgb(24, 30, 54);
                button7.BackColor = Color.FromArgb(24, 30, 54);
                button8.BackColor = Color.FromArgb(24, 30, 54);

                this.pnlformloader.Controls.Clear();
                Dispatches dis_Vrb = new Dispatches() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                dis_Vrb.FormBorderStyle = FormBorderStyle.None;
                this.pnlformloader.Controls.Add(dis_Vrb);
                dis_Vrb.Show();
            }
        }
    }
}
