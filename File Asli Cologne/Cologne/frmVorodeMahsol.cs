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
    public partial class frmVorodeMahsol : Form
    {
        public frmVorodeMahsol()
        {
            InitializeComponent();
        }
        public static void OnlyDigit(object sender, KeyPressEventArgs e)
        {
            // تعریف تابع دریافت فقط عدد
            if(char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtTedad_KeyPress(object sender, KeyPressEventArgs e)
        {
            frmVorodeMahsol.OnlyDigit(sender, e);
        }

        private void txtGheymatKharid_TextChanged(object sender, EventArgs e)
        {
            // کد مربوط به جدا کردن 3 رقم 3 رقم اعداد
            if (!string.IsNullOrEmpty(txtGheymatKharid.Text))
            {
                txtGheymatKharid.Text = String.Format("{0:n0}", Convert.ToInt64(txtGheymatKharid.Text.Replace(",", "")));
                txtGheymatKharid.Select(txtGheymatKharid.TextLength, 0);
            }
        }

        private void txtGheymatKharid_KeyPress(object sender, KeyPressEventArgs e)
        {
            // فراخوانی تابع (فقط عدد)
            frmVorodeMahsol.OnlyDigit(sender, e);
        }

      

        private void txtGheymatForosh_KeyPress(object sender, KeyPressEventArgs e)
        {
            frmVorodeMahsol.OnlyDigit(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNameMahsol.Text=="" || txtTedad.Text=="" || cmbHajm.Text==""||txtGheymatKharid.Text=="")
            {
                MessageBox.Show("لطفا کادر های خالی را پر کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
