using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Globalization;

namespace SBuildNotifierV2
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblTitle.Text = Properties.Resources.ResourceManager.GetString("frmTitle");
            lblSeverPath.Text = Properties.Settings.Default.serverPath;
        }

        private void btnServerLocation_Click(object sender, EventArgs e)
        {
            DialogResult result = folderDialogServerPath.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                Properties.Settings.Default.serverPath = folderDialogServerPath.SelectedPath;
                Properties.Settings.Default.Save();
                lblSeverPath.Text = Properties.Settings.Default.serverPath;
            }
        }
    }
}
