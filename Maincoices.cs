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
    public partial class Maincoices : Form
    {
        public Maincoices()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form myForm = new teammembers();
            myForm.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form myForm = new usermanag();
            myForm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form myForm = new dep();
            myForm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form myForm = new editemployee();
            myForm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form myForm = new empstatist();
            myForm.Show();
        }

        private void Maincoices_Load(object sender, EventArgs e)
        {

        }

        private void button13_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(" اطلع على اقسام الدائرة واضف اقساما جديدة اذا اردت", button13);
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(" اطلع على اسماء فريق عمل الدائرة ", button9);

        }

        private void button14_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(" يمكنك مشاهدة بعض المعلومات التي تعكس الاداء الوظيفي عن الموظف ", button14);

        }

        private void button11_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(" اجراء تعديلات على المعلومات الشخصية للموظفين ", button11);

        }

        private void button15_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(" اضف مستخدمون جدد لهذا النظام او غير كلمات المرور ", button15);

        }
    }
}
