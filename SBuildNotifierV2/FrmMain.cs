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
using System.IO;

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
            //Settings text to what they should be
            lblTitle.Text = Properties.Resources.ResourceManager.GetString("frmTitle");
            lblSeverPath.Text = Properties.Settings.Default.serverPath;
            lblDate.Text = DateTime.Now.ToString("MMMM") + " - " + DateTime.Now.Year.ToString();
            //This grabs the branches, lists them then adds the branch names only to the check boxes
            string[] dirs = Directory.GetDirectories(@Properties.Settings.Default.serverPath + "\\" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.ToString("MMMM"), "b*", SearchOption.TopDirectoryOnly);
            var branchNamesList = new List<string>();
            foreach (string branch in dirs)
            {
                branchNamesList.Add(branch.Substring(branch.LastIndexOf('\\') + 1));
            }
            string[] branchNamesString = branchNamesList.ToArray();
            chkLBoxBranches.Items.AddRange(branchNamesString);
        }

        private void btnServerLocation_Click(object sender, EventArgs e)
        {
            //Clicking this allows you to change the location of the server
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
