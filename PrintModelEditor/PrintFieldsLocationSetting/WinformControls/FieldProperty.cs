using PrintFieldsLocationSetting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace PrintFieldsLocationSetting
{
    public class FieldProperty : UserControl
    {
        private ComboBox cb_FontFamily;
        private NumericUpDown nup_FontSize;
        private TextBox tb_X;
        private TextBox tb_Y;
        private DataGridViewTextBoxColumn _property;
        private DataGridViewTextBoxColumn _value;
        private ComboBox cb_FieldType;
        private ComboBox cb_PrintType;
        private TextBox tb_TextAreaWidth;
        private TextBox tb_TextAreaHeight;
        private CheckBox cb_Bold;
        private CheckBox cb_Italic;
        private System.Windows.Forms.DataGridView dgv_FieldProperty;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tb_Y = new System.Windows.Forms.TextBox();
            this.tb_X = new System.Windows.Forms.TextBox();
            this.nup_FontSize = new System.Windows.Forms.NumericUpDown();
            this.cb_FontFamily = new System.Windows.Forms.ComboBox();
            this.dgv_FieldProperty = new System.Windows.Forms.DataGridView();
            this._property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cb_FieldType = new System.Windows.Forms.ComboBox();
            this.cb_PrintType = new System.Windows.Forms.ComboBox();
            this.tb_TextAreaWidth = new System.Windows.Forms.TextBox();
            this.tb_TextAreaHeight = new System.Windows.Forms.TextBox();
            this.cb_Bold = new System.Windows.Forms.CheckBox();
            this.cb_Italic = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nup_FontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FieldProperty)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_Y
            // 
            this.tb_Y.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Y.Location = new System.Drawing.Point(62, 95);
            this.tb_Y.Name = "tb_Y";
            this.tb_Y.Size = new System.Drawing.Size(80, 23);
            this.tb_Y.TabIndex = 4;
            this.tb_Y.Text = "0";
            this.tb_Y.Visible = false;
            this.tb_Y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriggerValidated);
            this.tb_Y.Validated += new System.EventHandler(this.tb_Y_Validated);
            // 
            // tb_X
            // 
            this.tb_X.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_X.Location = new System.Drawing.Point(62, 72);
            this.tb_X.Name = "tb_X";
            this.tb_X.Size = new System.Drawing.Size(80, 23);
            this.tb_X.TabIndex = 3;
            this.tb_X.Text = "0";
            this.tb_X.Visible = false;
            this.tb_X.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriggerValidated);
            this.tb_X.Validated += new System.EventHandler(this.tb_X_Validated);
            // 
            // nup_FontSize
            // 
            this.nup_FontSize.DecimalPlaces = 1;
            this.nup_FontSize.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nup_FontSize.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nup_FontSize.Location = new System.Drawing.Point(62, 49);
            this.nup_FontSize.Name = "nup_FontSize";
            this.nup_FontSize.Size = new System.Drawing.Size(80, 23);
            this.nup_FontSize.TabIndex = 2;
            this.nup_FontSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nup_FontSize.Visible = false;
            this.nup_FontSize.ValueChanged += new System.EventHandler(this.nup_FontSize_ValueChanged);
            this.nup_FontSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriggerValidated);
            this.nup_FontSize.Validated += new System.EventHandler(this.nup_FontSize_Validated);
            // 
            // cb_FontFamily
            // 
            this.cb_FontFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FontFamily.Font = new System.Drawing.Font("微软雅黑", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_FontFamily.FormattingEnabled = true;
            this.cb_FontFamily.Location = new System.Drawing.Point(62, 25);
            this.cb_FontFamily.Name = "cb_FontFamily";
            this.cb_FontFamily.Size = new System.Drawing.Size(80, 24);
            this.cb_FontFamily.TabIndex = 1;
            this.cb_FontFamily.Visible = false;
            this.cb_FontFamily.SelectedIndexChanged += new System.EventHandler(this.cb_FontFamily_SelectedIndexChanged);
            this.cb_FontFamily.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriggerValidated);
            this.cb_FontFamily.Validated += new System.EventHandler(this.cb_FontFamily_Validated);
            // 
            // dgv_FieldProperty
            // 
            this.dgv_FieldProperty.AllowUserToAddRows = false;
            this.dgv_FieldProperty.AllowUserToDeleteRows = false;
            this.dgv_FieldProperty.AllowUserToResizeColumns = false;
            this.dgv_FieldProperty.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_FieldProperty.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_FieldProperty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_FieldProperty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._property,
            this._value});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_FieldProperty.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_FieldProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_FieldProperty.Location = new System.Drawing.Point(0, 0);
            this.dgv_FieldProperty.Name = "dgv_FieldProperty";
            this.dgv_FieldProperty.RowHeadersVisible = false;
            this.dgv_FieldProperty.RowTemplate.Height = 23;
            this.dgv_FieldProperty.Size = new System.Drawing.Size(144, 260);
            this.dgv_FieldProperty.TabIndex = 0;
            this.dgv_FieldProperty.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_FieldProperty_CellDoubleClick);
            // 
            // _property
            // 
            this._property.DataPropertyName = "property";
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this._property.DefaultCellStyle = dataGridViewCellStyle10;
            this._property.HeaderText = "属性";
            this._property.Name = "_property";
            this._property.ReadOnly = true;
            this._property.Width = 60;
            // 
            // _value
            // 
            this._value.DataPropertyName = "value";
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            this._value.DefaultCellStyle = dataGridViewCellStyle11;
            this._value.HeaderText = "值";
            this._value.Name = "_value";
            this._value.ReadOnly = true;
            this._value.Width = 80;
            // 
            // cb_FieldType
            // 
            this.cb_FieldType.DisplayMember = "display";
            this.cb_FieldType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FieldType.Font = new System.Drawing.Font("微软雅黑", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_FieldType.FormattingEnabled = true;
            this.cb_FieldType.Location = new System.Drawing.Point(62, 117);
            this.cb_FieldType.Name = "cb_FieldType";
            this.cb_FieldType.Size = new System.Drawing.Size(80, 24);
            this.cb_FieldType.TabIndex = 5;
            this.cb_FieldType.ValueMember = "value";
            this.cb_FieldType.Visible = false;
            this.cb_FieldType.SelectedIndexChanged += new System.EventHandler(this.cb_FieldType_SelectedIndexChanged);
            this.cb_FieldType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriggerValidated);
            this.cb_FieldType.Validated += new System.EventHandler(this.cb_FieldType_Validated);
            // 
            // cb_PrintType
            // 
            this.cb_PrintType.DisplayMember = "display";
            this.cb_PrintType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_PrintType.Font = new System.Drawing.Font("微软雅黑", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_PrintType.FormattingEnabled = true;
            this.cb_PrintType.Location = new System.Drawing.Point(62, 141);
            this.cb_PrintType.Name = "cb_PrintType";
            this.cb_PrintType.Size = new System.Drawing.Size(80, 24);
            this.cb_PrintType.TabIndex = 6;
            this.cb_PrintType.ValueMember = "value";
            this.cb_PrintType.Visible = false;
            this.cb_PrintType.SelectedIndexChanged += new System.EventHandler(this.cb_PrintType_SelectedIndexChanged);
            this.cb_PrintType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriggerValidated);
            this.cb_PrintType.Validated += new System.EventHandler(this.cb_PrintType_Validated);
            // 
            // tb_TextAreaWidth
            // 
            this.tb_TextAreaWidth.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_TextAreaWidth.Location = new System.Drawing.Point(62, 165);
            this.tb_TextAreaWidth.Name = "tb_TextAreaWidth";
            this.tb_TextAreaWidth.Size = new System.Drawing.Size(80, 23);
            this.tb_TextAreaWidth.TabIndex = 7;
            this.tb_TextAreaWidth.Text = "0";
            this.tb_TextAreaWidth.Visible = false;
            this.tb_TextAreaWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriggerValidated);
            this.tb_TextAreaWidth.Validated += new System.EventHandler(this.tb_TextAreaWidth_Validated);
            // 
            // tb_TextAreaHeight
            // 
            this.tb_TextAreaHeight.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_TextAreaHeight.Location = new System.Drawing.Point(62, 188);
            this.tb_TextAreaHeight.Name = "tb_TextAreaHeight";
            this.tb_TextAreaHeight.Size = new System.Drawing.Size(80, 23);
            this.tb_TextAreaHeight.TabIndex = 8;
            this.tb_TextAreaHeight.Text = "0";
            this.tb_TextAreaHeight.Visible = false;
            this.tb_TextAreaHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriggerValidated);
            this.tb_TextAreaHeight.Validated += new System.EventHandler(this.tb_TextAreaHeight_Validated);
            // 
            // cb_Bold
            // 
            this.cb_Bold.AutoSize = true;
            this.cb_Bold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cb_Bold.Location = new System.Drawing.Point(91, 217);
            this.cb_Bold.Name = "cb_Bold";
            this.cb_Bold.Size = new System.Drawing.Size(15, 14);
            this.cb_Bold.TabIndex = 9;
            this.cb_Bold.UseVisualStyleBackColor = false;
            this.cb_Bold.CheckedChanged += new System.EventHandler(this.cb_Bold_CheckedChanged);
            // 
            // cb_Italic
            // 
            this.cb_Italic.AutoSize = true;
            this.cb_Italic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cb_Italic.Location = new System.Drawing.Point(91, 238);
            this.cb_Italic.Name = "cb_Italic";
            this.cb_Italic.Size = new System.Drawing.Size(15, 14);
            this.cb_Italic.TabIndex = 10;
            this.cb_Italic.UseVisualStyleBackColor = false;
            this.cb_Italic.CheckedChanged += new System.EventHandler(this.cb_Italic_CheckedChanged);
            // 
            // FieldProperty
            // 
            this.Controls.Add(this.cb_Italic);
            this.Controls.Add(this.cb_Bold);
            this.Controls.Add(this.tb_TextAreaHeight);
            this.Controls.Add(this.tb_TextAreaWidth);
            this.Controls.Add(this.cb_PrintType);
            this.Controls.Add(this.cb_FieldType);
            this.Controls.Add(this.tb_Y);
            this.Controls.Add(this.tb_X);
            this.Controls.Add(this.nup_FontSize);
            this.Controls.Add(this.cb_FontFamily);
            this.Controls.Add(this.dgv_FieldProperty);
            this.Name = "FieldProperty";
            this.Size = new System.Drawing.Size(144, 260);
            ((System.ComponentModel.ISupportInitialize)(this.nup_FontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FieldProperty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        FieldModel currentFieldModel = new FieldModel();
        public FieldModel CurrentFieldModel
        {
            get { return currentFieldModel; }
            set
            {
                FontFamilyName = value.FontFamilyName;
                FontSize = value.FontSize;
                LocationX = value.LocationX;
                LocationY = value.LocationY;
                FieldType = value.FieldType;
                PrintType = value.PrintType;
                TextAreaWidth = value.TextAreaWidth;
                TextAreaHeight = value.TextAreaHeight;
                Bold = value.Bold;
                Italic = value.Italic;
            }
        }
        public bool Italic
        {
            set
            {
                cb_Italic.Checked = value;
                currentFieldModel.Italic = value;
                //通知选中项改变属性
                if (DrawingControlBase.Current != null)
                {
                    if (DrawingControlBase.Current.CurrentField.Italic != currentFieldModel.Italic)
                        DrawingControlBase.Current.Italic = currentFieldModel.Italic;
                }
                dgv_FieldProperty.Refresh();
            }
        }

        public bool Bold
        {
            set
            {
                cb_Bold.Checked = value;
                currentFieldModel.Bold = value;
                //通知选中项改变属性
                if (DrawingControlBase.Current != null)
                {
                    if (DrawingControlBase.Current.CurrentField.Bold != currentFieldModel.Bold)
                        DrawingControlBase.Current.Bold = currentFieldModel.Bold;
                }
                dgv_FieldProperty.Refresh();
            }
        }

        public FieldType FieldType
        {
            set
            {
                cb_FieldType.SelectedValue = value;
                bl_PV[4].Value = cb_FieldType.Text;
                currentFieldModel.FieldType = value;
                //通知选中项改变属性
                if (DrawingControlBase.Current != null)
                {
                    if (DrawingControlBase.Current.CurrentField.FieldType != currentFieldModel.FieldType)
                        DrawingControlBase.Current.FieldType = currentFieldModel.FieldType;
                }
                dgv_FieldProperty.Refresh();
            }
        }

        public PrintType PrintType
        {
            set
            {
                cb_PrintType.SelectedValue = value;
                bl_PV[5].Value = cb_PrintType.Text;
                currentFieldModel.PrintType = value;
                //通知选中项改变属性
                if (DrawingControlBase.Current != null)
                {
                    if (DrawingControlBase.Current.CurrentField.PrintType != currentFieldModel.PrintType)
                        DrawingControlBase.Current.PrintType = currentFieldModel.PrintType;
                }
                dgv_FieldProperty.Refresh();
            }
        }

        public string FontFamilyName
        {
            set
            {
                cb_FontFamily.Text = value;
                bl_PV[0].Value = value;
                currentFieldModel.FontFamilyName = value;
                //通知选中项改变属性
                if (DrawingControlBase.Current != null)
                {
                    if (DrawingControlBase.Current.CurrentField.FontFamilyName != currentFieldModel.FontFamilyName)
                        DrawingControlBase.Current.InitFontFamilyName = currentFieldModel.FontFamilyName;
                }
                dgv_FieldProperty.Refresh();
            }
        }

        public decimal FontSize
        {
            set
            {
                nup_FontSize.Value = value;
                bl_PV[1].Value = value.ToString();
                currentFieldModel.FontSize = value;
                //通知选中项改变属性
                if (DrawingControlBase.Current != null)
                {
                    if (DrawingControlBase.Current.CurrentField.FontSize != currentFieldModel.FontSize)
                        DrawingControlBase.Current.InitFontSize = (float)currentFieldModel.FontSize;
                }
                dgv_FieldProperty.Refresh();
            }
        }

        public int LocationX
        {
            set
            {
                tb_X.Text = value.ToString();
                bl_PV[2].Value = value.ToString();
                currentFieldModel.LocationX = value;
                //通知选中项改变属性
                if (DrawingControlBase.Current != null)
                {
                    if (DrawingControlBase.Current.CurrentField.LocationX != currentFieldModel.LocationX)
                        DrawingControlBase.Current.FixedLocationInPage = new Point(currentFieldModel.LocationX, currentFieldModel.LocationY);
                }
                dgv_FieldProperty.Refresh();
            }
        }

        public int LocationY
        {
            set
            {
                tb_Y.Text = value.ToString();
                bl_PV[3].Value = value.ToString();
                currentFieldModel.LocationY = value;
                //通知选中项改变属性
                if (DrawingControlBase.Current != null)
                {
                    if (DrawingControlBase.Current.CurrentField.LocationY != currentFieldModel.LocationY)
                        DrawingControlBase.Current.FixedLocationInPage = new Point(currentFieldModel.LocationX, currentFieldModel.LocationY);
                }
                dgv_FieldProperty.Refresh();
            }
        }

        public int TextAreaWidth
        {
            set
            {
                tb_TextAreaWidth.Text = value.ToString();
                bl_PV[6].Value = value.ToString();
                currentFieldModel.TextAreaWidth = value;
                //通知选中项改变属性
                if (DrawingControlBase.Current != null)
                {
                    if (DrawingControlBase.Current.CurrentField.TextAreaWidth != currentFieldModel.TextAreaWidth)
                        DrawingControlBase.Current.TextAreaWidth = currentFieldModel.TextAreaWidth;
                }
                dgv_FieldProperty.Refresh();
            }
        }

        public int TextAreaHeight
        {
            set
            {
                tb_TextAreaHeight.Text = value.ToString();
                bl_PV[7].Value = value.ToString();
                currentFieldModel.TextAreaHeight = value;
                //通知选中项改变属性
                if (DrawingControlBase.Current != null)
                {
                    if (DrawingControlBase.Current.CurrentField.TextAreaHeight != currentFieldModel.TextAreaHeight)
                        DrawingControlBase.Current.TextAreaHeight = currentFieldModel.TextAreaHeight;
                }
                dgv_FieldProperty.Refresh();
            }
        }



        BindingList<PropertyValue> bl_PV = new BindingList<PropertyValue>();
        public FieldProperty()
        {
            InitializeComponent();
            bl_PV.Add(new PropertyValue() { Property = "字体", Value = "" });
            bl_PV.Add(new PropertyValue() { Property = "字号", Value = "" });
            bl_PV.Add(new PropertyValue() { Property = "X坐标", Value = "" });
            bl_PV.Add(new PropertyValue() { Property = "Y坐标", Value = "" });
            bl_PV.Add(new PropertyValue() { Property = "字段类型", Value = "" });
            bl_PV.Add(new PropertyValue() { Property = "打印类型", Value = "" });
            bl_PV.Add(new PropertyValue() { Property = "长(编辑)", Value = "" });
            bl_PV.Add(new PropertyValue() { Property = "高(编辑)", Value = "" });
            bl_PV.Add(new PropertyValue() { Property = "加粗", Value = "" });
            bl_PV.Add(new PropertyValue() { Property = "倾斜", Value = "" });
            //设置字体
            List<string> fontFamilyNames = new List<string>();
            FontFamily[] fontFamilies = new InstalledFontCollection().Families;
            foreach (FontFamily f in fontFamilies)
                fontFamilyNames.Add(f.Name);
            cb_FontFamily.DataSource = fontFamilyNames;
            if (fontFamilyNames.Count(fn => fn == "宋体") > 0)
                cb_FontFamily.Text = "宋体";

            cb_FieldType.DataSource = GetFieldTypeDt();
            cb_PrintType.DataSource = GetPrintTypeDt();

            CurrentFieldModel.SyncField(new FieldModel()
            {
                FontFamilyName = cb_FontFamily.Text,
                FontSize = 8.0m,
                LocationX = 0,
                LocationY = 0
            });
            dgv_FieldProperty.DataSource = bl_PV;
        }

        private DataTable GetFieldTypeDt()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("display", typeof(string));
            dt.Columns.Add("value", typeof(FieldType));
            dt.Rows.Add("文字", FieldType.String);
            dt.Rows.Add("图片", FieldType.Image);
            dt.Rows.Add("条形码", FieldType.BarCode);
            dt.Rows.Add("数据块", FieldType.DataBlock);
            dt.Rows.Add("线条", FieldType.Line);
            return dt;
        }

        private DataTable GetTFDt()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("display", typeof(string));
            dt.Columns.Add("value", typeof(bool));
            dt.Rows.Add("是", true);
            dt.Rows.Add("否", false);
            return dt;
        }

        private DataTable GetPrintTypeDt()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("display", typeof(string));
            dt.Columns.Add("value", typeof(PrintType));
            dt.Rows.Add("固定文字", PrintType.Static);
            dt.Rows.Add("动态数据", PrintType.Dynamic);
            return dt;
        }

        private void dgv_FieldProperty_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1)
                return;
            switch (e.RowIndex)
            {
                case 0:
                    if (CurrentFieldModel.FieldType == FieldType.DataBlock
                        || CurrentFieldModel.FieldType == FieldType.Line)
                        return;
                    cb_FontFamily.Visible = true;
                    cb_FontFamily.Focus();
                    break;
                case 1:
                    if (CurrentFieldModel.FieldType == FieldType.DataBlock
                        || CurrentFieldModel.FieldType == FieldType.Line)
                        return;
                    nup_FontSize.Visible = true;
                    nup_FontSize.Focus();
                    break;
                case 2:
                    if (CurrentFieldModel.FieldType == FieldType.DataBlock)
                        return;
                    tb_X.Visible = true;
                    tb_X.Focus();
                    break;
                case 3:
                    tb_Y.Visible = true;
                    tb_Y.Focus();
                    break;
                case 4:
                    break;
                case 5:
                    if (CurrentFieldModel.FieldType == FieldType.DataBlock
                        || CurrentFieldModel.FieldType == FieldType.Line)
                        return;
                    cb_PrintType.Visible = true;
                    cb_PrintType.Focus();
                    break;
                case 6:
                    if (CurrentFieldModel.FieldType == FieldType.DataBlock)
                        return;
                    tb_TextAreaWidth.Visible = true;
                    tb_TextAreaWidth.Focus();
                    break;
                case 7:
                    tb_TextAreaHeight.Visible = true;
                    tb_TextAreaHeight.Focus();
                    break;
            }
        }

        private void cb_FontFamily_Validated(object sender, EventArgs e)
        {
            cb_FontFamily.Visible = false;
        }

        private void nup_FontSize_Validated(object sender, EventArgs e)
        {
            nup_FontSize.Visible = false;
        }

        private void tb_X_Validated(object sender, EventArgs e)
        {
            int value = 0;
            if (!int.TryParse(tb_X.Text.Trim(), out value))
            {
                MessageBox.Show("坐标必须是整数");
                tb_X.Focus();
                return;
            }
            LocationX = value;
            tb_X.Visible = false;
        }

        private void tb_Y_Validated(object sender, EventArgs e)
        {
            int value = 0;
            if (!int.TryParse(tb_Y.Text.Trim(), out value))
            {
                MessageBox.Show("坐标必须是整数");
                tb_Y.Focus();
                return;
            }
            LocationY = value;
            tb_Y.Visible = false;
        }

        public FieldModel InitFieldModel()
        {
            return CurrentFieldModel;
        }

        private void cb_FontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_FontFamily.SelectedValue == null)
                return;
            FontFamilyName = cb_FontFamily.SelectedValue.ToString();
        }

        private void nup_FontSize_ValueChanged(object sender, EventArgs e)
        {
            FontSize = nup_FontSize.Value;
            
        }

        private void TriggerValidated(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.Validate();
            }
            else if (sender is TextBox)
            {
                if (e.KeyChar != 45 && e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cb_FieldType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_FieldType.SelectedValue == null)
                return;
            FieldType = (FieldType)cb_FieldType.SelectedValue;
        }

        private void cb_PrintType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_PrintType.SelectedValue == null)
                return;
            PrintType = (PrintType)cb_PrintType.SelectedValue;
        }

        private void cb_FieldType_Validated(object sender, EventArgs e)
        {
            cb_FieldType.Visible = false;
        }

        private void cb_PrintType_Validated(object sender, EventArgs e)
        {
            cb_PrintType.Visible = false;
        }

        private void tb_TextAreaWidth_Validated(object sender, EventArgs e)
        {
            TextAreaWidth = Convert.ToInt32(tb_TextAreaWidth.Text);
            tb_TextAreaWidth.Visible = false;
        }

        private void tb_TextAreaHeight_Validated(object sender, EventArgs e)
        {
            TextAreaHeight = Convert.ToInt32(tb_TextAreaHeight.Text);
            tb_TextAreaHeight.Visible = false;
        }

        private void cb_Bold_CheckedChanged(object sender, EventArgs e)
        {
            Bold = cb_Bold.Checked;
        }

        private void cb_Italic_CheckedChanged(object sender, EventArgs e)
        {
            Italic = cb_Italic.Checked;
        }
    }
}
