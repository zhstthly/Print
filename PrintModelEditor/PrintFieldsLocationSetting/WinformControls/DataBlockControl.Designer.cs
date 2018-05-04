namespace PrintFieldsLocationSetting.WinformControls
{
    partial class DataBlockControl
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
            this.pn_SplitTop = new System.Windows.Forms.Panel();
            this.pn_SplitBottom = new System.Windows.Forms.Panel();
            this.lb_ColumnName = new System.Windows.Forms.Label();
            this.lb_DataName = new System.Windows.Forms.Label();
            this.pn_Distance = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pn_SplitTop
            // 
            this.pn_SplitTop.BackColor = System.Drawing.Color.Black;
            this.pn_SplitTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_SplitTop.Location = new System.Drawing.Point(0, 12);
            this.pn_SplitTop.Name = "pn_SplitTop";
            this.pn_SplitTop.Size = new System.Drawing.Size(126, 5);
            this.pn_SplitTop.TabIndex = 1;
            // 
            // pn_SplitBottom
            // 
            this.pn_SplitBottom.BackColor = System.Drawing.Color.Black;
            this.pn_SplitBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pn_SplitBottom.Location = new System.Drawing.Point(0, 34);
            this.pn_SplitBottom.Name = "pn_SplitBottom";
            this.pn_SplitBottom.Size = new System.Drawing.Size(126, 5);
            this.pn_SplitBottom.TabIndex = 2;
            // 
            // lb_ColumnName
            // 
            this.lb_ColumnName.AutoSize = true;
            this.lb_ColumnName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_ColumnName.Location = new System.Drawing.Point(0, 0);
            this.lb_ColumnName.Name = "lb_ColumnName";
            this.lb_ColumnName.Size = new System.Drawing.Size(41, 12);
            this.lb_ColumnName.TabIndex = 3;
            this.lb_ColumnName.Text = "[列名]";
            // 
            // lb_DataName
            // 
            this.lb_DataName.AutoSize = true;
            this.lb_DataName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_DataName.Location = new System.Drawing.Point(0, 17);
            this.lb_DataName.Name = "lb_DataName";
            this.lb_DataName.Size = new System.Drawing.Size(53, 12);
            this.lb_DataName.TabIndex = 4;
            this.lb_DataName.Text = "[数据名]";
            // 
            // pn_Distance
            // 
            this.pn_Distance.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_Distance.Location = new System.Drawing.Point(0, 17);
            this.pn_Distance.Name = "pn_Distance";
            this.pn_Distance.Size = new System.Drawing.Size(126, 0);
            this.pn_Distance.TabIndex = 5;
            // 
            // DataBlockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_DataName);
            this.Controls.Add(this.pn_Distance);
            this.Controls.Add(this.pn_SplitTop);
            this.Controls.Add(this.lb_ColumnName);
            this.Controls.Add(this.pn_SplitBottom);
            this.Name = "DataBlockControl";
            this.Size = new System.Drawing.Size(126, 39);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataControl_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataControl_MouseClick);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DataBlockControl_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pn_SplitTop;
        private System.Windows.Forms.Panel pn_SplitBottom;
        private System.Windows.Forms.Label lb_ColumnName;
        private System.Windows.Forms.Label lb_DataName;
        private System.Windows.Forms.Panel pn_Distance;
    }
}
