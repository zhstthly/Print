namespace Print
{
    partial class Fm_ManualPrint
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
            this.cmb_TmplLst = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_ExpPrinter = new System.Windows.Forms.ComboBox();
            this.bt_PrintExpress = new System.Windows.Forms.Button();
            this.bt_Quit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_OrdPrinter = new System.Windows.Forms.ComboBox();
            this.bt_Print = new System.Windows.Forms.Button();
            this.dgv_Order = new System.Windows.Forms.DataGridView();
            this.bt_Search = new System.Windows.Forms.Button();
            this.tb_KeyWord = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Order)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 62;
            this.label1.Text = "出货单号：";
            // 
            // cmb_TmplLst
            // 
            this.cmb_TmplLst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TmplLst.FormattingEnabled = true;
            this.cmb_TmplLst.Location = new System.Drawing.Point(809, 371);
            this.cmb_TmplLst.Name = "cmb_TmplLst";
            this.cmb_TmplLst.Size = new System.Drawing.Size(213, 20);
            this.cmb_TmplLst.TabIndex = 61;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(738, 374);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 60;
            this.label6.Text = "快递单模版";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(421, 377);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 59;
            this.label5.Text = "快递单打印机";
            // 
            // cmb_ExpPrinter
            // 
            this.cmb_ExpPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ExpPrinter.FormattingEnabled = true;
            this.cmb_ExpPrinter.Location = new System.Drawing.Point(516, 374);
            this.cmb_ExpPrinter.Name = "cmb_ExpPrinter";
            this.cmb_ExpPrinter.Size = new System.Drawing.Size(199, 20);
            this.cmb_ExpPrinter.TabIndex = 58;
            // 
            // bt_PrintExpress
            // 
            this.bt_PrintExpress.Location = new System.Drawing.Point(621, 400);
            this.bt_PrintExpress.Name = "bt_PrintExpress";
            this.bt_PrintExpress.Size = new System.Drawing.Size(94, 28);
            this.bt_PrintExpress.TabIndex = 56;
            this.bt_PrintExpress.Text = "打印快递单";
            this.bt_PrintExpress.UseVisualStyleBackColor = true;
            this.bt_PrintExpress.Click += new System.EventHandler(this.bt_PrintExpress_Click);
            // 
            // bt_Quit
            // 
            this.bt_Quit.Location = new System.Drawing.Point(1058, 12);
            this.bt_Quit.Name = "bt_Quit";
            this.bt_Quit.Size = new System.Drawing.Size(81, 21);
            this.bt_Quit.TabIndex = 55;
            this.bt_Quit.Text = "退 出";
            this.bt_Quit.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 54;
            this.label4.Text = "订单打印机";
            // 
            // cmb_OrdPrinter
            // 
            this.cmb_OrdPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_OrdPrinter.FormattingEnabled = true;
            this.cmb_OrdPrinter.Location = new System.Drawing.Point(174, 374);
            this.cmb_OrdPrinter.Name = "cmb_OrdPrinter";
            this.cmb_OrdPrinter.Size = new System.Drawing.Size(199, 20);
            this.cmb_OrdPrinter.TabIndex = 53;
            // 
            // bt_Print
            // 
            this.bt_Print.Location = new System.Drawing.Point(279, 400);
            this.bt_Print.Name = "bt_Print";
            this.bt_Print.Size = new System.Drawing.Size(94, 28);
            this.bt_Print.TabIndex = 52;
            this.bt_Print.Text = "打印订单";
            this.bt_Print.UseVisualStyleBackColor = true;
            this.bt_Print.Click += new System.EventHandler(this.bt_Print_Click);
            // 
            // dgv_Order
            // 
            this.dgv_Order.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Order.Location = new System.Drawing.Point(12, 48);
            this.dgv_Order.Name = "dgv_Order";
            this.dgv_Order.RowHeadersVisible = false;
            this.dgv_Order.RowTemplate.Height = 23;
            this.dgv_Order.Size = new System.Drawing.Size(1128, 299);
            this.dgv_Order.TabIndex = 51;
            // 
            // bt_Search
            // 
            this.bt_Search.Location = new System.Drawing.Point(593, 6);
            this.bt_Search.Name = "bt_Search";
            this.bt_Search.Size = new System.Drawing.Size(73, 21);
            this.bt_Search.TabIndex = 50;
            this.bt_Search.Text = "搜 索";
            this.bt_Search.UseVisualStyleBackColor = true;
            this.bt_Search.Click += new System.EventHandler(this.bt_Search_Click);
            // 
            // tb_KeyWord
            // 
            this.tb_KeyWord.Location = new System.Drawing.Point(394, 7);
            this.tb_KeyWord.Name = "tb_KeyWord";
            this.tb_KeyWord.Size = new System.Drawing.Size(142, 21);
            this.tb_KeyWord.TabIndex = 49;
            // 
            // Fm_ManualPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 465);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_TmplLst);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmb_ExpPrinter);
            this.Controls.Add(this.bt_PrintExpress);
            this.Controls.Add(this.bt_Quit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmb_OrdPrinter);
            this.Controls.Add(this.bt_Print);
            this.Controls.Add(this.dgv_Order);
            this.Controls.Add(this.bt_Search);
            this.Controls.Add(this.tb_KeyWord);
            this.Name = "Fm_ManualPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手动打印";
            this.Load += new System.EventHandler(this.Fm_ManualPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Order)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_TmplLst;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_ExpPrinter;
        private System.Windows.Forms.Button bt_PrintExpress;
        private System.Windows.Forms.Button bt_Quit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_OrdPrinter;
        private System.Windows.Forms.Button bt_Print;
        private System.Windows.Forms.DataGridView dgv_Order;
        private System.Windows.Forms.Button bt_Search;
        private System.Windows.Forms.TextBox tb_KeyWord;
    }
}