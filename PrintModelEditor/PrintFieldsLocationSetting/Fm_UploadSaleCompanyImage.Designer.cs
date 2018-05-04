namespace PrintFieldsLocationSetting
{
    partial class Fm_UploadSaleCompanyImage
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
            this.dgv_SaleCompanyImage = new System.Windows.Forms.DataGridView();
            this._saleCompanyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._saleCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._saleCompanyImage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SaleCompanyImage)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_SaleCompanyImage
            // 
            this.dgv_SaleCompanyImage.AllowUserToAddRows = false;
            this.dgv_SaleCompanyImage.AllowUserToDeleteRows = false;
            this.dgv_SaleCompanyImage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SaleCompanyImage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._saleCompanyID,
            this._saleCompanyName,
            this._saleCompanyImage});
            this.dgv_SaleCompanyImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_SaleCompanyImage.Location = new System.Drawing.Point(0, 0);
            this.dgv_SaleCompanyImage.Name = "dgv_SaleCompanyImage";
            this.dgv_SaleCompanyImage.RowHeadersWidth = 20;
            this.dgv_SaleCompanyImage.RowTemplate.Height = 23;
            this.dgv_SaleCompanyImage.Size = new System.Drawing.Size(443, 341);
            this.dgv_SaleCompanyImage.TabIndex = 0;
            this.dgv_SaleCompanyImage.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_SaleCompanyImage_CellDoubleClick);
            this.dgv_SaleCompanyImage.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgv_SaleCompanyImage_PreviewKeyDown);
            // 
            // _saleCompanyID
            // 
            this._saleCompanyID.DataPropertyName = "SaleCompanyID";
            this._saleCompanyID.HeaderText = "SaleCompanyID";
            this._saleCompanyID.Name = "_saleCompanyID";
            this._saleCompanyID.ReadOnly = true;
            this._saleCompanyID.Visible = false;
            // 
            // _saleCompanyName
            // 
            this._saleCompanyName.DataPropertyName = "SaleCompanyName";
            this._saleCompanyName.HeaderText = "销售平台";
            this._saleCompanyName.Name = "_saleCompanyName";
            this._saleCompanyName.ReadOnly = true;
            this._saleCompanyName.Width = 150;
            // 
            // _saleCompanyImage
            // 
            this._saleCompanyImage.DataPropertyName = "SaleCompanyImage";
            this._saleCompanyImage.HeaderText = "图片名";
            this._saleCompanyImage.Name = "_saleCompanyImage";
            this._saleCompanyImage.ReadOnly = true;
            this._saleCompanyImage.Width = 250;
            // 
            // Fm_UploadSaleCompanyImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 341);
            this.Controls.Add(this.dgv_SaleCompanyImage);
            this.Name = "Fm_UploadSaleCompanyImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "销售平台打印图片上传";
            this.Load += new System.EventHandler(this.Fm_UploadSaleCompanyImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SaleCompanyImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_SaleCompanyImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn _saleCompanyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _saleCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _saleCompanyImage;
    }
}