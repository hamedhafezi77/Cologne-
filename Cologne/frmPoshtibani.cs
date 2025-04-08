using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cologne
{
    public partial class frmPoshtibani: Form
    {
        public frmPoshtibani()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label3.Text);
            MessageBox.Show("ایمیل کپی شد");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label4.Text);
            MessageBox.Show("آیدی کپی شد");
        }
    }
}
