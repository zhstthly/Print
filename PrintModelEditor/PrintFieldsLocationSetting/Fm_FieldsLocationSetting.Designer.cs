namespace PrintFieldsLocationSetting
{
    partial class Fm_FieldsLocationSetting
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pn_Side = new System.Windows.Forms.Panel();
            this.pn_Model = new System.Windows.Forms.Panel();
            this.pn_ModelBtns = new System.Windows.Forms.Panel();
            this.btn_Paste = new System.Windows.Forms.Button();
            this.btn_Copy = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.cb_Binding = new System.Windows.Forms.CheckBox();
            this.cb_Model = new System.Windows.Forms.ComboBox();
            this.lb_Model = new System.Windows.Forms.Label();
            this.pn_Paint = new System.Windows.Forms.Panel();
            this.pn_PaintInfo = new System.Windows.Forms.Panel();
            this.pn_PagePercent = new System.Windows.Forms.Panel();
            this.tb_SizePercent = new System.Windows.Forms.TrackBar();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_SizePercent = new System.Windows.Forms.Label();
            this.pn_Location = new System.Windows.Forms.Panel();
            this.lb_X = new System.Windows.Forms.Label();
            this.lb_Y = new System.Windows.Forms.Label();
            this.pn_Tools = new System.Windows.Forms.Panel();
            this.pn_PageSettings = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_UnSplitBlock = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nud_BlankWhite = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_DataModel = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_PageSettings = new System.Windows.Forms.Label();
            this.cb_PagePadding = new System.Windows.Forms.CheckBox();
            this.cb_PageSize = new System.Windows.Forms.ComboBox();
            this.nud_PagePadding = new System.Windows.Forms.NumericUpDown();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tt_CbBox = new System.Windows.Forms.ToolTip(this.components);
            this.btn_UploadImage = new System.Windows.Forms.Button();
            this.pv_Current = new PrintFieldsLocationSetting.PaintView();
            this.dm_Fields = new PrintFieldsLocationSetting.DataManager();
            this.btn_SenderSettings = new System.Windows.Forms.Button();
            this.pn_Side.SuspendLayout();
            this.pn_Model.SuspendLayout();
            this.pn_ModelBtns.SuspendLayout();
            this.pn_Paint.SuspendLayout();
            this.pn_PaintInfo.SuspendLayout();
            this.pn_PagePercent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SizePercent)).BeginInit();
            this.panel1.SuspendLayout();
            this.pn_Location.SuspendLayout();
            this.pn_Tools.SuspendLayout();
            this.pn_PageSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_UnSplitBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_BlankWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PagePadding)).BeginInit();
            this.SuspendLayout();
            // 
            // pn_Side
            // 
            this.pn_Side.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_Side.Controls.Add(this.dm_Fields);
            this.pn_Side.Controls.Add(this.pn_Model);
            this.pn_Side.Dock = System.Windows.Forms.DockStyle.Left;
            this.pn_Side.Location = new System.Drawing.Point(0, 0);
            this.pn_Side.Name = "pn_Side";
            this.pn_Side.Size = new System.Drawing.Size(267, 761);
            this.pn_Side.TabIndex = 0;
            // 
            // pn_Model
            // 
            this.pn_Model.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_Model.Controls.Add(this.pn_ModelBtns);
            this.pn_Model.Controls.Add(this.cb_Model);
            this.pn_Model.Controls.Add(this.lb_Model);
            this.pn_Model.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_Model.Location = new System.Drawing.Point(0, 0);
            this.pn_Model.Name = "pn_Model";
            this.pn_Model.Size = new System.Drawing.Size(265, 52);
            this.pn_Model.TabIndex = 0;
            // 
            // pn_ModelBtns
            // 
            this.pn_ModelBtns.BackColor = System.Drawing.Color.White;
            this.pn_ModelBtns.Controls.Add(this.btn_Paste);
            this.pn_ModelBtns.Controls.Add(this.btn_Copy);
            this.pn_ModelBtns.Controls.Add(this.btn_Remove);
            this.pn_ModelBtns.Controls.Add(this.cb_Binding);
            this.pn_ModelBtns.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pn_ModelBtns.Location = new System.Drawing.Point(0, 27);
            this.pn_ModelBtns.Name = "pn_ModelBtns";
            this.pn_ModelBtns.Size = new System.Drawing.Size(263, 23);
            this.pn_ModelBtns.TabIndex = 2;
            this.pn_ModelBtns.SizeChanged += new System.EventHandler(this.pn_ModelBtns_SizeChanged);
            // 
            // btn_Paste
            // 
            this.btn_Paste.BackColor = System.Drawing.Color.White;
            this.btn_Paste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Paste.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Paste.Location = new System.Drawing.Point(168, 0);
            this.btn_Paste.Name = "btn_Paste";
            this.btn_Paste.Size = new System.Drawing.Size(53, 23);
            this.btn_Paste.TabIndex = 4;
            this.btn_Paste.Text = "粘贴";
            this.btn_Paste.UseVisualStyleBackColor = false;
            this.btn_Paste.Click += new System.EventHandler(this.btn_Paste_Click);
            // 
            // btn_Copy
            // 
            this.btn_Copy.BackColor = System.Drawing.Color.White;
            this.btn_Copy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Copy.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Copy.Location = new System.Drawing.Point(111, 0);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(57, 23);
            this.btn_Copy.TabIndex = 5;
            this.btn_Copy.Text = "复制";
            this.btn_Copy.UseVisualStyleBackColor = false;
            this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.BackColor = System.Drawing.Color.White;
            this.btn_Remove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Remove.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Remove.Location = new System.Drawing.Point(56, 0);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(55, 23);
            this.btn_Remove.TabIndex = 3;
            this.btn_Remove.Text = "删除";
            this.btn_Remove.UseVisualStyleBackColor = false;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // cb_Binding
            // 
            this.cb_Binding.AutoSize = true;
            this.cb_Binding.Dock = System.Windows.Forms.DockStyle.Left;
            this.cb_Binding.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_Binding.Location = new System.Drawing.Point(0, 0);
            this.cb_Binding.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cb_Binding.Name = "cb_Binding";
            this.cb_Binding.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.cb_Binding.Size = new System.Drawing.Size(56, 23);
            this.cb_Binding.TabIndex = 6;
            this.cb_Binding.Text = "绑定";
            this.cb_Binding.UseVisualStyleBackColor = true;
            this.cb_Binding.CheckedChanged += new System.EventHandler(this.cb_Binding_CheckedChanged);
            // 
            // cb_Model
            // 
            this.cb_Model.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Model.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_Model.FormattingEnabled = true;
            this.cb_Model.Location = new System.Drawing.Point(52, 1);
            this.cb_Model.Name = "cb_Model";
            this.cb_Model.Size = new System.Drawing.Size(207, 25);
            this.cb_Model.TabIndex = 1;
            this.cb_Model.SelectedIndexChanged += new System.EventHandler(this.cb_Model_SelectedIndexChanged);
            // 
            // lb_Model
            // 
            this.lb_Model.AutoSize = true;
            this.lb_Model.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Model.Location = new System.Drawing.Point(4, 3);
            this.lb_Model.Name = "lb_Model";
            this.lb_Model.Size = new System.Drawing.Size(42, 21);
            this.lb_Model.TabIndex = 0;
            this.lb_Model.Text = "模板";
            this.lb_Model.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lb_Model_MouseDoubleClick);
            // 
            // pn_Paint
            // 
            this.pn_Paint.Controls.Add(this.pv_Current);
            this.pn_Paint.Controls.Add(this.pn_PaintInfo);
            this.pn_Paint.Controls.Add(this.pn_Tools);
            this.pn_Paint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_Paint.Location = new System.Drawing.Point(267, 0);
            this.pn_Paint.Name = "pn_Paint";
            this.pn_Paint.Size = new System.Drawing.Size(1217, 761);
            this.pn_Paint.TabIndex = 1;
            // 
            // pn_PaintInfo
            // 
            this.pn_PaintInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_PaintInfo.Controls.Add(this.pn_PagePercent);
            this.pn_PaintInfo.Controls.Add(this.pn_Location);
            this.pn_PaintInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pn_PaintInfo.Location = new System.Drawing.Point(0, 730);
            this.pn_PaintInfo.Name = "pn_PaintInfo";
            this.pn_PaintInfo.Size = new System.Drawing.Size(1217, 31);
            this.pn_PaintInfo.TabIndex = 1;
            // 
            // pn_PagePercent
            // 
            this.pn_PagePercent.Controls.Add(this.tb_SizePercent);
            this.pn_PagePercent.Controls.Add(this.label15);
            this.pn_PagePercent.Controls.Add(this.panel1);
            this.pn_PagePercent.Dock = System.Windows.Forms.DockStyle.Right;
            this.pn_PagePercent.Location = new System.Drawing.Point(731, 0);
            this.pn_PagePercent.Name = "pn_PagePercent";
            this.pn_PagePercent.Size = new System.Drawing.Size(345, 29);
            this.pn_PagePercent.TabIndex = 1;
            // 
            // tb_SizePercent
            // 
            this.tb_SizePercent.Dock = System.Windows.Forms.DockStyle.Right;
            this.tb_SizePercent.Location = new System.Drawing.Point(61, 0);
            this.tb_SizePercent.Maximum = 200;
            this.tb_SizePercent.Name = "tb_SizePercent";
            this.tb_SizePercent.Size = new System.Drawing.Size(222, 29);
            this.tb_SizePercent.TabIndex = 13;
            this.tb_SizePercent.Value = 100;
            this.tb_SizePercent.Visible = false;
            this.tb_SizePercent.Scroll += new System.EventHandler(this.tb_SizePercent_Scroll);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(4, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 21);
            this.label15.TabIndex = 14;
            this.label15.Text = "缩放比";
            this.label15.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lb_SizePercent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(283, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(62, 29);
            this.panel1.TabIndex = 12;
            // 
            // lb_SizePercent
            // 
            this.lb_SizePercent.AutoSize = true;
            this.lb_SizePercent.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_SizePercent.Location = new System.Drawing.Point(3, 5);
            this.lb_SizePercent.Name = "lb_SizePercent";
            this.lb_SizePercent.Size = new System.Drawing.Size(51, 21);
            this.lb_SizePercent.TabIndex = 12;
            this.lb_SizePercent.Text = "100%";
            this.lb_SizePercent.Visible = false;
            // 
            // pn_Location
            // 
            this.pn_Location.Controls.Add(this.lb_X);
            this.pn_Location.Controls.Add(this.lb_Y);
            this.pn_Location.Dock = System.Windows.Forms.DockStyle.Right;
            this.pn_Location.Location = new System.Drawing.Point(1076, 0);
            this.pn_Location.Name = "pn_Location";
            this.pn_Location.Size = new System.Drawing.Size(139, 29);
            this.pn_Location.TabIndex = 5;
            // 
            // lb_X
            // 
            this.lb_X.AutoSize = true;
            this.lb_X.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_X.Location = new System.Drawing.Point(3, 4);
            this.lb_X.Name = "lb_X";
            this.lb_X.Size = new System.Drawing.Size(24, 21);
            this.lb_X.TabIndex = 3;
            this.lb_X.Text = "X:";
            // 
            // lb_Y
            // 
            this.lb_Y.AutoSize = true;
            this.lb_Y.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Y.Location = new System.Drawing.Point(71, 4);
            this.lb_Y.Name = "lb_Y";
            this.lb_Y.Size = new System.Drawing.Size(24, 21);
            this.lb_Y.TabIndex = 4;
            this.lb_Y.Text = "Y:";
            // 
            // pn_Tools
            // 
            this.pn_Tools.AllowDrop = true;
            this.pn_Tools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_Tools.Controls.Add(this.pn_PageSettings);
            this.pn_Tools.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_Tools.Location = new System.Drawing.Point(0, 0);
            this.pn_Tools.Name = "pn_Tools";
            this.pn_Tools.Size = new System.Drawing.Size(1217, 29);
            this.pn_Tools.TabIndex = 0;
            // 
            // pn_PageSettings
            // 
            this.pn_PageSettings.Controls.Add(this.btn_SenderSettings);
            this.pn_PageSettings.Controls.Add(this.btn_UploadImage);
            this.pn_PageSettings.Controls.Add(this.label3);
            this.pn_PageSettings.Controls.Add(this.nud_UnSplitBlock);
            this.pn_PageSettings.Controls.Add(this.label4);
            this.pn_PageSettings.Controls.Add(this.label2);
            this.pn_PageSettings.Controls.Add(this.nud_BlankWhite);
            this.pn_PageSettings.Controls.Add(this.label1);
            this.pn_PageSettings.Controls.Add(this.btn_DataModel);
            this.pn_PageSettings.Controls.Add(this.btn_Save);
            this.pn_PageSettings.Controls.Add(this.btn_PageSettings);
            this.pn_PageSettings.Controls.Add(this.cb_PagePadding);
            this.pn_PageSettings.Controls.Add(this.cb_PageSize);
            this.pn_PageSettings.Controls.Add(this.nud_PagePadding);
            this.pn_PageSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_PageSettings.Location = new System.Drawing.Point(0, 0);
            this.pn_PageSettings.Name = "pn_PageSettings";
            this.pn_PageSettings.Size = new System.Drawing.Size(1215, 27);
            this.pn_PageSettings.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.Location = new System.Drawing.Point(1072, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 21);
            this.label3.TabIndex = 18;
            this.label3.Text = "mm";
            this.label3.Visible = false;
            // 
            // nud_UnSplitBlock
            // 
            this.nud_UnSplitBlock.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_UnSplitBlock.Location = new System.Drawing.Point(1033, 2);
            this.nud_UnSplitBlock.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_UnSplitBlock.Name = "nud_UnSplitBlock";
            this.nud_UnSplitBlock.Size = new System.Drawing.Size(36, 23);
            this.nud_UnSplitBlock.TabIndex = 17;
            this.nud_UnSplitBlock.Visible = false;
            this.nud_UnSplitBlock.ValueChanged += new System.EventHandler(this.nud_UnSplitBlock_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label4.Location = new System.Drawing.Point(956, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 16;
            this.label4.Text = "不分页块";
            this.label4.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.Location = new System.Drawing.Point(493, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "mm";
            // 
            // nud_BlankWhite
            // 
            this.nud_BlankWhite.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_BlankWhite.Location = new System.Drawing.Point(454, 2);
            this.nud_BlankWhite.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_BlankWhite.Name = "nud_BlankWhite";
            this.nud_BlankWhite.Size = new System.Drawing.Size(36, 23);
            this.nud_BlankWhite.TabIndex = 14;
            this.nud_BlankWhite.ValueChanged += new System.EventHandler(this.nud_BlankWhite_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(377, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "底部留白";
            // 
            // btn_DataModel
            // 
            this.btn_DataModel.Location = new System.Drawing.Point(532, 2);
            this.btn_DataModel.Name = "btn_DataModel";
            this.btn_DataModel.Size = new System.Drawing.Size(75, 23);
            this.btn_DataModel.TabIndex = 12;
            this.btn_DataModel.Text = "数据模板";
            this.btn_DataModel.UseVisualStyleBackColor = true;
            this.btn_DataModel.Click += new System.EventHandler(this.btn_DataModel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.White;
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Save.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Save.Location = new System.Drawing.Point(1140, 0);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 27);
            this.btn_Save.TabIndex = 11;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_PageSettings
            // 
            this.btn_PageSettings.AutoSize = true;
            this.btn_PageSettings.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_PageSettings.Location = new System.Drawing.Point(3, 2);
            this.btn_PageSettings.Name = "btn_PageSettings";
            this.btn_PageSettings.Size = new System.Drawing.Size(42, 21);
            this.btn_PageSettings.TabIndex = 2;
            this.btn_PageSettings.Text = "纸张";
            this.btn_PageSettings.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.btn_PageSettings_MouseDoubleClick);
            // 
            // cb_PagePadding
            // 
            this.cb_PagePadding.AutoSize = true;
            this.cb_PagePadding.Checked = true;
            this.cb_PagePadding.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_PagePadding.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_PagePadding.Location = new System.Drawing.Point(252, 0);
            this.cb_PagePadding.Name = "cb_PagePadding";
            this.cb_PagePadding.Size = new System.Drawing.Size(77, 25);
            this.cb_PagePadding.TabIndex = 10;
            this.cb_PagePadding.Text = "页边距";
            this.cb_PagePadding.UseVisualStyleBackColor = true;
            this.cb_PagePadding.CheckedChanged += new System.EventHandler(this.cb_PagePadding_CheckedChanged);
            // 
            // cb_PageSize
            // 
            this.cb_PageSize.BackColor = System.Drawing.Color.White;
            this.cb_PageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_PageSize.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_PageSize.FormattingEnabled = true;
            this.cb_PageSize.Location = new System.Drawing.Point(48, 1);
            this.cb_PageSize.Name = "cb_PageSize";
            this.cb_PageSize.Size = new System.Drawing.Size(200, 25);
            this.cb_PageSize.TabIndex = 3;
            this.cb_PageSize.SelectedIndexChanged += new System.EventHandler(this.cb_PageSize_SelectedIndexChanged);
            // 
            // nud_PagePadding
            // 
            this.nud_PagePadding.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_PagePadding.Location = new System.Drawing.Point(332, 2);
            this.nud_PagePadding.Name = "nud_PagePadding";
            this.nud_PagePadding.Size = new System.Drawing.Size(36, 23);
            this.nud_PagePadding.TabIndex = 5;
            this.nud_PagePadding.ValueChanged += new System.EventHandler(this.nud_PagePadding_ValueChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(267, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 761);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // btn_UploadImage
            // 
            this.btn_UploadImage.Location = new System.Drawing.Point(612, 2);
            this.btn_UploadImage.Name = "btn_UploadImage";
            this.btn_UploadImage.Size = new System.Drawing.Size(75, 23);
            this.btn_UploadImage.TabIndex = 19;
            this.btn_UploadImage.Text = "上传图片";
            this.btn_UploadImage.UseVisualStyleBackColor = true;
            this.btn_UploadImage.Click += new System.EventHandler(this.btn_UploadImage_Click);
            // 
            // pv_Current
            // 
            this.pv_Current.AllowDrop = true;
            this.pv_Current.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pv_Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pv_Current.FixedPageLocation = new System.Drawing.Point(608, 350);
            this.pv_Current.FixedPageSize = new System.Drawing.Size(0, 0);
            this.pv_Current.Location = new System.Drawing.Point(0, 29);
            this.pv_Current.Name = "pv_Current";
            this.pv_Current.OffsetPage = new System.Drawing.Point(0, 0);
            this.pv_Current.PaddingEnable = false;
            this.pv_Current.Size = new System.Drawing.Size(1217, 701);
            this.pv_Current.SizePercentNow = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pv_Current.TabIndex = 2;
            // 
            // dm_Fields
            // 
            this.dm_Fields.BackColor = System.Drawing.SystemColors.Control;
            this.dm_Fields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dm_Fields.Location = new System.Drawing.Point(0, 52);
            this.dm_Fields.ModelID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.dm_Fields.Name = "dm_Fields";
            this.dm_Fields.Size = new System.Drawing.Size(265, 707);
            this.dm_Fields.TabIndex = 1;
            // 
            // btn_SenderSettings
            // 
            this.btn_SenderSettings.Location = new System.Drawing.Point(693, 2);
            this.btn_SenderSettings.Name = "btn_SenderSettings";
            this.btn_SenderSettings.Size = new System.Drawing.Size(75, 23);
            this.btn_SenderSettings.TabIndex = 20;
            this.btn_SenderSettings.Text = "寄件人设置";
            this.btn_SenderSettings.UseVisualStyleBackColor = true;
            this.btn_SenderSettings.Click += new System.EventHandler(this.btn_SenderSettings_Click);
            // 
            // Fm_FieldsLocationSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 761);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pn_Paint);
            this.Controls.Add(this.pn_Side);
            this.Name = "Fm_FieldsLocationSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打印字段位置设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Fm_FieldsLocationSetting_FormClosing);
            this.Load += new System.EventHandler(this.Fm_FieldsLocationSetting_Load);
            this.pn_Side.ResumeLayout(false);
            this.pn_Model.ResumeLayout(false);
            this.pn_Model.PerformLayout();
            this.pn_ModelBtns.ResumeLayout(false);
            this.pn_ModelBtns.PerformLayout();
            this.pn_Paint.ResumeLayout(false);
            this.pn_PaintInfo.ResumeLayout(false);
            this.pn_PagePercent.ResumeLayout(false);
            this.pn_PagePercent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SizePercent)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pn_Location.ResumeLayout(false);
            this.pn_Location.PerformLayout();
            this.pn_Tools.ResumeLayout(false);
            this.pn_PageSettings.ResumeLayout(false);
            this.pn_PageSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_UnSplitBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_BlankWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PagePadding)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_Side;
        private System.Windows.Forms.Panel pn_Model;
        private System.Windows.Forms.ComboBox cb_Model;
        private System.Windows.Forms.Label lb_Model;
        private System.Windows.Forms.Panel pn_Paint;
        private System.Windows.Forms.Panel pn_PaintInfo;
        private System.Windows.Forms.Label lb_Y;
        private System.Windows.Forms.Label lb_X;
        private System.Windows.Forms.Panel pn_Tools;
        private System.Windows.Forms.NumericUpDown nud_PagePadding;
        private System.Windows.Forms.ComboBox cb_PageSize;
        private System.Windows.Forms.Label btn_PageSettings;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pn_Location;
        private System.Windows.Forms.TrackBar tb_SizePercent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_SizePercent;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel pn_PagePercent;
        private System.Windows.Forms.CheckBox cb_PagePadding;
        private System.Windows.Forms.Panel pn_PageSettings;
        private DataManager dm_Fields;
        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.Button btn_Paste;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Panel pn_ModelBtns;
        private System.Windows.Forms.ToolTip tt_CbBox;
        private System.Windows.Forms.CheckBox cb_Binding;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_DataModel;
        private System.Windows.Forms.NumericUpDown nud_BlankWhite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_UnSplitBlock;
        private System.Windows.Forms.Label label4;
        private PaintView pv_Current;
        private System.Windows.Forms.Button btn_UploadImage;
        private System.Windows.Forms.Button btn_SenderSettings;
    }
}

