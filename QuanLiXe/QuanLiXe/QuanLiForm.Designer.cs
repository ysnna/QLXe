namespace QuanLiXe
{
    partial class QuanLiForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLiForm));
            this.panelForm = new System.Windows.Forms.Panel();
            this.btQuanLiXe = new System.Windows.Forms.Button();
            this.btThongTinTho = new System.Windows.Forms.Button();
            this.btThongTinKhachHang = new System.Windows.Forms.Button();
            this.panelClick = new System.Windows.Forms.Panel();
            this.btGioiThieu = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.thongTinKhachHangUC = new QuanLiXe.UserControls.ThongTinKhachHangUC();
            this.gioiThieuUC = new QuanLiXe.UserControls.GioiThieuUC();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelForm
            // 
            this.panelForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelForm.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelForm.Controls.Add(this.btQuanLiXe);
            this.panelForm.Controls.Add(this.btThongTinTho);
            this.panelForm.Controls.Add(this.btThongTinKhachHang);
            this.panelForm.Controls.Add(this.panelClick);
            this.panelForm.Controls.Add(this.btGioiThieu);
            this.panelForm.Controls.Add(this.pictureBox1);
            this.panelForm.Location = new System.Drawing.Point(-3, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(355, 797);
            this.panelForm.TabIndex = 0;
            // 
            // btQuanLiXe
            // 
            this.btQuanLiXe.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btQuanLiXe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btQuanLiXe.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btQuanLiXe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btQuanLiXe.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQuanLiXe.ForeColor = System.Drawing.Color.Transparent;
            this.btQuanLiXe.Location = new System.Drawing.Point(6, 387);
            this.btQuanLiXe.Name = "btQuanLiXe";
            this.btQuanLiXe.Size = new System.Drawing.Size(349, 80);
            this.btQuanLiXe.TabIndex = 5;
            this.btQuanLiXe.Text = "Quản lí xe";
            this.btQuanLiXe.UseVisualStyleBackColor = true;
            // 
            // btThongTinTho
            // 
            this.btThongTinTho.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btThongTinTho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btThongTinTho.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btThongTinTho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btThongTinTho.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThongTinTho.ForeColor = System.Drawing.Color.Transparent;
            this.btThongTinTho.Location = new System.Drawing.Point(3, 301);
            this.btThongTinTho.Name = "btThongTinTho";
            this.btThongTinTho.Size = new System.Drawing.Size(349, 80);
            this.btThongTinTho.TabIndex = 4;
            this.btThongTinTho.Text = "Thông tin thợ";
            this.btThongTinTho.UseVisualStyleBackColor = true;
            // 
            // btThongTinKhachHang
            // 
            this.btThongTinKhachHang.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btThongTinKhachHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btThongTinKhachHang.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btThongTinKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btThongTinKhachHang.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThongTinKhachHang.ForeColor = System.Drawing.Color.Transparent;
            this.btThongTinKhachHang.Location = new System.Drawing.Point(3, 215);
            this.btThongTinKhachHang.Name = "btThongTinKhachHang";
            this.btThongTinKhachHang.Size = new System.Drawing.Size(349, 80);
            this.btThongTinKhachHang.TabIndex = 2;
            this.btThongTinKhachHang.Text = "Thông tin khách hàng";
            this.btThongTinKhachHang.UseVisualStyleBackColor = true;
            this.btThongTinKhachHang.Click += new System.EventHandler(this.btThongTinKhachHang_Click);
            // 
            // panelClick
            // 
            this.panelClick.BackColor = System.Drawing.Color.AliceBlue;
            this.panelClick.Location = new System.Drawing.Point(3, 129);
            this.panelClick.Name = "panelClick";
            this.panelClick.Size = new System.Drawing.Size(23, 80);
            this.panelClick.TabIndex = 1;
            // 
            // btGioiThieu
            // 
            this.btGioiThieu.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btGioiThieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btGioiThieu.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btGioiThieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGioiThieu.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGioiThieu.ForeColor = System.Drawing.Color.Transparent;
            this.btGioiThieu.Location = new System.Drawing.Point(3, 129);
            this.btGioiThieu.Name = "btGioiThieu";
            this.btGioiThieu.Size = new System.Drawing.Size(349, 80);
            this.btGioiThieu.TabIndex = 0;
            this.btGioiThieu.Text = "Giới thiệu";
            this.btGioiThieu.UseVisualStyleBackColor = true;
            this.btGioiThieu.Click += new System.EventHandler(this.btGioiThieu_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(32, -11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(274, 168);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // thongTinKhachHangUC
            // 
            this.thongTinKhachHangUC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thongTinKhachHangUC.BackColor = System.Drawing.Color.LemonChiffon;
            this.thongTinKhachHangUC.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("thongTinKhachHangUC.BackgroundImage")));
            this.thongTinKhachHangUC.Location = new System.Drawing.Point(350, 0);
            this.thongTinKhachHangUC.Name = "thongTinKhachHangUC";
            this.thongTinKhachHangUC.Size = new System.Drawing.Size(1080, 800);
            this.thongTinKhachHangUC.TabIndex = 2;
            // 
            // gioiThieuUC
            // 
            this.gioiThieuUC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gioiThieuUC.BackColor = System.Drawing.Color.LightBlue;
            this.gioiThieuUC.Location = new System.Drawing.Point(350, 0);
            this.gioiThieuUC.Name = "gioiThieuUC";
            this.gioiThieuUC.Size = new System.Drawing.Size(1080, 800);
            this.gioiThieuUC.TabIndex = 1;
            // 
            // QuanLiForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1426, 798);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.thongTinKhachHangUC);
            this.Controls.Add(this.gioiThieuUC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "QuanLiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lí";
            this.Load += new System.EventHandler(this.QuanLiForm_Load);
            this.panelForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Button btGioiThieu;
        private UserControls.GioiThieuUC gioiThieuUC;
        private System.Windows.Forms.Panel panelClick;
        private System.Windows.Forms.Button btThongTinKhachHang;
        private UserControls.ThongTinKhachHangUC thongTinKhachHangUC;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btThongTinTho;
        private System.Windows.Forms.Button btQuanLiXe;
    }
}