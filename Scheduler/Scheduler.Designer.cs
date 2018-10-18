namespace Scheduler
{
    partial class Viewer
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
            this.OutputTextViewer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog3 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog4 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.PrintAll = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
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
            this.calendarEventsToolStripMenuItem.Click += new System.EventHandler(this.ProduceCalendarEvents);
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
            this.inMSWordToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.inMSWordToolStripMenuItem.Text = "in MS Word";
            this.inMSWordToolStripMenuItem.Click += new System.EventHandler(this.OpenInWord);
            // 
            // inBrowserToolStripMenuItem
            // 
            this.inBrowserToolStripMenuItem.Name = "inBrowserToolStripMenuItem";
            this.inBrowserToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.inBrowserToolStripMenuItem.Text = "in Browser";
            this.inBrowserToolStripMenuItem.Click += new System.EventHandler(this.OpenInWebbrowser);
            // 
            // dataFolderToolStripMenuItem
            // 
            this.dataFolderToolStripMenuItem.Name = "dataFolderToolStripMenuItem";
            this.dataFolderToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
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
            // OutputTextViewer
            // 
            this.OutputTextViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OutputTextViewer.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.OutputTextViewer.Location = new System.Drawing.Point(0, 56);
            this.OutputTextViewer.Multiline = true;
            this.OutputTextViewer.Name = "OutputTextViewer";
            this.OutputTextViewer.ReadOnly = true;
            this.OutputTextViewer.Size = new System.Drawing.Size(548, 342);
            this.OutputTextViewer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Local";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "KSIS";
            // 
            // textBox1
            // 
            this.textBox1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.textBox1.Location = new System.Drawing.Point(53, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(204, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(330, 30);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(204, 20);
            this.textBox2.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(459, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Clear);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(378, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Reload";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PrintAll
            // 
            this.PrintAll.AutoSize = true;
            this.PrintAll.Location = new System.Drawing.Point(229, 5);
            this.PrintAll.Name = "PrintAll";
            this.PrintAll.Size = new System.Drawing.Size(61, 17);
            this.PrintAll.TabIndex = 8;
            this.PrintAll.Text = "Print All";
            this.PrintAll.UseVisualStyleBackColor = true;
            this.PrintAll.CheckedChanged += new System.EventHandler(this.PrintAllSection_CheckboxChange);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(304, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "PrintDates";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.PrintAllTimes_CheckboxChange);
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 399);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.PrintAll);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutputTextViewer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Viewer";
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
        private System.Windows.Forms.TextBox OutputTextViewer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog4;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox PrintAll;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}