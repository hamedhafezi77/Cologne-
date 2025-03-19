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
    public partial class frmSabteSefaresh : Form
    {
        public frmSabteSefaresh()
        {
            InitializeComponent();
        }

        private void txtGheymatForosh_TextChanged(object sender, EventArgs e)
        {
            // کد مربوط به جدا کردن 3 رقم 3 رقم اعداد
            if (!string.IsNullOrEmpty(txtGheymatForosh.Text))
            {
                txtGheymatForosh.Text = String.Format("{0:n0}", Convert.ToInt64(txtGheymatForosh.Text.Replace(",", "")));
                txtGheymatForosh.Select(txtGheymatForosh.TextLength, 0);
            }
        }

        private void txtGheymatForosh_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  دریافت فقط عدد
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            //دریافت فقط حروف 
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  دریافت فقط عدد
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
