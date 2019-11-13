using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Silhouette_Build_Notifier_CSharp
{
    public partial class FrmNotifierUI : Form
    {
        public FrmNotifierUI()
        {
            InitializeComponent();
        }

        private void FrmNotifierUI_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("MMM") + " " + DateTime.Now.Year.ToString();
        }
    }
}
