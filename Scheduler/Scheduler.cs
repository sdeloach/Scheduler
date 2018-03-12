using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class Scheduler : Form
    {
        string localFilename;
        string KSISfilename;
        Semester localSemester;
        Semester KSISsemester;

        public Scheduler()
        {
            InitializeComponent();
        }

        public void printMessage(string s)
        {
            MessageBox.Show(s);
        }

        private void openLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            localSemester = new Semester(this);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open local file";
            ofd.Filter = "CSV Files|*.csv";

            try
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    localFilename = ofd.FileName;
                    localSemester.localRead(localFilename);
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void verifyLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KSISsemester = new Semester(this);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Verify against KSIS file";
            ofd.Filter = "CSV Files|*.csv";

            try
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    KSISfilename = ofd.FileName;
                    KSISsemester.KSISread(KSISfilename);
                    localSemester.verify(KSISsemester);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
