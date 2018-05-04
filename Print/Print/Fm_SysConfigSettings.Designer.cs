namespace Print
{
    partial class Fm_SysConfigSettings
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
            this.tab_SystemSet = new System.Windows.Forms.TabControl();
            this.Express = new System.Windows.Forms.TabPage();
            this.bt_quit = new System.Windows.Forms.Button();
            this.bt_OK = new System.Windows.Forms.Button();
            this.dgv_Express = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this._selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._autoPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._expressCompanyID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this._expressPrintModel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this._orderPrinter = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this._expressPrinter = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this._pictureGroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tab_SystemSet.SuspendLayout();
            this.Express.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Express)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_SystemSet
            // 
            this.tab_SystemSet.Controls.Add(this.Express);
            this.tab_SystemSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_SystemSet.Location = new System.Drawing.Point(0, 0);
            this.tab_SystemSet.Name = "tab_SystemSet";
            this.tab_SystemSet.SelectedIndex = 0;
            this.tab_SystemSet.Size = new System.Drawing.Size(839, 560);
            this.tab_SystemSet.TabIndex = 0;
            this.tab_SystemSet.SelectedIndexChanged += new System.EventHandler(this.tab_SystemSet_SelectedIndexChanged);
            // 
            // Express
            // 
            this.Express.Controls.Add(this.dgv_Express);
            this.Express.Controls.Add(this.panel2);
            this.Express.Location = new System.Drawing.Point(4, 22);
            this.Express.Name = "Express";
            this.Express.Padding = new System.Windows.Forms.Padding(3);
            this.Express.Size = new System.Drawing.Size(831, 534);
            this.Express.TabIndex = 1;
            this.Express.Text = "快递打印设置";
            this.Express.UseVisualStyleBackColor = true;
            // 
            // bt_quit
            // 
            this.bt_quit.Location = new System.Drawing.Point(484, 3);
            this.bt_quit.Name = "bt_quit";
            this.bt_quit.Size = new System.Drawing.Size(75, 23);
            this.bt_quit.TabIndex = 49;
            this.bt_quit.Text = "退 出";
            this.bt_quit.UseVisualStyleBackColor = true;
            this.bt_quit.Click += new System.EventHandler(this.bt_quit_Click);
            // 
            // bt_OK
            // 
            this.bt_OK.Location = new System.Drawing.Point(253, 3);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(75, 23);
            this.bt_OK.TabIndex = 48;
            this.bt_OK.Text = "确 定";
            this.bt_OK.UseVisualStyleBackColor = true;
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
            // 
            // dgv_Express
            // 
            this.dgv_Express.AllowUserToAddRows = false;
            this.dgv_Express.AllowUserToDeleteRows = false;
            this.dgv_Express.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Express.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._selected,
            this._autoPrint,
            this._expressCompanyID,
            this._expressPrintModel,
            this._orderPrinter,
            this._expressPrinter,
            this._pictureGroup});
            this.dgv_Express.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Express.Location = new System.Drawing.Point(3, 3);
            this.dgv_Express.Name = "dgv_Express";
            this.dgv_Express.RowHeadersVisible = false;
            this.dgv_Express.RowTemplate.Height = 23;
            this.dgv_Express.Size = new System.Drawing.Size(825, 498);
            this.dgv_Express.TabIndex = 47;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bt_OK);
            this.panel2.Controls.Add(this.bt_quit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 501);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(825, 30);
            this.panel2.TabIndex = 50;
            // 
            // _selected
            // 
            this._selected.DataPropertyName = "Selected";
            this._selected.FalseValue = "false";
            this._selected.HeaderText = "选择";
            this._selected.Name = "_selected";
            this._selected.TrueValue = "true";
            this._selected.Width = 40;
            // 
            // _autoPrint
            // 
            this._autoPrint.DataPropertyName = "AutoPrint";
            this._autoPrint.FalseValue = "false";
            this._autoPrint.HeaderText = "自动打印";
            this._autoPrint.Name = "_autoPrint";
            this._autoPrint.TrueValue = "true";
            this._autoPrint.Width = 60;
            // 
            // _expressCompanyID
            // 
            this._expressCompanyID.DataPropertyName = "ExpressCompanyID";
            this._expressCompanyID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this._expressCompanyID.HeaderText = "快递公司";
            this._expressCompanyID.Name = "_expressCompanyID";
            this._expressCompanyID.ReadOnly = true;
            this._expressCompanyID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._expressCompanyID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._expressCompanyID.Width = 150;
            // 
            // _expressPrintModel
            // 
            this._expressPrintModel.DataPropertyName = "ExpressPrintModel";
            this._expressPrintModel.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this._expressPrintModel.HeaderText = "快递模板";
            this._expressPrintModel.Name = "_expressPrintModel";
            this._expressPrintModel.Width = 150;
            // 
            // _orderPrinter
            // 
            this._orderPrinter.DataPropertyName = "OrderPrinter";
            this._orderPrinter.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this._orderPrinter.HeaderText = "打印机（发货单）";
            this._orderPrinter.Name = "_orderPrinter";
            this._orderPrinter.Width = 150;
            // 
            // _expressPrinter
            // 
            this._expressPrinter.DataPropertyName = "ExpressPrinter";
            this._expressPrinter.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this._expressPrinter.HeaderText = "打印机（快递单）";
            this._expressPrinter.Name = "_expressPrinter";
            this._expressPrinter.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._expressPrinter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._expressPrinter.Width = 150;
            // 
            // _pictureGroup
            // 
            this._pictureGroup.DataPropertyName = "PictureGroup";
            this._pictureGroup.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this._pictureGroup.HeaderText = "图片组";
            this._pictureGroup.Name = "_pictureGroup";
            // 
            // Fm_SysConfigSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 560);
            this.Controls.Add(this.tab_SystemSet);
            this.Name = "Fm_SysConfigSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打印设置";
            this.Load += new System.EventHandler(this.Fm_SysConfigSettings_Load);
            this.tab_SystemSet.ResumeLayout(false);
            this.Express.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Express)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_SystemSet;
        private System.Windows.Forms.TabPage Express;
        private System.Windows.Forms.Button bt_quit;
        private System.Windows.Forms.Button bt_OK;
        private System.Windows.Forms.DataGridView dgv_Express;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _selected;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _autoPrint;
        private System.Windows.Forms.DataGridViewComboBoxColumn _expressCompanyID;
        private System.Windows.Forms.DataGridViewComboBoxColumn _expressPrintModel;
        private System.Windows.Forms.DataGridViewComboBoxColumn _orderPrinter;
        private System.Windows.Forms.DataGridViewComboBoxColumn _expressPrinter;
        private System.Windows.Forms.DataGridViewComboBoxColumn _pictureGroup;
    }
}