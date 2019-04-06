namespace _17110094_NguyenAnh_Login
{
    partial class StaticForm
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
            this.PanelMale = new System.Windows.Forms.Panel();
            this.PanelFemale = new System.Windows.Forms.Panel();
            this.PanelTotal = new System.Windows.Forms.Panel();
            this.LabelTotal = new System.Windows.Forms.Label();
            this.LabelMale = new System.Windows.Forms.Label();
            this.LabelFemale = new System.Windows.Forms.Label();
            this.PanelMale.SuspendLayout();
            this.PanelFemale.SuspendLayout();
            this.PanelTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMale
            // 
            this.PanelMale.BackColor = System.Drawing.Color.SpringGreen;
            this.PanelMale.Controls.Add(this.LabelMale);
            this.PanelMale.Location = new System.Drawing.Point(1, 149);
            this.PanelMale.Name = "PanelMale";
            this.PanelMale.Size = new System.Drawing.Size(271, 117);
            this.PanelMale.TabIndex = 1;
            // 
            // PanelFemale
            // 
            this.PanelFemale.BackColor = System.Drawing.Color.LightPink;
            this.PanelFemale.Controls.Add(this.LabelFemale);
            this.PanelFemale.Location = new System.Drawing.Point(272, 149);
            this.PanelFemale.Name = "PanelFemale";
            this.PanelFemale.Size = new System.Drawing.Size(276, 117);
            this.PanelFemale.TabIndex = 1;
            // 
            // PanelTotal
            // 
            this.PanelTotal.BackColor = System.Drawing.SystemColors.Highlight;
            this.PanelTotal.Controls.Add(this.LabelTotal);
            this.PanelTotal.Location = new System.Drawing.Point(1, 2);
            this.PanelTotal.Name = "PanelTotal";
            this.PanelTotal.Size = new System.Drawing.Size(547, 150);
            this.PanelTotal.TabIndex = 1;
            // 
            // LabelTotal
            // 
            this.LabelTotal.AutoSize = true;
            this.LabelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotal.Location = new System.Drawing.Point(222, 52);
            this.LabelTotal.Name = "LabelTotal";
            this.LabelTotal.Size = new System.Drawing.Size(93, 32);
            this.LabelTotal.TabIndex = 0;
            this.LabelTotal.Text = "label1";
            // 
            // LabelMale
            // 
            this.LabelMale.AutoSize = true;
            this.LabelMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMale.Location = new System.Drawing.Point(61, 25);
            this.LabelMale.Name = "LabelMale";
            this.LabelMale.Size = new System.Drawing.Size(93, 32);
            this.LabelMale.TabIndex = 0;
            this.LabelMale.Text = "label1";
            // 
            // LabelFemale
            // 
            this.LabelFemale.AutoSize = true;
            this.LabelFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFemale.Location = new System.Drawing.Point(59, 25);
            this.LabelFemale.Name = "LabelFemale";
            this.LabelFemale.Size = new System.Drawing.Size(93, 32);
            this.LabelFemale.TabIndex = 0;
            this.LabelFemale.Text = "label1";
            // 
            // StaticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 278);
            this.Controls.Add(this.PanelTotal);
            this.Controls.Add(this.PanelFemale);
            this.Controls.Add(this.PanelMale);
            this.Name = "StaticForm";
            this.Text = "StaticForm";
            this.Load += new System.EventHandler(this.StaticForm_Load);
            this.PanelMale.ResumeLayout(false);
            this.PanelMale.PerformLayout();
            this.PanelFemale.ResumeLayout(false);
            this.PanelFemale.PerformLayout();
            this.PanelTotal.ResumeLayout(false);
            this.PanelTotal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMale;
        private System.Windows.Forms.Label LabelMale;
        private System.Windows.Forms.Panel PanelFemale;
        private System.Windows.Forms.Label LabelFemale;
        private System.Windows.Forms.Panel PanelTotal;
        private System.Windows.Forms.Label LabelTotal;
    }
}