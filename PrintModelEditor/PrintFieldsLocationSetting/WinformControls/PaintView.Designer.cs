using System;

namespace PrintFieldsLocationSetting
{
    partial class PaintView
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
            this.components = new System.ComponentModel.Container();
            PrintFieldsLocationSetting.Models.FieldModel fieldModel1 = new PrintFieldsLocationSetting.Models.FieldModel();
            this.pn_Page = new System.Windows.Forms.Panel();
            this.pn_UnSplitBlock = new System.Windows.Forms.Panel();
            this.pn_Blank = new System.Windows.Forms.Panel();
            this.pn_HScroll = new System.Windows.Forms.Panel();
            this.h_ScrollBar = new System.Windows.Forms.HScrollBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.v_ScrollBar = new System.Windows.Forms.VScrollBar();
            this.cm_FieldManager = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmi_AddNewField = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_AddDataBlock = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Splitter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Splitter_H = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Splitter_V = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Picture = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_BarCode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_BackGroundImage = new System.Windows.Forms.ToolStripMenuItem();
            this.fp_FieldProperty = new PrintFieldsLocationSetting.FieldProperty();
            this.pn_Page.SuspendLayout();
            this.pn_HScroll.SuspendLayout();
            this.cm_FieldManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_Page
            // 
            this.pn_Page.AllowDrop = true;
            this.pn_Page.BackColor = System.Drawing.Color.White;
            this.pn_Page.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pn_Page.Controls.Add(this.pn_UnSplitBlock);
            this.pn_Page.Controls.Add(this.pn_Blank);
            this.pn_Page.Location = new System.Drawing.Point(147, 18);
            this.pn_Page.Name = "pn_Page";
            this.pn_Page.Size = new System.Drawing.Size(318, 448);
            this.pn_Page.TabIndex = 0;
            this.pn_Page.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Blank_Click);
            this.pn_Page.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pn_Page_MouseMove);
            // 
            // pn_UnSplitBlock
            // 
            this.pn_UnSplitBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pn_UnSplitBlock.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pn_UnSplitBlock.Location = new System.Drawing.Point(0, 448);
            this.pn_UnSplitBlock.Name = "pn_UnSplitBlock";
            this.pn_UnSplitBlock.Size = new System.Drawing.Size(318, 0);
            this.pn_UnSplitBlock.TabIndex = 1;
            // 
            // pn_Blank
            // 
            this.pn_Blank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pn_Blank.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pn_Blank.Location = new System.Drawing.Point(0, 448);
            this.pn_Blank.Name = "pn_Blank";
            this.pn_Blank.Size = new System.Drawing.Size(318, 0);
            this.pn_Blank.TabIndex = 0;
            // 
            // pn_HScroll
            // 
            this.pn_HScroll.Controls.Add(this.h_ScrollBar);
            this.pn_HScroll.Controls.Add(this.panel2);
            this.pn_HScroll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pn_HScroll.Location = new System.Drawing.Point(0, 492);
            this.pn_HScroll.Name = "pn_HScroll";
            this.pn_HScroll.Size = new System.Drawing.Size(975, 17);
            this.pn_HScroll.TabIndex = 1;
            // 
            // h_ScrollBar
            // 
            this.h_ScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.h_ScrollBar.LargeChange = 1;
            this.h_ScrollBar.Location = new System.Drawing.Point(0, 0);
            this.h_ScrollBar.Maximum = 0;
            this.h_ScrollBar.Name = "h_ScrollBar";
            this.h_ScrollBar.Size = new System.Drawing.Size(958, 17);
            this.h_ScrollBar.TabIndex = 1;
            this.h_ScrollBar.ValueChanged += new System.EventHandler(this.h_ScrollBar_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(958, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(17, 17);
            this.panel2.TabIndex = 0;
            // 
            // v_ScrollBar
            // 
            this.v_ScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.v_ScrollBar.Location = new System.Drawing.Point(958, 0);
            this.v_ScrollBar.Minimum = -100;
            this.v_ScrollBar.Name = "v_ScrollBar";
            this.v_ScrollBar.Size = new System.Drawing.Size(17, 492);
            this.v_ScrollBar.TabIndex = 2;
            this.v_ScrollBar.ValueChanged += new System.EventHandler(this.v_ScrollBar_ValueChanged);
            // 
            // cm_FieldManager
            // 
            this.cm_FieldManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmi_AddNewField,
            this.tsmi_AddDataBlock,
            this.tsmi_Splitter,
            this.tsmi_Picture,
            this.tsmi_BarCode,
            this.toolStripSeparator1,
            this.tsmi_BackGroundImage});
            this.cm_FieldManager.Name = "cm_FieldManager";
            this.cm_FieldManager.Size = new System.Drawing.Size(153, 164);
            this.cm_FieldManager.Opening += new System.ComponentModel.CancelEventHandler(this.cm_FieldManager_Opening);
            // 
            // cmi_AddNewField
            // 
            this.cmi_AddNewField.Name = "cmi_AddNewField";
            this.cmi_AddNewField.Size = new System.Drawing.Size(152, 22);
            this.cmi_AddNewField.Text = "字段";
            this.cmi_AddNewField.Click += new System.EventHandler(this.cmi_AddNewField_Click);
            // 
            // tsmi_AddDataBlock
            // 
            this.tsmi_AddDataBlock.Name = "tsmi_AddDataBlock";
            this.tsmi_AddDataBlock.Size = new System.Drawing.Size(152, 22);
            this.tsmi_AddDataBlock.Text = "数据模板";
            // 
            // tsmi_Splitter
            // 
            this.tsmi_Splitter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Splitter_H,
            this.tsmi_Splitter_V});
            this.tsmi_Splitter.Name = "tsmi_Splitter";
            this.tsmi_Splitter.Size = new System.Drawing.Size(152, 22);
            this.tsmi_Splitter.Text = "分割线";
            // 
            // tsmi_Splitter_H
            // 
            this.tsmi_Splitter_H.Name = "tsmi_Splitter_H";
            this.tsmi_Splitter_H.Size = new System.Drawing.Size(100, 22);
            this.tsmi_Splitter_H.Text = "横线";
            this.tsmi_Splitter_H.Click += new System.EventHandler(this.tsmi_Splitter_H_Click);
            // 
            // tsmi_Splitter_V
            // 
            this.tsmi_Splitter_V.Name = "tsmi_Splitter_V";
            this.tsmi_Splitter_V.Size = new System.Drawing.Size(100, 22);
            this.tsmi_Splitter_V.Text = "竖线";
            this.tsmi_Splitter_V.Click += new System.EventHandler(this.tsmi_Splitter_V_Click);
            // 
            // tsmi_Picture
            // 
            this.tsmi_Picture.Name = "tsmi_Picture";
            this.tsmi_Picture.Size = new System.Drawing.Size(152, 22);
            this.tsmi_Picture.Text = "图片";
            this.tsmi_Picture.Click += new System.EventHandler(this.tsmi_Picture_Click);
            // 
            // tsmi_BarCode
            // 
            this.tsmi_BarCode.Name = "tsmi_BarCode";
            this.tsmi_BarCode.Size = new System.Drawing.Size(152, 22);
            this.tsmi_BarCode.Text = "条形码";
            this.tsmi_BarCode.Click += new System.EventHandler(this.tsmi_BarCode_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmi_BackGroundImage
            // 
            this.tsmi_BackGroundImage.Name = "tsmi_BackGroundImage";
            this.tsmi_BackGroundImage.Size = new System.Drawing.Size(152, 22);
            this.tsmi_BackGroundImage.Text = "底图";
            this.tsmi_BackGroundImage.Click += new System.EventHandler(this.tsmi_BackGroundImage_Click);
            // 
            // fp_FieldProperty
            // 
            fieldModel1.BindingText = null;
            fieldModel1.Bold = false;
            fieldModel1.Enable = false;
            fieldModel1.FieldID = new System.Guid("00000000-0000-0000-0000-000000000000");
            fieldModel1.FieldName = null;
            fieldModel1.FieldType = PrintFieldsLocationSetting.Models.FieldType.String;
            fieldModel1.FontFamilyName = "宋体";
            fieldModel1.FontSize = new decimal(new int[] {
            80,
            0,
            0,
            65536});
            fieldModel1.Italic = false;
            fieldModel1.LocationX = 0;
            fieldModel1.LocationY = 0;
            fieldModel1.ModelID = new System.Guid("00000000-0000-0000-0000-000000000000");
            fieldModel1.PrintType = PrintFieldsLocationSetting.Models.PrintType.Dynamic;
            fieldModel1.TextAreaHeight = 0;
            fieldModel1.TextAreaWidth = 0;
            this.fp_FieldProperty.CurrentFieldModel = fieldModel1;
            this.fp_FieldProperty.Location = new System.Drawing.Point(814, 0);
            this.fp_FieldProperty.Name = "fp_FieldProperty";
            this.fp_FieldProperty.Size = new System.Drawing.Size(144, 257);
            this.fp_FieldProperty.TabIndex = 3;
            // 
            // PaintView
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ContextMenuStrip = this.cm_FieldManager;
            this.Controls.Add(this.fp_FieldProperty);
            this.Controls.Add(this.v_ScrollBar);
            this.Controls.Add(this.pn_HScroll);
            this.Controls.Add(this.pn_Page);
            this.Name = "PaintView";
            this.Size = new System.Drawing.Size(975, 509);
            this.Load += new System.EventHandler(this.PaintView_Load);
            this.SizeChanged += new System.EventHandler(this.PaintView_SizeChanged);
            this.Click += new System.EventHandler(this.Blank_Click);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PaintView_MouseMove);
            this.pn_Page.ResumeLayout(false);
            this.pn_HScroll.ResumeLayout(false);
            this.cm_FieldManager.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_Page;
        private System.Windows.Forms.Panel pn_HScroll;
        private System.Windows.Forms.HScrollBar h_ScrollBar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.VScrollBar v_ScrollBar;
        private System.Windows.Forms.ContextMenuStrip cm_FieldManager;
        private System.Windows.Forms.ToolStripMenuItem cmi_AddNewField;
        private System.Windows.Forms.ToolStripMenuItem tsmi_AddDataBlock;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Splitter;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Splitter_H;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Splitter_V;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Picture;
        private System.Windows.Forms.ToolStripMenuItem tsmi_BarCode;
        private System.Windows.Forms.Panel pn_Blank;
        private System.Windows.Forms.Panel pn_UnSplitBlock;
        private FieldProperty fp_FieldProperty;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_BackGroundImage;
    }
}
