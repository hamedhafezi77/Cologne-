namespace Cologne
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ورودمحصولاتجدیدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ورودمحصولاتجدیدToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ثبتسفارشToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حسابداریToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ثبتفاکتورجدیدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.محاسبهیدرآمدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ورودمحصولاتجدیدToolStripMenuItem,
            this.حسابداریToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(1025, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ورودمحصولاتجدیدToolStripMenuItem
            // 
            this.ورودمحصولاتجدیدToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ورودمحصولاتجدیدToolStripMenuItem1,
            this.ثبتسفارشToolStripMenuItem});
            this.ورودمحصولاتجدیدToolStripMenuItem.Name = "ورودمحصولاتجدیدToolStripMenuItem";
            this.ورودمحصولاتجدیدToolStripMenuItem.Size = new System.Drawing.Size(43, 24);
            this.ورودمحصولاتجدیدToolStripMenuItem.Text = "منو";
            // 
            // ورودمحصولاتجدیدToolStripMenuItem1
            // 
            this.ورودمحصولاتجدیدToolStripMenuItem1.Name = "ورودمحصولاتجدیدToolStripMenuItem1";
            this.ورودمحصولاتجدیدToolStripMenuItem1.Size = new System.Drawing.Size(215, 26);
            this.ورودمحصولاتجدیدToolStripMenuItem1.Text = "ورود محصولات جدید";
            this.ورودمحصولاتجدیدToolStripMenuItem1.Click += new System.EventHandler(this.ورودمحصولاتجدیدToolStripMenuItem1_Click);
            // 
            // ثبتسفارشToolStripMenuItem
            // 
            this.ثبتسفارشToolStripMenuItem.Name = "ثبتسفارشToolStripMenuItem";
            this.ثبتسفارشToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.ثبتسفارشToolStripMenuItem.Text = "ثبت سفارش";
            this.ثبتسفارشToolStripMenuItem.Click += new System.EventHandler(this.ثبتسفارشToolStripMenuItem_Click);
            // 
            // حسابداریToolStripMenuItem
            // 
            this.حسابداریToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ثبتفاکتورجدیدToolStripMenuItem,
            this.محاسبهیدرآمدToolStripMenuItem});
            this.حسابداریToolStripMenuItem.Name = "حسابداریToolStripMenuItem";
            this.حسابداریToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.حسابداریToolStripMenuItem.Text = "حسابداری";
            // 
            // ثبتفاکتورجدیدToolStripMenuItem
            // 
            this.ثبتفاکتورجدیدToolStripMenuItem.Name = "ثبتفاکتورجدیدToolStripMenuItem";
            this.ثبتفاکتورجدیدToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.ثبتفاکتورجدیدToolStripMenuItem.Text = "ثبت فاکتور خرید جدید";
            this.ثبتفاکتورجدیدToolStripMenuItem.Click += new System.EventHandler(this.ثبتفاکتورجدیدToolStripMenuItem_Click);
            // 
            // محاسبهیدرآمدToolStripMenuItem
            // 
            this.محاسبهیدرآمدToolStripMenuItem.Name = "محاسبهیدرآمدToolStripMenuItem";
            this.محاسبهیدرآمدToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.محاسبهیدرآمدToolStripMenuItem.Text = "محاسبه ی درآمد";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 542);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(92, 577);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 24);
            this.label2.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1025, 669);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rose Perfium";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ورودمحصولاتجدیدToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ورودمحصولاتجدیدToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ثبتسفارشToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem حسابداریToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ثبتفاکتورجدیدToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem محاسبهیدرآمدToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

