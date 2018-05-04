using BLL;
using DataEntity;
using Infrastructure;
using PrintEntity;
using PrintServer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Print
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_ManualPrint_Click(object sender, EventArgs e)
        {
            Fm_ManualPrint fm_MP = new Fm_ManualPrint();
            fm_MP.Show();
        }

        private void btn_AutoPrint_Click(object sender, EventArgs e)
        {
            PrinterManager.PrintEngine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Fm_ConfigSettings().ShowDialog();
        }

        private void btn_SysConfigSettings_Click(object sender, EventArgs e)
        {
            new Fm_SysConfigSettings().ShowDialog();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)  //判断是否最小化
            {
                this.ShowInTaskbar = false;  //不显示在系统任务栏
                notifyIcon1.Visible = true;  //托盘图标可见
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;  //显示在系统任务栏
            this.WindowState = FormWindowState.Normal;  //还原窗体
            this.BringToFront();
            this.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void tsmi_Close_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            this.Dispose();
            
        }

        private void tsmi_AutoPrint_Click(object sender, EventArgs e)
        {
            PrinterManager.PrintEngine();
        }

        private void tsmi_ManalPrint_Click(object sender, EventArgs e)
        {
            Fm_ManualPrint fm_MP = new Fm_ManualPrint();
            fm_MP.Show();
        }

        private void tsmi_RepositorySettings_Click(object sender, EventArgs e)
        {
            new Fm_ConfigSettings().ShowDialog();
        }

        private void tsmi_PrintSettings_Click(object sender, EventArgs e)
        {
            new Fm_SysConfigSettings().ShowDialog();
        }
    }
}
