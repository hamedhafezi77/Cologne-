using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Cologne
{
    public partial class frmSabteFaktoreJadid : Form
    {
        public frmSabteFaktoreJadid()
        {
            InitializeComponent();
        }


        CologneDBEntities1 db = new CologneDBEntities1();
        internal void TxtClear()
        {
            lblId.Text = "";
            txtShomareFaktor.Clear();
            rbNaghd.Checked = false;
            rbCheck.Checked = false;
            txtMablagheKoleFaktor.Clear();
            dateTimePicker1.Focus();
            dataGridView1.ClearSelection();
        }
        internal void ShowAllDate()
        {
            using (CologneDBEntities1 db = new CologneDBEntities1())
            {
                dataGridView1.DataSource = db.tblSabteFaktoreJadid.ToList();
                // تابعی که اطلاعات را از جدول در دیتاگرید ویوو نمایش میدهد
            }
        }
        private new void Update() //این تابع برای نمایش تعداد رکورد های دیتاگرید ویو هستش
        {
            int recordCount = db.tblSabteFaktoreJadid.Count();
            lblTedadKolRecord.Text = db.tblSabteFaktoreJadid.Count().ToString();
        }
        
        private void frmSabteFaktoreJadid_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("B Nazanin", 14, FontStyle.Bold);// این خط کد فونت دیتاگریدویو رو عوض میکند
            ShowAllDate();
            Update();
            dataGridView1.ClearSelection();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtMablagh_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMablagheKoleFaktor.Text))
            {
                txtMablagheKoleFaktor.Text = string.Format("{0:n0}", Convert.ToInt64(txtMablagheKoleFaktor.Text.Replace(",", "")));
                txtMablagheKoleFaktor.Select(txtMablagheKoleFaktor.TextLength, 0);
            }              
           
        }
        private void txtShomareFaktor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        private void rbNaghd_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNaghd.Checked)
            {
                dateTimePicker2.Enabled = false;
            }
            else
            {
                dateTimePicker2.Enabled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            TxtClear();
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text == "" || txtShomareFaktor.Text == "" || !rbNaghd.Checked && !rbCheck.Checked || dateTimePicker2.Text == "" || txtMablagheKoleFaktor.Text == "")
            {
                MessageBox.Show("لطفا تمام کادر ها را پر کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                string RaveshKharid = "";

                if (rbNaghd.Checked)
                {
                    RaveshKharid = "نقد";
                }
                else if (rbCheck.Checked)
                {
                    RaveshKharid = "چک";
                }


                db.InsertTblSabteFaktoreJadid(dateTimePicker1.Value, int.Parse(txtShomareFaktor.Text), RaveshKharid, dateTimePicker2.Value, int.Parse(txtMablagheKoleFaktor.Text.Replace(",", "")));
                db.SaveChanges();
                MessageBox.Show(" اطلاعات با موفقیت ذخیره شد ");
                TxtClear();
                ShowAllDate();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string RaveshKharid="";

            if (rbNaghd.Checked)
            {
                RaveshKharid = "نقد";
            }
            else if (rbCheck.Checked)
            {
                RaveshKharid = "چک";
            }

                db.UpdateTblSabteFaktoreJadid(int.Parse(lblId.Text),dateTimePicker1.Value,int.Parse(txtShomareFaktor.Text),RaveshKharid,dateTimePicker2.Value,long.Parse(txtMablagheKoleFaktor.Text.Replace(",", "")));
                db.SaveChanges();
                MessageBox.Show(" اطلاعات با موفقیت ویرایش شد ");
                TxtClear();
                ShowAllDate();
                Update();
          
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" آیا از حذف رکورد مورد نظر مطمِئن هستید ؟ ", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.DeleteTblSabteFaktoreJadid(int.Parse(lblId.Text));
                db.SaveChanges();
                db.ResetIdTblSabteFaktoreJadid();

                MessageBox.Show(" رکورد مورد نظر با موفقیت حذف شد ");
                TxtClear();
                ShowAllDate(); 
                Update();
                dataGridView1.ClearSelection();
            }
        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {

            //  اگر رکوردی از دیتاگریدویو انتخاب بشه باتن سیو خاموش میشه
            btnSave.Enabled = dataGridView1.SelectedRows.Count == 0;

            // صفحه ی دیتاگریدویو رو میبره به آخرین رکورد
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtShomareFaktor.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtMablagheKoleFaktor.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            /* با CurrentRow میگوییم که ببین کاربر رو چه سطری کلیک کرده.
             و شماره سطون رو با Cells مشخص میکنیم
             در اصل مقادیری که در ستون دیتاگریدویو هست رو به کلیک روی آنها به تکست باکس های نام برده منتقل میکنیم

             */



            /*
             تیکه کد پایین برای اینه که ، میاد ستون سوم دیتاگرید ویو رو بررسی میکنه 
            اگر چک بود  رادیوباتن چک رو روشن میکنه و اگر نقد بود رادیو باتن نقد رو روشن میکنه...
            این تیکه کد برای زمانی هست که یه رکورد انتخاب شده باشه
             */

            // بررسی وجود رکورد انتخاب شده
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // دریافت مقدار سلول چهارم (ایندکس 3)
                string cellValue = dataGridView1.SelectedRows[0].Cells[3].Value?.ToString();

                // بررسی مقدار سلول و تنظیم RadioButton مناسب
                if (cellValue == "چک")
                {
                    rbCheck.Checked = true;
                    rbNaghd.Checked = false;
                }
                else if (cellValue == "نقد")
                {
                    rbCheck.Checked = false;
                    rbNaghd.Checked = true;
                }
                else
                {
                    // اگر مقدار دیگری بود هر دو را غیرفعال کنید
                    rbNaghd.Checked = false;
                    rbCheck.Checked = false;
                }
            }
            else
            {
                // اگر هیچ رکوردی انتخاب نشده بود
                rbCheck.Checked = false;
                rbNaghd.Checked = false;
            }
        }

        
    }
}
