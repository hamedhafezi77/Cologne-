using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
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
            frm.Show();
        }
        private void ثبتفاکتورجدیدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSabteFaktoreJadid frm = new frmSabteFaktoreJadid();
            frm.Show();
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
            frm.Show();
        }
        private void محاسبهیدرآمدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSoratVaziat frm = new frmSoratVaziat();
            frm.Show();
        }
        private void دربارهبرنامهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout(); 
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // کد تغییر فونت و سایز منو استریپ
            menuStrip1.Font = new Font("B Nazanin", 12, FontStyle.Bold);
           // menuStrip1.Font = new Font("Times New Roman", 12, FontStyle.Bold);


        }

        private void پشتیبانیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPoshtibani frm = new frmPoshtibani();
            frm.Show();
        }
    }
}
