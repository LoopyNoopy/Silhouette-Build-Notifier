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
using Microsoft.Toolkit.Uwp.Notifications;
using System.Windows.UI.Notifications;

namespace SBuildNotifierV2
{
    public partial class FrmMain : Form
    {
        public List<FileSystemWatcher> buildWatchers = new List<FileSystemWatcher>();

        public FrmMain()
        {
            InitializeComponent();
        }


        public static void StartWatchers()
        {
            string[] ArrayPaths = new string[2];
            List<FileSystemWatcher> watchers = new List<FileSystemWatcher>();
            ArrayPaths[0] = @"C:\WatcherTest";
            ArrayPaths[1] = @"C:\WatcherTest2"; 

        int i = 0;
            foreach (String String in ArrayPaths)
            {
                watchers.Add(MyWatcherFatory(ArrayPaths[i]));
                i++;
            }

            foreach (FileSystemWatcher watcher in watchers)
            {
                watcher.EnableRaisingEvents = true; ;
                Console.WriteLine("Watching this folder {0}", watcher.Path);
                i++;
            }

        }
        public static FileSystemWatcher MyWatcherFatory(string path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(path);
            watcher.Changed += Watcher_Created;
            watcher.Created += Watcher_Created;
            watcher.Path = path;
            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;
            return watcher;
        }

        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            _ = new FileInfo(e.FullPath);
            //var notifications = Windows.UI.Notifications;
            Console.WriteLine("File Created!! :: {0}", e.FullPath);
        }

        private void updateWatcher()
        {
            //FileSystemWatcher branch = new FileSystemWatcher();
            foreach(var branch in chkLBoxBranches.Items)
            {
                if (chkLBoxBranches.GetItemCheckState(chkLBoxBranches.Items.IndexOf(branch)).ToString().Contains("Unchecked") != true)
                {
                    if(chkLBoxBranches.GetItemCheckState(chkLBoxBranches.Items.IndexOf(branch)).ToString().Contains("Indeterminate") != true)
                    {
                        //If the checkbox is checked - Create a watcher for it
                        
                        Console.WriteLine(branch + chkLBoxBranches.GetItemCheckState(chkLBoxBranches.Items.IndexOf(branch)).ToString());
                    }
                }
            }
        }


        private void checkLiveBranch()
        {
            if (Directory.Exists(Properties.Settings.Default.serverPath + "\\" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.ToString("MMMM")))
            {
                string[] liveDirectory = Directory.GetDirectories(@Properties.Settings.Default.serverPath + "\\" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.ToString("MMMM"), "b*", SearchOption.TopDirectoryOnly);
                if (!(liveDirectory == null))
                {
                    var liveBranchNames = new List<string>();
                    foreach (string branch in liveDirectory)
                    {
                        liveBranchNames.Add(branch.Substring(branch.LastIndexOf('\\') + 1));
                    }
                    //If the saved branches is not empty - add those which are new
                    if (!(Properties.Settings.Default.branchNames == null))
                    {
                        //Compare saved branches to live branches - add those it does not contain
                        var savedDirectory = new List<string>(Properties.Settings.Default.branchNames.Cast<string>().ToArray());
                        bool isThere = false;
                        foreach (string savedBranch in savedDirectory)
                        {
                            isThere = false;
                            foreach (string liveBranch in liveBranchNames)
                            {
                                if (savedBranch.Contains(liveBranch))
                                {
                                    isThere = true;
                                }
                            }
                            //If the branch is already in the saved branches remove it from the live branch names
                            if (isThere == true)
                            {
                                liveBranchNames.RemoveAll(b => b.Contains(savedBranch.Substring(0, savedBranch.IndexOf(","))));
                            }
                        }
                        //savedDirectory.AddRange(liveBranchNames);
                        liveBranchNames.Distinct().ToList();
                        foreach (string item in liveBranchNames)
                        {
                            Properties.Settings.Default.branchNames.Add(item.ToString() + "," + "Unchecked");
                        }
                        Properties.Settings.Default.Save();
                    }
                    chkLBoxBranches.Show();
                }
            }
            else
            {
                chkLBoxBranches.Hide();
            }
        }

