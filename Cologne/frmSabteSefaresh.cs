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
        CologneDBEntities1 db = new CologneDBEntities1();
        internal void TxtClear()
        {
            lblId.Text="";
            txtNameMahsol2.Clear();
            cmbHajm.Text="";
            txtGheymatForosh.Clear();
            txtNameKharidar.Clear();
            txtTel.Clear();
            txtAddress.Clear();
            txtNameMahsol2.Focus();
            dataGridView1.ClearSelection();
        }
        internal void ShowAllDate() // تابعی که خودم تعریف کردم
        {
            using (CologneDBEntities1 db = new CologneDBEntities1())
            {
                dataGridView1.DataSource = db.tblSabteSefaresh.ToList();
                // تابعی که اطلاعات را از جدول در دیتاگرید ویوو نمایش میدهد
            }
        }
        private new void Update()
        {
            //این تابع برای نمایش تعداد رکورد های دیتاگرید ویو هستش
            int recordCount = db.tblSabteSefaresh.Count();
            lblRecord.Text = db.tblSabteSefaresh.Count().ToString();
        }
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
        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  دریافت فقط عدد
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //  اگر رکوردی از دیتاگریدویو انتخاب بشه باتن سیو خاموش میشه
            btnSave.Enabled = dataGridView1.SelectedRows.Count == 0;

            // صفحه ی دیتاگریدویو رو میبره به آخرین رکورد
            dataGridView1.FirstDisplayedScrollingColumnIndex= dataGridView1.RowCount - 1;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNameMahsol2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cmbHajm.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtGheymatForosh.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtNameKharidar.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtTel.Text=dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtAddress.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            // با CurrentRow میگوییم که ببین کاربر رو چه سطری کلیک کرد
            // با Cells [مقدار ستون مشخص میشود و با [شماره سطون
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNameMahsol2.Text=="" || cmbHajm.Text=="" || txtGheymatForosh.Text=="" ||
            txtNameKharidar.Text=="" ||txtTel.Text=="" || txtAddress.Text=="" )
            {
                MessageBox.Show(" لطفا کادر های خالی را پر کنید "," خطا ",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                db.InsertTblSabteSefaresh(txtNameMahsol2.Text, cmbHajm.Text, long.Parse(txtGheymatForosh.Text.Replace(",", "")), dateTimePicker1.Value, txtNameKharidar.Text, int.Parse(txtTel.Text), txtAddress.Text);
                db.SaveChanges();
                MessageBox.Show(" اطلاعات با موفقیت ذخیره شد ");
                TxtClear();
                ShowAllDate();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            db.UpdateTblSabteSefaresh(int.Parse(lblId.Text), txtNameMahsol2.Text, cmbHajm.Text, long.Parse(txtGheymatForosh.Text.Replace(",", "")), dateTimePicker1.Value, txtNameKharidar.Text, long.Parse(txtTel.Text), txtAddress.Text);
            db.SaveChanges();
            MessageBox.Show(" اطلاعات با موفقیت ویرایش شد ");
            TxtClear();
            ShowAllDate();
            Update();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblId.Text.Length > 0)
            {
                if (MessageBox.Show(" آیا از حذف رکورد مورد نظر مطمِئن هستید ؟ ", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.DeleteTblSabteSefaresh(int.Parse(lblId.Text));
                    db.SaveChanges();
                    db.ResetIdTblSabteSefaresh();
                    MessageBox.Show(" رکورد مورد نظر با موفقیت حذف شد ");
                    TxtClear();
                    ShowAllDate();
                }
            }
            Update();
            dataGridView1.ClearSelection();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            TxtClear();
        }

        private void frmSabteSefaresh_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("B Nazanin", 14, FontStyle.Bold);// این خط کد فونت دیتاگریدویو رو عوض میکند
            ShowAllDate();
            Update();
            dataGridView1.ClearSelection();

            // این کد برای این است که دیتاگرید ویو از راست نمایش داده شود
            dataGridView1.HorizontalScrollingOffset = 0;
        }

       
    }
}
