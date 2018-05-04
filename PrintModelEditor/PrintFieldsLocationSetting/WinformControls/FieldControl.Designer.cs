namespace PrintFieldsLocationSetting
{
    partial class FieldControl
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
            this.pn_Header = new System.Windows.Forms.Panel();
            this.cb_FieldName = new System.Windows.Forms.ComboBox();
            this.lb_FieldName = new System.Windows.Forms.Label();
            this.tb_BindingText = new System.Windows.Forms.TextBox();
            this.lb_ShowText = new System.Windows.Forms.Label();
            this.pn_Header.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_Header
            // 
            this.pn_Header.BackColor = System.Drawing.Color.White;
            this.pn_Header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_Header.Controls.Add(this.cb_FieldName);
            this.pn_Header.Controls.Add(this.lb_FieldName);
            this.pn_Header.Location = new System.Drawing.Point(0, 0);
            this.pn_Header.Name = "pn_Header";
            this.pn_Header.Size = new System.Drawing.Size(149, 21);
            this.pn_Header.TabIndex = 0;
            // 
            // cb_FieldName
            // 
            this.cb_FieldName.BackColor = System.Drawing.Color.White;
            this.cb_FieldName.FormattingEnabled = true;
            this.cb_FieldName.Location = new System.Drawing.Point(51, 0);
            this.cb_FieldName.Name = "cb_FieldName";
            this.cb_FieldName.Size = new System.Drawing.Size(97, 20);
            this.cb_FieldName.TabIndex = 3;
            this.cb_FieldName.TextChanged += new System.EventHandler(this.cb_FieldName_TextChanged);
            this.cb_FieldName.Validated += new System.EventHandler(this.cb_FieldName_Validated);
            // 
            // lb_FieldName
            // 
            this.lb_FieldName.AutoSize = true;
            this.lb_FieldName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_FieldName.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.lb_FieldName.Location = new System.Drawing.Point(-2, 0);
            this.lb_FieldName.Name = "lb_FieldName";
            this.lb_FieldName.Size = new System.Drawing.Size(48, 19);
            this.lb_FieldName.TabIndex = 2;
            this.lb_FieldName.Text = "字段名";
            this.lb_FieldName.Click += new System.EventHandler(this.lb_FieldName_Click);
            this.lb_FieldName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_ShowText_MouseDown);
            this.lb_FieldName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lb_ShowText_MouseMove);
            this.lb_FieldName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lb_ShowText_MouseUp);
            this.lb_FieldName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.lb_FieldName_PreviewKeyDown);
            // 
            // tb_BindingText
            // 
            this.tb_BindingText.BackColor = System.Drawing.Color.Pink;
            this.tb_BindingText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_BindingText.Location = new System.Drawing.Point(0, 23);
            this.tb_BindingText.Multiline = true;
            this.tb_BindingText.Name = "tb_BindingText";
            this.tb_BindingText.Size = new System.Drawing.Size(149, 21);
            this.tb_BindingText.TabIndex = 1;
            this.tb_BindingText.WordWrap = false;
            this.tb_BindingText.TextChanged += new System.EventHandler(this.tb_BindingText_TextChanged);
            // 
            // lb_ShowText
            // 
            this.lb_ShowText.AutoSize = true;
            this.lb_ShowText.Location = new System.Drawing.Point(0, 0);
            this.lb_ShowText.Name = "lb_ShowText";
            this.lb_ShowText.Size = new System.Drawing.Size(0, 12);
            this.lb_ShowText.TabIndex = 2;
            this.lb_ShowText.Click += new System.EventHandler(this.lb_FieldName_Click);
            this.lb_ShowText.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lb_ShowText_MouseDoubleClick);
            this.lb_ShowText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_ShowText_MouseDown);
            this.lb_ShowText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lb_ShowText_MouseMove);
            this.lb_ShowText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lb_ShowText_MouseUp);
            this.lb_ShowText.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.lb_FieldName_PreviewKeyDown);
            // 
            // FieldControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tb_BindingText);
            this.Controls.Add(this.pn_Header);
            this.Controls.Add(this.lb_ShowText);
            this.Name = "FieldControl";
            this.Size = new System.Drawing.Size(151, 45);
            this.Load += new System.EventHandler(this.FieldControl_Load);
            this.pn_Header.ResumeLayout(false);
            this.pn_Header.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel pn_Header;
        public System.Windows.Forms.TextBox tb_BindingText;
        private System.Windows.Forms.Label lb_FieldName;
        private System.Windows.Forms.Label lb_ShowText;
        private System.Windows.Forms.ComboBox cb_FieldName;
    }
}
