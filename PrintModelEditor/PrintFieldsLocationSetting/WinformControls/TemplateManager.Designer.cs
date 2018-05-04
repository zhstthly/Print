namespace PrintFieldsLocationSetting
{
    partial class DataManager
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_Fields = new System.Windows.Forms.DataGridView();
            this._fieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._bindingText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._modelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._fieldID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._fontFamilyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._fontSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._locationX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._locationY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._fieldType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._printType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._textAreaWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._textAreaHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._bold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._italic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Fields)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Fields
            // 
            this.dgv_Fields.AllowUserToAddRows = false;
            this.dgv_Fields.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgv_Fields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Fields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._fieldName,
            this._bindingText,
            this._enable,
            this._modelID,
            this._fieldID,
            this._fontFamilyName,
            this._fontSize,
            this._locationX,
            this._locationY,
            this._fieldType,
            this._printType,
            this._textAreaWidth,
            this._textAreaHeight,
            this._bold,
            this._italic});
            this.dgv_Fields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Fields.Location = new System.Drawing.Point(0, 0);
            this.dgv_Fields.MultiSelect = false;
            this.dgv_Fields.Name = "dgv_Fields";
            this.dgv_Fields.RowHeadersWidth = 15;
            this.dgv_Fields.RowTemplate.Height = 23;
            this.dgv_Fields.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Fields.Size = new System.Drawing.Size(268, 456);
            this.dgv_Fields.TabIndex = 2;
            this.dgv_Fields.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Fields_CellContentClick);
            this.dgv_Fields.SelectionChanged += new System.EventHandler(this.dgv_Fields_SelectionChanged);
            this.dgv_Fields.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgv_Fields_UserDeletingRow);
            // 
            // _fieldName
            // 
            this._fieldName.DataPropertyName = "FieldName";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this._fieldName.DefaultCellStyle = dataGridViewCellStyle1;
            this._fieldName.HeaderText = "字段名";
            this._fieldName.Name = "_fieldName";
            this._fieldName.ReadOnly = true;
            this._fieldName.Width = 80;
            // 
            // _bindingText
            // 
            this._bindingText.DataPropertyName = "BindingText";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this._bindingText.DefaultCellStyle = dataGridViewCellStyle2;
            this._bindingText.HeaderText = "绑定文本";
            this._bindingText.Name = "_bindingText";
            this._bindingText.ReadOnly = true;
            // 
            // _enable
            // 
            this._enable.DataPropertyName = "Enable";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this._enable.DefaultCellStyle = dataGridViewCellStyle3;
            this._enable.FalseValue = "false";
            this._enable.HeaderText = "有效性";
            this._enable.Name = "_enable";
            this._enable.TrueValue = "true";
            this._enable.Width = 50;
            // 
            // _modelID
            // 
            this._modelID.DataPropertyName = "ModelID";
            this._modelID.HeaderText = "ModelID";
            this._modelID.Name = "_modelID";
            this._modelID.ReadOnly = true;
            this._modelID.Visible = false;
            // 
            // _fieldID
            // 
            this._fieldID.DataPropertyName = "FieldID";
            this._fieldID.HeaderText = "FieldID";
            this._fieldID.Name = "_fieldID";
            this._fieldID.ReadOnly = true;
            this._fieldID.Visible = false;
            // 
            // _fontFamilyName
            // 
            this._fontFamilyName.DataPropertyName = "FontFamilyName";
            this._fontFamilyName.HeaderText = "FontFamilyName";
            this._fontFamilyName.Name = "_fontFamilyName";
            this._fontFamilyName.ReadOnly = true;
            this._fontFamilyName.Visible = false;
            // 
            // _fontSize
            // 
            this._fontSize.DataPropertyName = "FontSize";
            this._fontSize.HeaderText = "FontSize";
            this._fontSize.Name = "_fontSize";
            this._fontSize.ReadOnly = true;
            this._fontSize.Visible = false;
            // 
            // _locationX
            // 
            this._locationX.DataPropertyName = "LocationX";
            this._locationX.HeaderText = "LocationX";
            this._locationX.Name = "_locationX";
            this._locationX.ReadOnly = true;
            this._locationX.Visible = false;
            // 
            // _locationY
            // 
            this._locationY.DataPropertyName = "LocationY";
            this._locationY.HeaderText = "LocationY";
            this._locationY.Name = "_locationY";
            this._locationY.ReadOnly = true;
            this._locationY.Visible = false;
            // 
            // _fieldType
            // 
            this._fieldType.DataPropertyName = "FieldType";
            this._fieldType.HeaderText = "FieldType";
            this._fieldType.Name = "_fieldType";
            this._fieldType.ReadOnly = true;
            this._fieldType.Visible = false;
            // 
            // _printType
            // 
            this._printType.DataPropertyName = "PrintType";
            this._printType.HeaderText = "PrintType";
            this._printType.Name = "_printType";
            this._printType.ReadOnly = true;
            this._printType.Visible = false;
            // 
            // _textAreaWidth
            // 
            this._textAreaWidth.DataPropertyName = "TextAreaWidth";
            this._textAreaWidth.HeaderText = "TextAreaWidth";
            this._textAreaWidth.Name = "_textAreaWidth";
            this._textAreaWidth.ReadOnly = true;
            this._textAreaWidth.Visible = false;
            // 
            // _textAreaHeight
            // 
            this._textAreaHeight.DataPropertyName = "TextAreaHeight";
            this._textAreaHeight.HeaderText = "TextAreaHeight";
            this._textAreaHeight.Name = "_textAreaHeight";
            this._textAreaHeight.ReadOnly = true;
            this._textAreaHeight.Visible = false;
            // 
            // _bold
            // 
            this._bold.DataPropertyName = "Bold";
            this._bold.HeaderText = "Bold";
            this._bold.Name = "_bold";
            this._bold.ReadOnly = true;
            this._bold.Visible = false;
            // 
            // _italic
            // 
            this._italic.DataPropertyName = "Italic";
            this._italic.HeaderText = "Italic";
            this._italic.Name = "_italic";
            this._italic.ReadOnly = true;
            this._italic.Visible = false;
            // 
            // DataManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_Fields);
            this.Name = "DataManager";
            this.Size = new System.Drawing.Size(268, 456);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Fields)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Fields;
        private System.Windows.Forms.DataGridViewTextBoxColumn _fieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _bindingText;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _enable;
        private System.Windows.Forms.DataGridViewTextBoxColumn _modelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _fieldID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _fontFamilyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _fontSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn _locationX;
        private System.Windows.Forms.DataGridViewTextBoxColumn _locationY;
        private System.Windows.Forms.DataGridViewTextBoxColumn _fieldType;
        private System.Windows.Forms.DataGridViewTextBoxColumn _printType;
        private System.Windows.Forms.DataGridViewTextBoxColumn _textAreaWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn _textAreaHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn _bold;
        private System.Windows.Forms.DataGridViewTextBoxColumn _italic;
    }
}
