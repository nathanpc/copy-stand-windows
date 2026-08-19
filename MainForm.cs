using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CopyStand.Clipboard;

namespace CopyStand
{
    /// <summary>
    /// Main form of our application.
    /// </summary>
    public partial class MainForm : Form
    {
        public ClipboardManager manager;

        /// <summary>
        /// Initializes the main form of the application.
        /// </summary>
        /// <param name="clipboardManager">Shared instance of the clipboard manager.</param>
        public MainForm(ClipboardManager clipboardManager)
        {
            manager = clipboardManager;
            InitializeComponent();
            manager.ClipsListUpdated += OnClipsListUpdated;

            manager.Append(new Clip("A thing!"));
        }

        /// <summary>
        /// Event that happens whenever the clipboard manager history gets updated.
        /// </summary>
        /// <param name="sender">The clipboard manager object.</param>
        /// <param name="e">Ignored. Always null.</param>
        private void OnClipsListUpdated(object sender, EventArgs e)
        {
            lstClips.VirtualListSize = manager.Clips.Count;
        }

        /// <summary>
        /// Event that happens whenever the ListView needs to show an item from
        /// the clipboard manager.
        /// </summary>
        /// <param name="sender">Control that fired the event.</param>
        /// <param name="e">Virtual list event arguments.</param>
        private void lstClips_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = manager.Clips[e.ItemIndex].ToListViewItem();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            // TODO: Actually start the server.
            lblServerStatus.Text = "Server Running";
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            // TODO: Actually stop the server.
            lblServerStatus.Text = "Server Stopped";
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            // TODO: Copy the currently selected item to the clipboard.
        }
    }
}
