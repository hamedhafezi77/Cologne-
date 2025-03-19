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
    public partial class frmSabteFaktoreJadid : Form
    {
        public frmSabteFaktoreJadid()
        {
            InitializeComponent();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void txtMablagh_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMablagh.Text))
            {
                txtMablagh.Text = string.Format("{0:n0}", Convert.ToInt64(txtMablagh.Text.Replace(",", "")));
                txtMablagh.Select(txtMablagh.TextLength, 0);
            }
        }

        private void rbNaghd_CheckedChanged(object sender, EventArgs e)
        {
            if(rbNaghd.Checked)
            {
                dateTimePicker2.Enabled = false;
            }
            else
            {
                dateTimePicker2.Enabled = true;
            }
        }

        private void txtShomareFaktor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text=="" || txtShomareFaktor.Text=="" ||!rbNaghd.Checked && !rbCheck.Checked || dateTimePicker2.Text=="" || txtMablagh.Text=="")
            {
                MessageBox.Show("لطفا تمام کادر ها را پر کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
         }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
