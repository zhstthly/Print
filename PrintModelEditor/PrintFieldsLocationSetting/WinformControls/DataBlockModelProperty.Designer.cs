namespace PrintFieldsLocationSetting.WinformControls
{
    partial class DataBlockModelProperty
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_DataModelProperty = new System.Windows.Forms.DataGridView();
            this._property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cb_DataName = new System.Windows.Forms.ComboBox();
            this.tb_ColumnName = new System.Windows.Forms.TextBox();
            this.tb_Width = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataModelProperty)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_DataModelProperty
            // 
            this.dgv_DataModelProperty.AllowUserToAddRows = false;
            this.dgv_DataModelProperty.AllowUserToDeleteRows = false;
            this.dgv_DataModelProperty.AllowUserToResizeColumns = false;
            this.dgv_DataModelProperty.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DataModelProperty.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_DataModelProperty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DataModelProperty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._property,
            this._value});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DataModelProperty.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_DataModelProperty.Location = new System.Drawing.Point(0, 0);
            this.dgv_DataModelProperty.Name = "dgv_DataModelProperty";
            this.dgv_DataModelProperty.RowHeadersVisible = false;
            this.dgv_DataModelProperty.RowTemplate.Height = 23;
            this.dgv_DataModelProperty.Size = new System.Drawing.Size(144, 96);
            this.dgv_DataModelProperty.TabIndex = 1;
            this.dgv_DataModelProperty.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DataModelProperty_CellDoubleClick);
            // 
            // _property
            // 
            this._property.DataPropertyName = "property";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this._property.DefaultCellStyle = dataGridViewCellStyle2;
            this._property.HeaderText = "属性";
            this._property.Name = "_property";
            this._property.ReadOnly = true;
            this._property.Width = 60;
            // 
            // _value
            // 
            this._value.DataPropertyName = "value";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this._value.DefaultCellStyle = dataGridViewCellStyle3;
            this._value.HeaderText = "值";
            this._value.Name = "_value";
            this._value.ReadOnly = true;
            this._value.Width = 80;
            // 
            // cb_DataName
            // 
            this.cb_DataName.DisplayMember = "display";
            this.cb_DataName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_DataName.Font = new System.Drawing.Font("微软雅黑", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_DataName.FormattingEnabled = true;
            this.cb_DataName.Location = new System.Drawing.Point(61, 71);
            this.cb_DataName.Name = "cb_DataName";
            this.cb_DataName.Size = new System.Drawing.Size(80, 24);
            this.cb_DataName.TabIndex = 10;
            this.cb_DataName.ValueMember = "value";
            this.cb_DataName.Visible = false;
            this.cb_DataName.SelectedIndexChanged += new System.EventHandler(this.cb_DataName_SelectedIndexChanged);
            this.cb_DataName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriggerValidated);
            this.cb_DataName.Validated += new System.EventHandler(this.ValueValidated);
            // 
            // tb_ColumnName
            // 
            this.tb_ColumnName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_ColumnName.Location = new System.Drawing.Point(61, 49);
            this.tb_ColumnName.Name = "tb_ColumnName";
            this.tb_ColumnName.Size = new System.Drawing.Size(80, 23);
            this.tb_ColumnName.TabIndex = 9;
            this.tb_ColumnName.Visible = false;
            this.tb_ColumnName.TextChanged += new System.EventHandler(this.tb_ColumnName_TextChanged);
            this.tb_ColumnName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriggerValidated);
            this.tb_ColumnName.Validated += new System.EventHandler(this.ValueValidated);
            // 
            // tb_Width
            // 
            this.tb_Width.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Width.Location = new System.Drawing.Point(61, 26);
            this.tb_Width.Name = "tb_Width";
            this.tb_Width.Size = new System.Drawing.Size(80, 23);
            this.tb_Width.TabIndex = 8;
            this.tb_Width.Text = "0";
            this.tb_Width.Visible = false;
            this.tb_Width.TextChanged += new System.EventHandler(this.tb_Width_TextChanged);
            this.tb_Width.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriggerValidated);
            this.tb_Width.Validated += new System.EventHandler(this.ValueValidated);
            // 
            // DataModelProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cb_DataName);
            this.Controls.Add(this.tb_ColumnName);
            this.Controls.Add(this.tb_Width);
            this.Controls.Add(this.dgv_DataModelProperty);
            this.Name = "DataModelProperty";
            this.Size = new System.Drawing.Size(144, 96);
            this.Load += new System.EventHandler(this.DataModelProperty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataModelProperty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_DataModelProperty;
        private System.Windows.Forms.DataGridViewTextBoxColumn _property;
        private System.Windows.Forms.DataGridViewTextBoxColumn _value;
        private System.Windows.Forms.ComboBox cb_DataName;
        private System.Windows.Forms.TextBox tb_ColumnName;
        private System.Windows.Forms.TextBox tb_Width;
    }
}
