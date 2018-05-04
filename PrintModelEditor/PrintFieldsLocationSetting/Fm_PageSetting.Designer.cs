namespace PrintFieldsLocationSetting
{
    partial class Fm_PageSetting
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nud_Padding = new System.Windows.Forms.NumericUpDown();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.nud_PageWidth = new System.Windows.Forms.NumericUpDown();
            this.nud_PageHeight = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_PageName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Padding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PageWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PageHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "纸张大小";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(124, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "×";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(201, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "mm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "页边距";
            // 
            // nud_Padding
            // 
            this.nud_Padding.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_Padding.Location = new System.Drawing.Point(72, 66);
            this.nud_Padding.Name = "nud_Padding";
            this.nud_Padding.Size = new System.Drawing.Size(47, 23);
            this.nud_Padding.TabIndex = 6;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_Save.Location = new System.Drawing.Point(156, 102);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_Delete.Location = new System.Drawing.Point(15, 102);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete.TabIndex = 8;
            this.btn_Delete.Text = "删除";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // nud_PageWidth
            // 
            this.nud_PageWidth.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_PageWidth.Location = new System.Drawing.Point(72, 36);
            this.nud_PageWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_PageWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_PageWidth.Name = "nud_PageWidth";
            this.nud_PageWidth.Size = new System.Drawing.Size(47, 23);
            this.nud_PageWidth.TabIndex = 9;
            this.nud_PageWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_PageHeight
            // 
            this.nud_PageHeight.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_PageHeight.Location = new System.Drawing.Point(147, 36);
            this.nud_PageHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_PageHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_PageHeight.Name = "nud_PageHeight";
            this.nud_PageHeight.Size = new System.Drawing.Size(47, 23);
            this.nud_PageHeight.TabIndex = 10;
            this.nud_PageHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "纸张名称";
            // 
            // tb_PageName
            // 
            this.tb_PageName.Location = new System.Drawing.Point(72, 9);
            this.tb_PageName.Name = "tb_PageName";
            this.tb_PageName.Size = new System.Drawing.Size(159, 21);
            this.tb_PageName.TabIndex = 1;
            // 
            // Fm_PageSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 133);
            this.Controls.Add(this.tb_PageName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nud_PageHeight);
            this.Controls.Add(this.nud_PageWidth);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.nud_Padding);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Fm_PageSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "页面设置";
            ((System.ComponentModel.ISupportInitialize)(this.nud_Padding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PageWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PageHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nud_Padding;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.NumericUpDown nud_PageWidth;
        private System.Windows.Forms.NumericUpDown nud_PageHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_PageName;
    }
}