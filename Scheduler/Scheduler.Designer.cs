﻿namespace Scheduler
{
    partial class Scheduler
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verifyLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertKSISToLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructorScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.inMSWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.openToolStripMenuItem,
            this.openToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(548, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLocalToolStripMenuItem,
            this.verifyLocalToolStripMenuItem,
            this.convertKSISToLocalToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openLocalToolStripMenuItem
            // 
            this.openLocalToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.openLocalToolStripMenuItem.Name = "openLocalToolStripMenuItem";
            this.openLocalToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openLocalToolStripMenuItem.Text = "&Open Local";
            this.openLocalToolStripMenuItem.Click += new System.EventHandler(this.OpenLocalFile);
            // 
            // verifyLocalToolStripMenuItem
            // 
            this.verifyLocalToolStripMenuItem.Name = "verifyLocalToolStripMenuItem";
            this.verifyLocalToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.verifyLocalToolStripMenuItem.Text = "Verify Local";
            this.verifyLocalToolStripMenuItem.Click += new System.EventHandler(this.VerifyLocalFile);
            // 
            // convertKSISToLocalToolStripMenuItem
            // 
            this.convertKSISToLocalToolStripMenuItem.Name = "convertKSISToLocalToolStripMenuItem";
            this.convertKSISToLocalToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.convertKSISToLocalToolStripMenuItem.Text = "Convert KSIS to Local";
            this.convertKSISToLocalToolStripMenuItem.Click += new System.EventHandler(this.ConvertToKSISFile);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineScheduleToolStripMenuItem,
            this.instructorScheduleToolStripMenuItem,
            this.calendarEventsToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.openToolStripMenuItem.Text = "Produce";
            // 
            // lineScheduleToolStripMenuItem
            // 
            this.lineScheduleToolStripMenuItem.Name = "lineScheduleToolStripMenuItem";
            this.lineScheduleToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.lineScheduleToolStripMenuItem.Text = "Line Schedule";
            this.lineScheduleToolStripMenuItem.Click += new System.EventHandler(this.ProduceLineSchedule);
            // 
            // instructorScheduleToolStripMenuItem
            // 
            this.instructorScheduleToolStripMenuItem.Name = "instructorScheduleToolStripMenuItem";
            this.instructorScheduleToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.instructorScheduleToolStripMenuItem.Text = "Instructor Schedule";
            this.instructorScheduleToolStripMenuItem.Click += new System.EventHandler(this.ProduceInstructorSchedule);
            // 
            // calendarEventsToolStripMenuItem
            // 
            this.calendarEventsToolStripMenuItem.Name = "calendarEventsToolStripMenuItem";
            this.calendarEventsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.calendarEventsToolStripMenuItem.Text = "Calendar Events";
            this.calendarEventsToolStripMenuItem.Click += new System.EventHandler(this.calendarEventsToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inMSWordToolStripMenuItem,
            this.inBrowserToolStripMenuItem,
            this.dataFolderToolStripMenuItem});
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.openToolStripMenuItem1.Text = "Open";
            // 
            // inMSWordToolStripMenuItem
            // 
            this.inMSWordToolStripMenuItem.Name = "inMSWordToolStripMenuItem";
            this.inMSWordToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.inMSWordToolStripMenuItem.Text = "in MS Word";
            this.inMSWordToolStripMenuItem.Click += new System.EventHandler(this.OpenInWord);
            // 
            // inBrowserToolStripMenuItem
            // 
            this.inBrowserToolStripMenuItem.Name = "inBrowserToolStripMenuItem";
            this.inBrowserToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.inBrowserToolStripMenuItem.Text = "in Browser";
            this.inBrowserToolStripMenuItem.Click += new System.EventHandler(this.OpenInWebbrowser);
            // 
            // dataFolderToolStripMenuItem
            // 
            this.dataFolderToolStripMenuItem.Name = "dataFolderToolStripMenuItem";
            this.dataFolderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dataFolderToolStripMenuItem.Text = "Data Folder";
            this.dataFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenDataFolder);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.ShowAbout);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 24);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(548, 375);
            this.textBox1.TabIndex = 1;
            // 
            // Scheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 399);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Scheduler";
            this.Text = "Scheduler";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLocalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verifyLocalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertKSISToLocalToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructorScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calendarEventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inMSWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataFolderToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
    }
}