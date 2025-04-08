using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cologne
{
    public partial class frmSoratVaziat: Form
   
    {
        
        private Bitmap memoryImage; // مربوط به پرینت
        private void CaptureForm()
        {
            Graphics g = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, g);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            Point screenPoint = this.PointToScreen(Point.Empty);
            memoryGraphics.CopyFromScreen(screenPoint.Y, screenPoint.X, 0, 0, s);
        }// مربوط به پرینت
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            int imgWidth = memoryImage.Width;
            int imgHeight = memoryImage.Height;

            int pageWidth = e.MarginBounds.Width;
            int pageHeight = e.MarginBounds.Height;

            float scale = Math.Min((float)pageWidth / imgWidth, (float)pageHeight / imgHeight);

            int printWidth = (int)(imgWidth * scale);
            int printHeight = (int)(imgHeight * scale);

            int left = e.MarginBounds.Left + (pageWidth - printWidth) / 2;
            int top = e.MarginBounds.Top + (pageHeight - printHeight) / 2;

            e.Graphics.DrawImage(memoryImage, left, top, printWidth, printHeight);
        }// مربوط به پرینت


        public frmSoratVaziat()
        {
            InitializeComponent();

        }
      
        CologneDBEntities1 db = new CologneDBEntities1();// این کد که ساختنن یه شی از دیتابیس هست رو نوشتم که بتونم توی این فرم از اطلاعات دیتابیس استفاده کنم
        private void TxtFormat(TextBox textBox)// تابع جداکننده اعداد
        {

            // میشد کل کد همین تابع رو توی همه ی تکست باکس ها نوشت ولی اینجوری کد کمتره
            // کلمه رزرو شده می باشد که میتونیم جاش از اسم تکست باکس استفاده کنیم در صورتی که کد رو توی رویداد تکست چنج خود تکست باکس بنویسیم textBox
            
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = string.Format("{0:n0}", Convert.ToInt64(textBox.Text.Replace(",", "")));
                textBox.Select(textBox.TextLength, 0);

            }
        }
        private void HesabeSod()
        {
           // این تابع مجموع ستون قیمت خرید در فرم ورود محصول و قیمت فروش در فرم ثبت سفارش رو از هم کم میکنه و نتیجه رو توی تکست باکس در فرم صورت وضعیت نمایش میده 
           
                // جمع کل مبالغ فاکتورها
                decimal totalFaktor = db.tblVorodeMahsol.Sum(f => f.GheymateKharid);

                // جمع کل قیمت فروش‌ها
                decimal totalForosh = db.tblSabteSefaresh.Sum( g=> g.GheymateForosh);

                // محاسبه سود
                decimal sod = totalForosh - totalFaktor;

                // نمایش در تکست باکس
                txtSodAzSarmaye.Text = sod.ToString(); // نمایش با جداکننده هزارگان
           
        }


      
        private void frmSoratVaziat_Load(object sender, EventArgs e)
        {
            txtTedadeKoleFaktorFrmSoratVaziat.Text = db.tblSabteFaktoreJadid.Count().ToString();
            txtTedadMahsolByFrmSoratvaziat.Text=db.tblVorodeMahsol.Count().ToString(); 
            txtTedadMahsolSellFrmSoratvaziat.Text=db.tblSabteSefaresh.Count().ToString();
            txtMizanMabaleqFaktor.Text=db.tblSabteFaktoreJadid.Sum(x=>x.MablagheKoleFaktor).ToString();
            txtMizanMabaleqForosh.Text=db.tblSabteSefaresh.Sum(x=>x.GheymateForosh).ToString();
            HesabeSod();

            // این کد برای محاسبه ی موجودی انبار می باشد 
            try
            {
                // گرفتن آخرین آیدی ثبت‌شده در جدول ثبت سفارش
                long akharinIdFrmSabteSefaresh = db.tblSabteSefaresh.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // گرفتن آخرین آیدی ثبت‌شده در جدول ورودی محصول
                long akharinIdVoroodi = db.tblVorodeMahsol.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // محاسبه موجودی
                long mojudi = akharinIdVoroodi - akharinIdFrmSabteSefaresh;

                // نمایش در TextBox با جداکننده 3 رقمی
                txtMojudiyeMahsol.Text = mojudi.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در محاسبه موجودی: " + ex.Message);
            }
        }

        private void txtTedadeKoleFaktorFrmSoratVaziat_TextChanged(object sender, EventArgs e)
        {
            // فراخوانی تابع ، جداکننده اعداد
            TxtFormat(txtTedadeKoleFaktorFrmSoratVaziat);
        }
        private void txtTedadeKoleFaktorFrmSoratVaziat_Enter(object sender, EventArgs e)
        {
            // تمرکز را از تکست باکس خارج میکند
            this.ActiveControl = null;
        }


        private void txtTedadMahsolByFrmSoratvaziat_TextChanged(object sender, EventArgs e)
        {
            TxtFormat(txtTedadMahsolByFrmSoratvaziat);//فراخوانی تابع
        }
        private void txtTedadMahsolByFrmSoratvaziat_Enter(object sender, EventArgs e)
        {
            // تمرکز را از تکست باکس خارج میکند
            this.ActiveControl = null;
        }


        private void txtTedadMahsolSellFrmSoratvaziat_TextChanged(object sender, EventArgs e)
        {
            TxtFormat(txtTedadMahsolSellFrmSoratvaziat);// فراخوانی تابع
        }
        private void txtTedadMahsolSellFrmSoratvaziat_Enter(object sender, EventArgs e)
        {
            // تمرکز را از تکست باکس خارج میکند
            this.ActiveControl = null;
        }


        private void txtMojudiyeMahsol_TextChanged(object sender, EventArgs e)
        {
            TxtFormat(txtMojudiyeMahsol);
        }
        private void txtMojudiyeMahsol_Enter(object sender, EventArgs e)
        {
            // تمرکز را از تکست باکس خارج میکند
            this.ActiveControl = null;
        }


        private void txtMizanMabaleqFaktor_TextChanged(object sender, EventArgs e)
        {
            TxtFormat(txtMizanMabaleqFaktor);
        }
        private void txtMizanMabaleqFaktor_Enter(object sender, EventArgs e)
        {
            // تمرکز را از تکست باکس خارج میکند
            this.ActiveControl = null;
        }

        private void txtMizanMabaleqForosh_TextChanged_1(object sender, EventArgs e)
        {
            TxtFormat(txtMizanMabaleqForosh);
        }
        private void txtMizanMabaleqForosh_Enter(object sender, EventArgs e)
        {
            // تمرکز را از تکست باکس خارج میکند
            this.ActiveControl = null;
        }


        private void txtSodAzSarmaye_TextChanged(object sender, EventArgs e)
        {
            TxtFormat(txtSodAzSarmaye);
        }
        private void txtSodAzSarmaye_Enter(object sender, EventArgs e)
        {
            // تمرکز را از تکست باکس خارج میکند
            this.ActiveControl = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //دستورات زیر هر 1 ثانیه یک بار انجام میشود. در پروپرتی های تایمر 
            // interval را به 1000 تغییر دادیم

            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            
            CaptureForm();

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);

            // 👇 تنظیم حالت چاپ به افقی
            printDoc.DefaultPageSettings.Landscape = true;

            // 👇 تنظیم سایز کاغذ به A4 به صورت دستی (بر حسب 1/100 اینچ)
            PaperSize a5Paper = new PaperSize("A5", 583,827); // A4 افقی: 29.7cm x 21cm = 11.69in x 8.27in
            printDoc.DefaultPageSettings.PaperSize = a5Paper;

            // 👇 (اختیاری) تنظیم حاشیه‌ها
            //printDoc.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5); // یک سانت از هر طرف

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
            /*
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            printDialog.Document = printDocument;

            // نمایش دیالوگ پرینت
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.PrintPage += PrintPage;
                printDocument.Print();
            }
            */
        }


    }
    
}
