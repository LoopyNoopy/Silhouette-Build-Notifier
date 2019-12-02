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
using Microsoft.Win32;

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
            //Checks if the directory exists, if it does add the names to the checklistbox
            if(Directory.Exists(@Properties.Settings.Default.serverPath + "\\" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.ToString("MMMM")))
            {
                string[] dirs = Directory.GetDirectories(@Properties.Settings.Default.serverPath + "\\" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.ToString("MMMM"), "b*", SearchOption.TopDirectoryOnly);
                if(!(dirs == null))
                {
                    var branchNamesList = new List<string>();
                    foreach (string branch in dirs)
                    {
                        branchNamesList.Add(branch.Substring(branch.LastIndexOf('\\') + 1));
                    }
                    chkLBoxBranches.Items.Clear();
                    chkLBoxBranches.Items.AddRange(branchNamesList.ToArray());
                    //Checks all the names in the check box against the settings file to see which have already been checked
                    BindingList<string> boundBranches = new BindingList<string>(Properties.Settings.Default.branchNames.Cast<string>().ToArray());
                    int i = 0;
                    foreach (string branch in boundBranches)
                    {
                        if (branchNamesList.Contains(branch))
                        {
                            if (branch.Substring(branch.LastIndexOf(',') + 1) == "Checked")
                            {
                                chkLBoxBranches.SetItemChecked(i, true);
                            }
                            else
                            {
                                chkLBoxBranches.SetItemChecked(i, false);
                            }
                        }
                        else
                        {
                            //chkLBoxBranches.SetItemCheckState(i, CheckState.Indeterminate);
                        }
                        i += 1;
                    }
                }
                else
                {
                    lblSeverPath.Text = ("No branches have been made yet");
                }
                
                chkLBoxBranches.Show();
            }
            else
            {
                if(!(Directory.Exists(@Properties.Settings.Default.serverPath + "\\" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.ToString("MMMM"))))
                {
                    lblSeverPath.Text = ("Month not found");
                }
                else if((!(Directory.Exists(@Properties.Settings.Default.serverPath + "\\" + DateTime.Now.Year.ToString()))))
                {
                    lblSeverPath.Text = ("Year not found");
                }
                else
                {
                    lblSeverPath.Text = ("Server not found");
                }
                chkLBoxBranches.Hide();
            }

            Properties.Settings.Default.Save();
            chkLBoxBranches.Height = chkLBoxBranches.Items.Count * (chkLBoxBranches.ItemHeight + 2);
        }

        //Sets checkboxes / buttons to correct state on load
        private void FrmMain_Load(object sender, EventArgs e)
        {
            nIcoBNotifier.Visible = true;
            //Settings text to what they should be
            lblTitle.Text = Properties.Resources.ResourceManager.GetString("frmTitle");
            lblTitle.Left = (lblTitle.Parent.Width - lblTitle.Width) / 2;
            lblSeverPath.Text = Properties.Settings.Default.serverPath;
            lblDate.Text = DateTime.Now.ToString("MMMM") + " - " + DateTime.Now.Year.ToString();
            lblDate.Left = (lblDate.Parent.Width - lblDate.Width) / 2;
            updateBranchList();
            btnStatus();
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
                //Add / remove watcher
            }
            Properties.Settings.Default.Save();
        }

        //Functions which minimises to the systemtray icon
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            nIcoBNotifier.Visible = true;
        }

        //Function to show the UI when double clicking the systray
        private void nIcoBNotifier_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            nIcoBNotifier.Visible = false;
        }

        //Updates the startup setting when clicked
        private void btnStartup_Click(object sender, EventArgs e)
        {
            btnStatus();
        }

        //When toggled, adds / deletes registry key in startup reg
        private void btnStatus()
        {
            if (Properties.Settings.Default.runStartup == true)
            {
                Properties.Settings.Default.runStartup = false;
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.DeleteValue("Silhouette Build Notifier", false);
                }
                btnStartup.Text = ("Startup Disabled");
                btnStartup.BackColor = Color.FromArgb(255, 208, 106, 78);
            }
            else
            {
                Properties.Settings.Default.runStartup = true;
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.SetValue("Silhouette Build Notifier", "\"" + Application.ExecutablePath + "\"");
                }
                btnStartup.Text = ("Startup Enabled");
                btnStartup.BackColor = Color.FromArgb(255, 79, 178, 206);
            }
            Properties.Settings.Default.Save();
        }
    }
}
