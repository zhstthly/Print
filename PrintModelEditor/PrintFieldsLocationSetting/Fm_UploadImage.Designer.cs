namespace PrintFieldsLocationSetting
{
    partial class Fm_UploadImage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_UploadSaleCompanyImage = new System.Windows.Forms.Button();
            this.btn_DeleteSign = new System.Windows.Forms.Button();
            this.cb_GroupName = new System.Windows.Forms.ComboBox();
            this.cb_Sign = new System.Windows.Forms.ComboBox();
            this.btn_AddSign = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_DeleteGroupName = new System.Windows.Forms.Button();
            this.btn_AddNewGroup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_PictureGroup = new System.Windows.Forms.DataGridView();
            this._id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._groupID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this._locationID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this._pictureName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PictureGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_UploadSaleCompanyImage);
            this.panel1.Controls.Add(this.btn_DeleteSign);
            this.panel1.Controls.Add(this.cb_GroupName);
            this.panel1.Controls.Add(this.cb_Sign);
            this.panel1.Controls.Add(this.btn_AddSign);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_DeleteGroupName);
            this.panel1.Controls.Add(this.btn_AddNewGroup);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 31);
            this.panel1.TabIndex = 0;
            // 
            // btn_UploadSaleCompanyImage
            // 
            this.btn_UploadSaleCompanyImage.Location = new System.Drawing.Point(609, 5);
            this.btn_UploadSaleCompanyImage.Name = "btn_UploadSaleCompanyImage";
            this.btn_UploadSaleCompanyImage.Size = new System.Drawing.Size(90, 23);
            this.btn_UploadSaleCompanyImage.TabIndex = 11;
            this.btn_UploadSaleCompanyImage.Text = "销售公司图片";
            this.btn_UploadSaleCompanyImage.UseVisualStyleBackColor = true;
            this.btn_UploadSaleCompanyImage.Click += new System.EventHandler(this.btn_UploadSaleCompanyImage_Click);
            // 
            // btn_DeleteSign
            // 
            this.btn_DeleteSign.Location = new System.Drawing.Point(193, 4);
            this.btn_DeleteSign.Name = "btn_DeleteSign";
            this.btn_DeleteSign.Size = new System.Drawing.Size(46, 23);
            this.btn_DeleteSign.TabIndex = 10;
            this.btn_DeleteSign.Text = "删除";
            this.btn_DeleteSign.UseVisualStyleBackColor = true;
            this.btn_DeleteSign.Click += new System.EventHandler(this.btn_DeleteSign_Click);
            // 
            // cb_GroupName
            // 
            this.cb_GroupName.FormattingEnabled = true;
            this.cb_GroupName.Location = new System.Drawing.Point(288, 6);
            this.cb_GroupName.Name = "cb_GroupName";
            this.cb_GroupName.Size = new System.Drawing.Size(168, 20);
            this.cb_GroupName.TabIndex = 9;
            this.cb_GroupName.SelectedIndexChanged += new System.EventHandler(this.cb_GroupName_SelectedIndexChanged);
            // 
            // cb_Sign
            // 
            this.cb_Sign.FormattingEnabled = true;
            this.cb_Sign.Location = new System.Drawing.Point(46, 6);
            this.cb_Sign.Name = "cb_Sign";
            this.cb_Sign.Size = new System.Drawing.Size(87, 20);
            this.cb_Sign.TabIndex = 8;
            // 
            // btn_AddSign
            // 
            this.btn_AddSign.Location = new System.Drawing.Point(139, 4);
            this.btn_AddSign.Name = "btn_AddSign";
            this.btn_AddSign.Size = new System.Drawing.Size(51, 23);
            this.btn_AddSign.TabIndex = 7;
            this.btn_AddSign.Text = "添加";
            this.btn_AddSign.UseVisualStyleBackColor = true;
            this.btn_AddSign.Click += new System.EventHandler(this.btn_AddSign_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "方位";
            // 
            // btn_DeleteGroupName
            // 
            this.btn_DeleteGroupName.Location = new System.Drawing.Point(514, 4);
            this.btn_DeleteGroupName.Name = "btn_DeleteGroupName";
            this.btn_DeleteGroupName.Size = new System.Drawing.Size(49, 23);
            this.btn_DeleteGroupName.TabIndex = 3;
            this.btn_DeleteGroupName.Text = "删除";
            this.btn_DeleteGroupName.UseVisualStyleBackColor = true;
            this.btn_DeleteGroupName.Click += new System.EventHandler(this.btn_DeleteGroupName_Click);
            // 
            // btn_AddNewGroup
            // 
            this.btn_AddNewGroup.Location = new System.Drawing.Point(462, 4);
            this.btn_AddNewGroup.Name = "btn_AddNewGroup";
            this.btn_AddNewGroup.Size = new System.Drawing.Size(46, 23);
            this.btn_AddNewGroup.TabIndex = 2;
            this.btn_AddNewGroup.Text = "添加";
            this.btn_AddNewGroup.UseVisualStyleBackColor = true;
            this.btn_AddNewGroup.Click += new System.EventHandler(this.btn_AddNewGroup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(247, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "组名";
            // 
            // dgv_PictureGroup
            // 
            this.dgv_PictureGroup.AllowUserToAddRows = false;
            this.dgv_PictureGroup.AllowUserToDeleteRows = false;
            this.dgv_PictureGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PictureGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._id,
            this._groupID,
            this._locationID,
            this._pictureName,
            this._description});
            this.dgv_PictureGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_PictureGroup.Location = new System.Drawing.Point(0, 31);
            this.dgv_PictureGroup.Name = "dgv_PictureGroup";
            this.dgv_PictureGroup.RowHeadersVisible = false;
            this.dgv_PictureGroup.RowTemplate.Height = 23;
            this.dgv_PictureGroup.Size = new System.Drawing.Size(711, 466);
            this.dgv_PictureGroup.TabIndex = 1;
            this.dgv_PictureGroup.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_PictureGroup_CellDoubleClick);
            this.dgv_PictureGroup.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgv_PictureGroup_PreviewKeyDown);
            // 
            // _id
            // 
            this._id.DataPropertyName = "ID";
            this._id.HeaderText = "ID";
            this._id.Name = "_id";
            this._id.ReadOnly = true;
            this._id.Visible = false;
            // 
            // _groupID
            // 
            this._groupID.DataPropertyName = "GroupID";
            this._groupID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this._groupID.HeaderText = "组名";
            this._groupID.Name = "_groupID";
            this._groupID.ReadOnly = true;
            this._groupID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._groupID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._groupID.Width = 150;
            // 
            // _locationID
            // 
            this._locationID.DataPropertyName = "LocationID";
            this._locationID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this._locationID.HeaderText = "方位";
            this._locationID.Name = "_locationID";
            this._locationID.ReadOnly = true;
            this._locationID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._locationID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _pictureName
            // 
            this._pictureName.DataPropertyName = "PictureName";
            this._pictureName.HeaderText = "图片名";
            this._pictureName.Name = "_pictureName";
            this._pictureName.ReadOnly = true;
            this._pictureName.Width = 200;
            // 
            // _description
            // 
            this._description.DataPropertyName = "Description";
            this._description.HeaderText = "说明";
            this._description.Name = "_description";
            this._description.Width = 250;
            // 
            // Fm_UploadImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 497);
            this.Controls.Add(this.dgv_PictureGroup);
            this.Controls.Add(this.panel1);
            this.Name = "Fm_UploadImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "快递图片上传";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Fm_UploadImage_FormClosing);
            this.Load += new System.EventHandler(this.Fm_UploadImage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PictureGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_DeleteSign;
        private System.Windows.Forms.ComboBox cb_GroupName;
        private System.Windows.Forms.ComboBox cb_Sign;
        private System.Windows.Forms.Button btn_AddSign;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_DeleteGroupName;
        private System.Windows.Forms.Button btn_AddNewGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_PictureGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn _id;
        private System.Windows.Forms.DataGridViewComboBoxColumn _groupID;
        private System.Windows.Forms.DataGridViewComboBoxColumn _locationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _pictureName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _description;
        private System.Windows.Forms.Button btn_UploadSaleCompanyImage;
    }
}