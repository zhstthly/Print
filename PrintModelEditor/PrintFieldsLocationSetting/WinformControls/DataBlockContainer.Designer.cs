namespace PrintFieldsLocationSetting.WinformControls
{
    partial class DataBlockContainer
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
            this.pn_Area = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pn_Area
            // 
            this.pn_Area.BackColor = System.Drawing.Color.White;
            this.pn_Area.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_Area.Location = new System.Drawing.Point(25, 16);
            this.pn_Area.Name = "pn_Area";
            this.pn_Area.Size = new System.Drawing.Size(707, 60);
            this.pn_Area.TabIndex = 3;
            // 
            // DataBlockContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pn_Area);
            this.Name = "DataBlockContainer";
            this.Size = new System.Drawing.Size(763, 97);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_Area;
    }
}
