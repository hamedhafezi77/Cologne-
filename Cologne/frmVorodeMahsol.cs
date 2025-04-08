using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cologne
{
    public partial class frmVorodeMahsol : Form
    {
        public frmVorodeMahsol()
        {
            InitializeComponent();
        }

        CologneDBEntities1 db =new CologneDBEntities1();
        internal void TxtClear()
        {
            lblIdV.Text="";
            txtNameMahsol.Clear();
            txtTedad.Clear();
            txtGheymatKharid.Clear();
            cmbHajm.Text = "";
            txtNameMahsol.Focus();
            dataGridView1.ClearSelection();
        }
        internal void ShowAllDate() // تابعی که خودم تعریف کردمpri
        {
            using (CologneDBEntities1 db = new CologneDBEntities1())
            {
                dataGridView1.DataSource = db.tblVorodeMahsol.ToList();
                // تابعی که اطلاعات را از جدول در دیتاگرید ویوو نمایش میدهد
            }
        }
        private new void Update()
        {
            //این تابع برای نمایش تعداد رکورد های دیتاگرید ویو هستش
            int recordCount = db.tblVorodeMahsol.Count();
            lblRecord.Text = db.tblVorodeMahsol.Count().ToString();
        }
        public static void OnlyDigit(object sender, KeyPressEventArgs e)
        {
            // تعریف تابع دریافت فقط عدد
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }
      

        private void frmVorodeMahsol_KeyUp(object sender, KeyEventArgs e)
        {
            /*
            if (e.Control && e.KeyCode == Keys.N)
            {
                btnSave.PerformClick();
            }
            */
            // این کد برای ساختن کلید میانبر دکمه ی ذخیره می باشد
            // باید در فرم فعال باشد KeyPreview فقط رویداد 
        }
        private void frmVorodeMahsol_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("B Nazanin", 14, FontStyle.Bold);// این خط کد فونت دیتاگریدویو رو عوض میکند
            ShowAllDate();
            Update();
            dataGridView1.ClearSelection();
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
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {

                dataGridView1.DataSource = db.tblVorodeMahsol.ToList(); // اگر تکست باکس خالی شد، بازگشت به داده‌های اولیه
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;// صفحه ی دیتاگریدویو رو میبره به آخرین رکورد
            }
            else
            {
                // جستجو در داده‌ها
                var results = db.tblVorodeMahsol.Where(x => x.NameMahsol.Contains(searchText)).ToList();
                dataGridView1.DataSource = results;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            TxtClear();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtNameMahsol.Text == "" || txtTedad.Text == "" || cmbHajm.Text == "" || txtGheymatKharid.Text == "")
            {
                MessageBox.Show("لطفا کادر های خالی را پر کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                db.InsertTblVorodeMahsol(txtNameMahsol.Text, int.Parse(txtTedad.Text), cmbHajm.Text, dateTimePicker1.Value, int.Parse(txtGheymatKharid.Text.Replace(",", "")));
                db.SaveChanges();
                MessageBox.Show(" اطلاعات با موفقیت ذخیره شد ");

            }
            TxtClear();
            ShowAllDate();
            Update();

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            db.UpdateTblVorodeMahsol(int.Parse(lblIdV.Text), txtNameMahsol.Text, int.Parse(txtTedad.Text), cmbHajm.Text, dateTimePicker1.Value, int.Parse(txtGheymatKharid.Text.Replace(",", "")));
            db.SaveChanges();
            MessageBox.Show(" اطلاعات با موفقیت ویرایش شد ");
            TxtClear(); // فراخوانی تابع پاک کردن تکست باکس ها
            ShowAllDate();
            Update();


        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblIdV.Text.Length > 0) // (اگر تکست باکس آیدی بزرگ تر از 0 بود دستورات زیر را انجام بده(برای زمانی که کاربر رکوردی را انتخاب نکرده است و تکست باکس آیدی خالی است
            {
                if (MessageBox.Show("آیا از حذف رکورد مورد نظر مطمِئن هستید ؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.DeletetblVorodeMahsol(int.Parse(lblIdV.Text));
                    db.SaveChanges();
                    db.ResetIdTblVorodeMahsol();         // فراخوانی استورپروسیجر برای آپدیت کردن آیدی ها که به ترتیب پشت سر هم و مرتب باشند

                    MessageBox.Show("رکورد مورد نظر با موفقیت حذف شد");
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
        
       
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //  اگر رکوردی از دیتاگریدویو انتخاب بشه باتن سیو خاموش میشه
            btnSave.Enabled = dataGridView1.SelectedRows.Count == 0;

            // صفحه ی دیتاگریدویو رو میبره به آخرین رکورد
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIdV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNameMahsol.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtTedad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmbHajm.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtGheymatKharid.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            // با CurrentRow میگوییم که ببین کاربر رو چه سطری کلیک کرد
            // با Cells [مقدار ستون مشخص میشود و با [شماره سطون

        }

        
    }
}

