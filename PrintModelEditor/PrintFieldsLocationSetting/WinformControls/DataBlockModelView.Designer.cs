namespace PrintFieldsLocationSetting.WinformControls
{
    partial class DataBlockModelView
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
            PrintFieldsLocationSetting.Models.DataBlockModel dataBlockModel1 = new PrintFieldsLocationSetting.Models.DataBlockModel();
            this.pn_Page = new System.Windows.Forms.Panel();
            this.pn_Area = new System.Windows.Forms.Panel();
            this.uc_DataModelProperty = new PrintFieldsLocationSetting.WinformControls.DataBlockModelProperty();
            this.pn_Page.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_Page
            // 
            this.pn_Page.BackColor = System.Drawing.Color.White;
            this.pn_Page.Controls.Add(this.pn_Area);
            this.pn_Page.Location = new System.Drawing.Point(61, 175);
            this.pn_Page.Name = "pn_Page";
            this.pn_Page.Size = new System.Drawing.Size(732, 88);
            this.pn_Page.TabIndex = 0;
            // 
            // pn_Area
            // 
            this.pn_Area.BackColor = System.Drawing.Color.White;
            this.pn_Area.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_Area.Location = new System.Drawing.Point(13, 15);
            this.pn_Area.Name = "pn_Area";
            this.pn_Area.Size = new System.Drawing.Size(707, 60);
            this.pn_Area.TabIndex = 2;
            // 
            // uc_DataModelProperty
            // 
            dataBlockModel1.ColumnName = "[列名]";
            dataBlockModel1.ColumnWidth = 20;
            dataBlockModel1.DataModelID = new System.Guid("00000000-0000-0000-0000-000000000000");
            dataBlockModel1.DataName = "[数据名]";
            dataBlockModel1.Index = 0;
            dataBlockModel1.TemplateModelID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.uc_DataModelProperty.CurrentDataModel = dataBlockModel1;
            this.uc_DataModelProperty.Location = new System.Drawing.Point(781, 3);
            this.uc_DataModelProperty.Name = "uc_DataModelProperty";
            this.uc_DataModelProperty.Size = new System.Drawing.Size(144, 96);
            this.uc_DataModelProperty.TabIndex = 1;
            // 
            // DataBlockModelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.uc_DataModelProperty);
            this.Controls.Add(this.pn_Page);
            this.Name = "DataBlockModelView";
            this.Size = new System.Drawing.Size(928, 539);
            this.Load += new System.EventHandler(this.DataModelView_Load);
            this.pn_Page.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_Page;
        private System.Windows.Forms.Panel pn_Area;
        private DataBlockModelProperty uc_DataModelProperty;
    }
}
