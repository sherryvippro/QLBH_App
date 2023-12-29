namespace QLBH_App
{
    partial class FormHSD
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboHSD = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvHSD = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHSD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hạn sử dụng còn lại:";
            // 
            // cboHSD
            // 
            this.cboHSD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboHSD.FormattingEnabled = true;
            this.cboHSD.Location = new System.Drawing.Point(266, 39);
            this.cboHSD.Name = "cboHSD";
            this.cboHSD.Size = new System.Drawing.Size(189, 33);
            this.cboHSD.TabIndex = 1;
            this.cboHSD.SelectedValueChanged += new System.EventHandler(this.cboHSD_SelectedValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboHSD);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1097, 100);
            this.panel1.TabIndex = 2;
            // 
            // dgvHSD
            // 
            this.dgvHSD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHSD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHSD.Location = new System.Drawing.Point(0, 100);
            this.dgvHSD.Name = "dgvHSD";
            this.dgvHSD.RowHeadersWidth = 62;
            this.dgvHSD.RowTemplate.Height = 28;
            this.dgvHSD.Size = new System.Drawing.Size(1097, 629);
            this.dgvHSD.TabIndex = 3;
            // 
            // FormHSD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 729);
            this.Controls.Add(this.dgvHSD);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormHSD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormHSD";
            this.Load += new System.EventHandler(this.FormHSD_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHSD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboHSD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvHSD;
    }
}