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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ورودمحصولاتجدیدToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVorodeMahsol frm = new frmVorodeMahsol();
            frm.ShowDialog();
        }

        private void ثبتفاکتورجدیدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSabteFaktoreJadid frm = new frmSabteFaktoreJadid();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //دستورات زیر هر 1 ثانیه یک بار انجام میشود. در پروپرتی های تایمر 
            // interval را به 1000 تغییر دادیم

            label1.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongDateString();
        }

        private void ثبتسفارشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSabteSefaresh frm = new frmSabteSefaresh();
            frm.ShowDialog();
        }
    }
}