        private void setCheckState()
        {
            //Grab the names of the branches and populates them in the box
            //To see if the directories still exist
            string[] liveDirectory = Directory.GetDirectories(@Properties.Settings.Default.serverPath + "\\" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.ToString("MMMM"), "b*", SearchOption.TopDirectoryOnly);
            var branches = new List<string>(Properties.Settings.Default.branchNames.Cast<string>().ToArray());
            var branchNames = new List<string>();
            foreach(string branch in branches)
            {
                branchNames.Add(branch.Substring(0, branch.IndexOf(",")));
            }
            chkLBoxBranches.Items.AddRange(branchNames.ToArray());
            //Checks to see the checked state and updates the check box
            int i = 0;
            bool exist = false;
            foreach (string branch in branches)
            {
                exist = false;
                if (branch.Contains("Unchecked") == true)
                {
                    chkLBoxBranches.SetItemChecked(i, false);
                }
                else
                {
                    chkLBoxBranches.SetItemChecked(i, true);
                }
                foreach(string liveBranch in liveDirectory)
                {
                    if (liveBranch.Contains(branch.Substring(0, branch.IndexOf(",")))==true)
                    {
                        exist = true;
                    }
                }
                if(exist == false)
                {
                    chkLBoxBranches.SetItemCheckState(i, CheckState.Indeterminate);
                }
                i += 1;
            }
            chkLBoxBranches.Show();
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
            checkLiveBranch();
            setCheckState();
            startUpCheck();
            StartWatchers();
        }

        //Changes the directory location of the server
        private void btnServerLocation_Click(object sender, EventArgs e)
        {
            DialogResult result = folderDialogServerPath.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                Properties.Settings.Default.serverPath = folderDialogServerPath.SelectedPath;
                lblSeverPath.Text = Properties.Settings.Default.serverPath;
                checkLiveBranch();
            }
        }

        //Updates the settings file when items are checked / unchecked
        private void chkLBoxBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.branchNames.Clear();
            foreach (object itemCheck in chkLBoxBranches.Items)
            {
                Properties.Settings.Default.branchNames.Add(itemCheck.ToString() + "," + chkLBoxBranches.GetItemCheckState(chkLBoxBranches.Items.IndexOf(itemCheck)).ToString());
                updateWatcher();
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

        private void startUpCheck()
        {
            if (Properties.Settings.Default.runStartup == true)
            {
                btnStartup.Text = ("Startup Enabled");
                btnStartup.BackColor = Color.FromArgb(255, 79, 178, 206);
                
            }
            else
            {
                btnStartup.Text = ("Startup Disabled");
                btnStartup.BackColor = Color.FromArgb(255, 208, 106, 78);
            }
        }

        private void btnNotify_Click(object sender, EventArgs e)
        {
            var toastContent = new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
            {
                new AdaptiveText()
                {
                    Text = "New build of XXX is available"
                },
                new AdaptiveText()
                {
                    Text = "XXX has just been been created, would you like to open the build folder?"
                }
            },
                        AppLogoOverride = new ToastGenericAppLogo()
                        {
                            Source = @"C:\Users\dburgess\Pictures\silhouetteLogo.png",
                            HintCrop = ToastGenericAppLogoCrop.Circle
                        }
                    }
                },
                Actions = new ToastActionsCustom()
                {
                    Buttons =
        {
            new ToastButton("Yes", "action=acceptFriendRequest&userId=49183")
            {
                ActivationType = ToastActivationType.Background
            },
            new ToastButton("No", "action=declineFriendRequest&userId=49183")
            {
                ActivationType = ToastActivationType.Background
            }
        }
                }
            };

            // Create the toast notification
            var toastNotif = new ToastNotification(toastContent.GetContent());

            // And send the notification
            ToastNotificationManager.CreateToastNotifier().Show(toastNotif);
        }
    }
}
