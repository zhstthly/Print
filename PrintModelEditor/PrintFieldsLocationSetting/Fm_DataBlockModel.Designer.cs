namespace PrintFieldsLocationSetting
{
    partial class Fm_DataModel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_DataModelTemplate = new System.Windows.Forms.DataGridView();
            this.pn_Settings = new System.Windows.Forms.Panel();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.nud_Distance = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nud_FontSize = new System.Windows.Forms.NumericUpDown();
            this.cb_FontFamily = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nud_LineWidth = new System.Windows.Forms.NumericUpDown();
            this.btn_Create = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.nud_ColumnNum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nud_PaddingRight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nud_PaddingLeft = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_PaddingBottom = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_PaddingTop = new System.Windows.Forms.NumericUpDown();
            this.lb_PaddingTop = new System.Windows.Forms.Label();
            this.uc_CurrentDataModelView = new PrintFieldsLocationSetting.WinformControls.DataBlockModelView();
            this._modelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._pageWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._fontFamilyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._fontSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._paddingLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._paddingTop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._paddingRight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._paddingBottom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._lineWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._modelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dataSplitter = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataModelTemplate)).BeginInit();
            this.pn_Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Distance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ColumnNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PaddingRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PaddingLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PaddingBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PaddingTop)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_DataModelTemplate
            // 
            this.dgv_DataModelTemplate.AllowUserToAddRows = false;
            this.dgv_DataModelTemplate.AllowUserToResizeColumns = false;
            this.dgv_DataModelTemplate.AllowUserToResizeRows = false;
            this.dgv_DataModelTemplate.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgv_DataModelTemplate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DataModelTemplate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._modelID,
            this._pageWidth,
            this._columnNum,
            this._fontFamilyName,
            this._fontSize,
            this._paddingLeft,
            this._paddingTop,
            this._paddingRight,
            this._paddingBottom,
            this._distance,
            this._lineWidth,
            this._modelName,
            this._dataSplitter,
            this._enable});
            this.dgv_DataModelTemplate.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgv_DataModelTemplate.Location = new System.Drawing.Point(0, 0);
            this.dgv_DataModelTemplate.MultiSelect = false;
            this.dgv_DataModelTemplate.Name = "dgv_DataModelTemplate";
            this.dgv_DataModelTemplate.RowHeadersWidth = 15;
            this.dgv_DataModelTemplate.RowTemplate.Height = 23;
            this.dgv_DataModelTemplate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DataModelTemplate.Size = new System.Drawing.Size(379, 539);
            this.dgv_DataModelTemplate.TabIndex = 0;
            this.dgv_DataModelTemplate.SelectionChanged += new System.EventHandler(this.dgv_DataModelTemplate_SelectionChanged);
            this.dgv_DataModelTemplate.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgv_DataModelTemplate_UserDeletingRow);
            // 
            // pn_Settings
            // 
            this.pn_Settings.Controls.Add(this.btn_Edit);
            this.pn_Settings.Controls.Add(this.nud_Distance);
            this.pn_Settings.Controls.Add(this.label8);
            this.pn_Settings.Controls.Add(this.nud_FontSize);
            this.pn_Settings.Controls.Add(this.cb_FontFamily);
            this.pn_Settings.Controls.Add(this.label7);
            this.pn_Settings.Controls.Add(this.label6);
            this.pn_Settings.Controls.Add(this.nud_LineWidth);
            this.pn_Settings.Controls.Add(this.btn_Create);
            this.pn_Settings.Controls.Add(this.label5);
            this.pn_Settings.Controls.Add(this.nud_ColumnNum);
            this.pn_Settings.Controls.Add(this.label4);
            this.pn_Settings.Controls.Add(this.nud_PaddingRight);
            this.pn_Settings.Controls.Add(this.label2);
            this.pn_Settings.Controls.Add(this.nud_PaddingLeft);
            this.pn_Settings.Controls.Add(this.label3);
            this.pn_Settings.Controls.Add(this.nud_PaddingBottom);
            this.pn_Settings.Controls.Add(this.label1);
            this.pn_Settings.Controls.Add(this.nud_PaddingTop);
            this.pn_Settings.Controls.Add(this.lb_PaddingTop);
            this.pn_Settings.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_Settings.Location = new System.Drawing.Point(379, 0);
            this.pn_Settings.Name = "pn_Settings";
            this.pn_Settings.Size = new System.Drawing.Size(929, 62);
            this.pn_Settings.TabIndex = 1;
            // 
            // btn_Edit
            // 
            this.btn_Edit.BackColor = System.Drawing.Color.White;
            this.btn_Edit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Edit.Location = new System.Drawing.Point(0, 1);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(98, 56);
            this.btn_Edit.TabIndex = 24;
            this.btn_Edit.Text = "编辑";
            this.btn_Edit.UseVisualStyleBackColor = false;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // nud_Distance
            // 
            this.nud_Distance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_Distance.Location = new System.Drawing.Point(660, 1);
            this.nud_Distance.Name = "nud_Distance";
            this.nud_Distance.Size = new System.Drawing.Size(57, 26);
            this.nud_Distance.TabIndex = 23;
            this.nud_Distance.ValueChanged += new System.EventHandler(this.nud_Distance_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(615, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 21);
            this.label8.TabIndex = 22;
            this.label8.Text = "间距";
            // 
            // nud_FontSize
            // 
            this.nud_FontSize.DecimalPlaces = 1;
            this.nud_FontSize.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_FontSize.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nud_FontSize.Location = new System.Drawing.Point(548, 31);
            this.nud_FontSize.Name = "nud_FontSize";
            this.nud_FontSize.Size = new System.Drawing.Size(61, 26);
            this.nud_FontSize.TabIndex = 21;
            this.nud_FontSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nud_FontSize.ValueChanged += new System.EventHandler(this.nup_FontSize_ValueChanged);
            // 
            // cb_FontFamily
            // 
            this.cb_FontFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FontFamily.Font = new System.Drawing.Font("微软雅黑", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_FontFamily.FormattingEnabled = true;
            this.cb_FontFamily.Location = new System.Drawing.Point(407, 33);
            this.cb_FontFamily.Name = "cb_FontFamily";
            this.cb_FontFamily.Size = new System.Drawing.Size(90, 24);
            this.cb_FontFamily.TabIndex = 20;
            this.cb_FontFamily.SelectedIndexChanged += new System.EventHandler(this.cb_FontFamily_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(359, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 21);
            this.label7.TabIndex = 19;
            this.label7.Text = "字体";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(503, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 21);
            this.label6.TabIndex = 17;
            this.label6.Text = "字号";
            // 
            // nud_LineWidth
            // 
            this.nud_LineWidth.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_LineWidth.Location = new System.Drawing.Point(436, 1);
            this.nud_LineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_LineWidth.Name = "nud_LineWidth";
            this.nud_LineWidth.Size = new System.Drawing.Size(61, 26);
            this.nud_LineWidth.TabIndex = 11;
            this.nud_LineWidth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_LineWidth.ValueChanged += new System.EventHandler(this.nud_LineWidth_ValueChanged);
            // 
            // btn_Create
            // 
            this.btn_Create.BackColor = System.Drawing.Color.White;
            this.btn_Create.Location = new System.Drawing.Point(619, 30);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(98, 27);
            this.btn_Create.TabIndex = 15;
            this.btn_Create.Text = "新建";
            this.btn_Create.UseVisualStyleBackColor = false;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(359, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "始末线宽";
            // 
            // nud_ColumnNum
            // 
            this.nud_ColumnNum.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_ColumnNum.Location = new System.Drawing.Point(548, 1);
            this.nud_ColumnNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_ColumnNum.Name = "nud_ColumnNum";
            this.nud_ColumnNum.Size = new System.Drawing.Size(61, 26);
            this.nud_ColumnNum.TabIndex = 14;
            this.nud_ColumnNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(503, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "分栏";
            // 
            // nud_PaddingRight
            // 
            this.nud_PaddingRight.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_PaddingRight.Location = new System.Drawing.Point(292, 31);
            this.nud_PaddingRight.Name = "nud_PaddingRight";
            this.nud_PaddingRight.Size = new System.Drawing.Size(61, 26);
            this.nud_PaddingRight.TabIndex = 7;
            this.nud_PaddingRight.ValueChanged += new System.EventHandler(this.nud_PaddingRight_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(230, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "右边距";
            // 
            // nud_PaddingLeft
            // 
            this.nud_PaddingLeft.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_PaddingLeft.Location = new System.Drawing.Point(163, 31);
            this.nud_PaddingLeft.Name = "nud_PaddingLeft";
            this.nud_PaddingLeft.Size = new System.Drawing.Size(61, 26);
            this.nud_PaddingLeft.TabIndex = 5;
            this.nud_PaddingLeft.ValueChanged += new System.EventHandler(this.nud_PaddingLeft_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(101, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "左边距";
            // 
            // nud_PaddingBottom
            // 
            this.nud_PaddingBottom.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_PaddingBottom.Location = new System.Drawing.Point(292, 1);
            this.nud_PaddingBottom.Name = "nud_PaddingBottom";
            this.nud_PaddingBottom.Size = new System.Drawing.Size(61, 26);
            this.nud_PaddingBottom.TabIndex = 3;
            this.nud_PaddingBottom.ValueChanged += new System.EventHandler(this.nud_PaddingBottom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(230, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "下边距";
            // 
            // nud_PaddingTop
            // 
            this.nud_PaddingTop.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_PaddingTop.Location = new System.Drawing.Point(163, 1);
            this.nud_PaddingTop.Name = "nud_PaddingTop";
            this.nud_PaddingTop.Size = new System.Drawing.Size(61, 26);
            this.nud_PaddingTop.TabIndex = 1;
            this.nud_PaddingTop.ValueChanged += new System.EventHandler(this.nud_PaddingTop_ValueChanged);
            // 
            // lb_PaddingTop
            // 
            this.lb_PaddingTop.AutoSize = true;
            this.lb_PaddingTop.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_PaddingTop.Location = new System.Drawing.Point(101, 3);
            this.lb_PaddingTop.Name = "lb_PaddingTop";
            this.lb_PaddingTop.Size = new System.Drawing.Size(58, 21);
            this.lb_PaddingTop.TabIndex = 0;
            this.lb_PaddingTop.Text = "上边距";
            // 
            // uc_CurrentDataModelView
            // 
            this.uc_CurrentDataModelView.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.uc_CurrentDataModelView.ColumnNum = 0;
            this.uc_CurrentDataModelView.Distance = 0;
            this.uc_CurrentDataModelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_CurrentDataModelView.Edit = false;
            this.uc_CurrentDataModelView.FontFamilyName = null;
            this.uc_CurrentDataModelView.FontSize = 0F;
            this.uc_CurrentDataModelView.LineWidth = 0;
            this.uc_CurrentDataModelView.Location = new System.Drawing.Point(379, 62);
            this.uc_CurrentDataModelView.Name = "uc_CurrentDataModelView";
            this.uc_CurrentDataModelView.PaddingBottom = 0;
            this.uc_CurrentDataModelView.PaddingLeft = 0;
            this.uc_CurrentDataModelView.PaddingRight = 0;
            this.uc_CurrentDataModelView.PaddingTop = 0;
            this.uc_CurrentDataModelView.PageWidth = 0;
            this.uc_CurrentDataModelView.Percentage = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uc_CurrentDataModelView.Size = new System.Drawing.Size(929, 477);
            this.uc_CurrentDataModelView.TabIndex = 2;
            this.uc_CurrentDataModelView.SizeChanged += new System.EventHandler(this.uc_CurrentDataModelView_SizeChanged);
            // 
            // _modelID
            // 
            this._modelID.DataPropertyName = "ModelID";
            this._modelID.HeaderText = "ModelID";
            this._modelID.Name = "_modelID";
            this._modelID.ReadOnly = true;
            this._modelID.Visible = false;
            // 
            // _pageWidth
            // 
            this._pageWidth.DataPropertyName = "PageWidth";
            this._pageWidth.HeaderText = "PageWidth";
            this._pageWidth.Name = "_pageWidth";
            this._pageWidth.ReadOnly = true;
            this._pageWidth.Visible = false;
            // 
            // _columnNum
            // 
            this._columnNum.DataPropertyName = "ColumnNum";
            this._columnNum.HeaderText = "ColumnNum";
            this._columnNum.Name = "_columnNum";
            this._columnNum.ReadOnly = true;
            this._columnNum.Visible = false;
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
            // _paddingLeft
            // 
            this._paddingLeft.DataPropertyName = "PaddingLeft";
            this._paddingLeft.HeaderText = "PaddingLeft";
            this._paddingLeft.Name = "_paddingLeft";
            this._paddingLeft.ReadOnly = true;
            this._paddingLeft.Visible = false;
            // 
            // _paddingTop
            // 
            this._paddingTop.DataPropertyName = "PaddingTop";
            this._paddingTop.HeaderText = "PaddingTop";
            this._paddingTop.Name = "_paddingTop";
            this._paddingTop.ReadOnly = true;
            this._paddingTop.Visible = false;
            // 
            // _paddingRight
            // 
            this._paddingRight.DataPropertyName = "PaddingRight";
            this._paddingRight.HeaderText = "PaddingRight";
            this._paddingRight.Name = "_paddingRight";
            this._paddingRight.ReadOnly = true;
            this._paddingRight.Visible = false;
            // 
            // _paddingBottom
            // 
            this._paddingBottom.DataPropertyName = "PaddingBottom";
            this._paddingBottom.HeaderText = "PaddingBottom";
            this._paddingBottom.Name = "_paddingBottom";
            this._paddingBottom.ReadOnly = true;
            this._paddingBottom.Visible = false;
            // 
            // _distance
            // 
            this._distance.DataPropertyName = "Distance";
            this._distance.HeaderText = "Distance";
            this._distance.Name = "_distance";
            this._distance.ReadOnly = true;
            this._distance.Visible = false;
            // 
            // _lineWidth
            // 
            this._lineWidth.DataPropertyName = "LineWidth";
            this._lineWidth.HeaderText = "LineWidth";
            this._lineWidth.Name = "_lineWidth";
            this._lineWidth.ReadOnly = true;
            this._lineWidth.Visible = false;
            // 
            // _modelName
            // 
            this._modelName.DataPropertyName = "ModelName";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this._modelName.DefaultCellStyle = dataGridViewCellStyle1;
            this._modelName.HeaderText = "模板名";
            this._modelName.Name = "_modelName";
            this._modelName.Width = 200;
            // 
            // _dataSplitter
            // 
            this._dataSplitter.DataPropertyName = "DataSplitter";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this._dataSplitter.DefaultCellStyle = dataGridViewCellStyle2;
            this._dataSplitter.FalseValue = "false";
            this._dataSplitter.HeaderText = "数据分割线";
            this._dataSplitter.Name = "_dataSplitter";
            this._dataSplitter.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._dataSplitter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._dataSplitter.TrueValue = "true";
            this._dataSplitter.Width = 90;
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
            this._enable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._enable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._enable.TrueValue = "true";
            this._enable.Width = 65;
            // 
            // Fm_DataModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 539);
            this.Controls.Add(this.uc_CurrentDataModelView);
            this.Controls.Add(this.pn_Settings);
            this.Controls.Add(this.dgv_DataModelTemplate);
            this.Name = "Fm_DataModel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据模板";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Fm_DataModel_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataModelTemplate)).EndInit();
            this.pn_Settings.ResumeLayout(false);
            this.pn_Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Distance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ColumnNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PaddingRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PaddingLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PaddingBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PaddingTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_DataModelTemplate;
        private System.Windows.Forms.Panel pn_Settings;
        private System.Windows.Forms.NumericUpDown nud_ColumnNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nud_LineWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nud_PaddingRight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nud_PaddingLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_PaddingBottom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_PaddingTop;
        private System.Windows.Forms.Label lb_PaddingTop;
        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_FontFamily;
        private System.Windows.Forms.NumericUpDown nud_FontSize;
        private WinformControls.DataBlockModelView uc_CurrentDataModelView;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nud_Distance;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn _modelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _pageWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn _fontFamilyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _fontSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn _paddingLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn _paddingTop;
        private System.Windows.Forms.DataGridViewTextBoxColumn _paddingRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn _paddingBottom;
        private System.Windows.Forms.DataGridViewTextBoxColumn _distance;
        private System.Windows.Forms.DataGridViewTextBoxColumn _lineWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn _modelName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _dataSplitter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _enable;
    }
}