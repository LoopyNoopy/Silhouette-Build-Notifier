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
using System.Configuration;

namespace SBuildNotifierV2
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void updateBranchList()
        {
            //This updated the branchNames setting when the directory has been changed
            if(Directory.Exists(@Properties.Settings.Default.serverPath + "\\" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.ToString("MMMM")))
            {
                string[] dirs = Directory.GetDirectories(@Properties.Settings.Default.serverPath + "\\" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.ToString("MMMM"), "b*", SearchOption.TopDirectoryOnly);
                var branchNamesList = new List<string>();
                foreach (string branch in dirs)
                {
                    branchNamesList.Add(branch.Substring(branch.LastIndexOf('\\') + 1));
                }
                chkLBoxBranches.Items.Clear();
                chkLBoxBranches.Items.AddRange(branchNamesList.ToArray());
                chkLBoxBranches.Show();
            }
            else
            {
                lblSeverPath.Text = ("Server not found");
                chkLBoxBranches.Hide();
            }
            //This grabs the branch names from the settings and sets them as the check box names
            BindingList<string> boundBranches = new BindingList<string>(Properties.Settings.Default.branchNames.Cast<string>().ToArray());
            int i = 0;
            foreach (string branch in boundBranches)
            {
                if (branch.Substring(branch.LastIndexOf(',') + 1) == "Checked")
                {
                    chkLBoxBranches.SetItemChecked(i, true);
                }
                else
                {
                    chkLBoxBranches.SetItemChecked(i, false);
                }
                i += 1;
            }
            Properties.Settings.Default.Save();
            chkLBoxBranches.Height = chkLBoxBranches.Items.Count * (chkLBoxBranches.ItemHeight + 2);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //Settings text to what they should be
            lblTitle.Text = Properties.Resources.ResourceManager.GetString("frmTitle");
            lblSeverPath.Text = Properties.Settings.Default.serverPath;
            lblDate.Text = DateTime.Now.ToString("MMMM") + " - " + DateTime.Now.Year.ToString();
            updateBranchList();
        }

        //Changes the directory location of the server
        private void btnServerLocation_Click(object sender, EventArgs e)
        {
            DialogResult result = folderDialogServerPath.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                Properties.Settings.Default.serverPath = folderDialogServerPath.SelectedPath;
                lblSeverPath.Text = Properties.Settings.Default.serverPath;
                updateBranchList();
            }
        }

        //Updates the settings file when items are checked / unchecked
        private void chkLBoxBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.branchNames.Clear();
            foreach (object itemCheck in chkLBoxBranches.Items)
            {
                Properties.Settings.Default.branchNames.Add(itemCheck.ToString() + "," + chkLBoxBranches.GetItemCheckState(chkLBoxBranches.Items.IndexOf(itemCheck)).ToString());
            }
            Properties.Settings.Default.Save();
        }
    }
}
