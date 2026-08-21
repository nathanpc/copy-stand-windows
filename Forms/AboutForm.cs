using CopyStand.Properties;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CopyStand.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            // Dynamically update some parts of the dialog.
            lblAppName.Text = Application.ProductName + " v" + Application.ProductVersion;
        }

        /// <summary>
        /// Opens a website using the system's default browser.
        /// </summary>
        /// <param name="url">URL to be opened by the browser.</param>
        public void OpenWebsite(string url)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo(url);
            psInfo.UseShellExecute = true;
            Process.Start(psInfo);
        }

        private void btnSourceCode_Click(object sender, EventArgs e)
        {
            OpenWebsite(Resources.CodeRepoWebsite);
        }

        private void btnDevWebsite_Click(object sender, EventArgs e)
        {
            OpenWebsite(Resources.DeveloperWebsite);
        }
    }
}
