namespace Print
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_ManualPrint = new System.Windows.Forms.Button();
            this.btn_AutoPrint = new System.Windows.Forms.Button();
            this.btn_Repository = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_SysConfigSettings = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_RepositorySettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_PrintSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_AutoPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ManalPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ManualPrint
            // 
            this.btn_ManualPrint.Location = new System.Drawing.Point(97, 20);
            this.btn_ManualPrint.Name = "btn_ManualPrint";
            this.btn_ManualPrint.Size = new System.Drawing.Size(75, 23);
            this.btn_ManualPrint.TabIndex = 44;
            this.btn_ManualPrint.Text = "手动打印";
            this.btn_ManualPrint.UseVisualStyleBackColor = true;
            this.btn_ManualPrint.Click += new System.EventHandler(this.btn_ManualPrint_Click);
            // 
            // btn_AutoPrint
            // 
            this.btn_AutoPrint.Location = new System.Drawing.Point(7, 20);
            this.btn_AutoPrint.Name = "btn_AutoPrint";
            this.btn_AutoPrint.Size = new System.Drawing.Size(75, 23);
            this.btn_AutoPrint.TabIndex = 45;
            this.btn_AutoPrint.Text = "自动打印";
            this.btn_AutoPrint.UseVisualStyleBackColor = true;
            this.btn_AutoPrint.Click += new System.EventHandler(this.btn_AutoPrint_Click);
            // 
            // btn_Repository
            // 
            this.btn_Repository.Location = new System.Drawing.Point(6, 20);
            this.btn_Repository.Name = "btn_Repository";
            this.btn_Repository.Size = new System.Drawing.Size(75, 23);
            this.btn_Repository.TabIndex = 46;
            this.btn_Repository.Text = "仓库设置";
            this.btn_Repository.UseVisualStyleBackColor = true;
            this.btn_Repository.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.btn_AutoPrint);
            this.groupBox1.Controls.Add(this.btn_ManualPrint);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 58);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "订单打印";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.btn_SysConfigSettings);
            this.groupBox2.Controls.Add(this.btn_Repository);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 58);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "本地设置";
            // 
            // btn_SysConfigSettings
            // 
            this.btn_SysConfigSettings.Location = new System.Drawing.Point(97, 20);
            this.btn_SysConfigSettings.MaximumSize = new System.Drawing.Size(72, 23);
            this.btn_SysConfigSettings.MinimumSize = new System.Drawing.Size(72, 23);
            this.btn_SysConfigSettings.Name = "btn_SysConfigSettings";
            this.btn_SysConfigSettings.Size = new System.Drawing.Size(72, 23);
            this.btn_SysConfigSettings.TabIndex = 47;
            this.btn_SysConfigSettings.Text = "打印设置";
            this.btn_SysConfigSettings.UseVisualStyleBackColor = true;
            this.btn_SysConfigSettings.Click += new System.EventHandler(this.btn_SysConfigSettings_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "可得网订单自动打印系统";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_AutoPrint,
            this.tsmi_ManalPrint,
            this.toolStripSeparator1,
            this.tsmi_RepositorySettings,
            this.tsmi_PrintSettings,
            this.toolStripSeparator2,
            this.tsmi_Close});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 126);
            // 
            // tsmi_Close
            // 
            this.tsmi_Close.Name = "tsmi_Close";
            this.tsmi_Close.Size = new System.Drawing.Size(124, 22);
            this.tsmi_Close.Text = "退出";
            this.tsmi_Close.Click += new System.EventHandler(this.tsmi_Close_Click);
            // 
            // tsmi_RepositorySettings
            // 
            this.tsmi_RepositorySettings.Name = "tsmi_RepositorySettings";
            this.tsmi_RepositorySettings.Size = new System.Drawing.Size(124, 22);
            this.tsmi_RepositorySettings.Text = "仓库设置";
            this.tsmi_RepositorySettings.Click += new System.EventHandler(this.tsmi_RepositorySettings_Click);
            // 
            // tsmi_PrintSettings
            // 
            this.tsmi_PrintSettings.Name = "tsmi_PrintSettings";
            this.tsmi_PrintSettings.Size = new System.Drawing.Size(124, 22);
            this.tsmi_PrintSettings.Text = "打印设置";
            this.tsmi_PrintSettings.Click += new System.EventHandler(this.tsmi_PrintSettings_Click);
            // 
            // tsmi_AutoPrint
            // 
            this.tsmi_AutoPrint.Name = "tsmi_AutoPrint";
            this.tsmi_AutoPrint.Size = new System.Drawing.Size(124, 22);
            this.tsmi_AutoPrint.Text = "自动打印";
            this.tsmi_AutoPrint.Click += new System.EventHandler(this.tsmi_AutoPrint_Click);
            // 
            // tsmi_ManalPrint
            // 
            this.tsmi_ManalPrint.Name = "tsmi_ManalPrint";
            this.tsmi_ManalPrint.Size = new System.Drawing.Size(124, 22);
            this.tsmi_ManalPrint.Text = "手动打印";
            this.tsmi_ManalPrint.Click += new System.EventHandler(this.tsmi_ManalPrint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(121, 6);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 116);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打印程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_ManualPrint;
        private System.Windows.Forms.Button btn_AutoPrint;
        private System.Windows.Forms.Button btn_Repository;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_SysConfigSettings;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Close;
        private System.Windows.Forms.ToolStripMenuItem tsmi_AutoPrint;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ManalPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_RepositorySettings;
        private System.Windows.Forms.ToolStripMenuItem tsmi_PrintSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

