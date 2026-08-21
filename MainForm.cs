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
            SetSyncDirectionComboBox(Settings.SyncDirection);

            // Register clipboard manager event handlers.
            manager.ClipsListUpdated += OnClipsListUpdated;
            manager.ServerStarted += OnServerStarted;
            manager.ServerStopped += OnServerStopped;

            // Initialize the clipboard manager with the current clipboard contents.
            manager.StartSyncServer();
            try { manager.AddItem(Clip.FromClipboard()); } catch (Exception) { }
        }

        /// <summary>
        /// Copies the currently selected item data, if there is one, to the clipboard.
        /// </summary>
        public void CopySelectedItem()
        {
            // Do we have anything selected to put on the clipboard?
            if (lstClips.SelectedIndices.Count == 0)
                return;

            // Copy the currently selected item to the clipboard;
            Clip clip = manager.Clips[lstClips.SelectedIndices[0]];
            System.Windows.Forms.Clipboard.SetText(clip.Data);
        }

        /// <summary>
        /// Sets the selected item in the synchronization direction ComboBox in
        /// the ToolStrip.
        /// </summary>
        /// <param name="direction">Synchronization direction.</param>
        public void SetSyncDirectionComboBox(SyncDirection direction)
        {
            switch (direction)
            {
                case SyncDirection.Bidirectional:
                    cmbSyncDirection.SelectedIndex = 0;
                    break;
                case SyncDirection.ReceiveOnly:
                    cmbSyncDirection.SelectedIndex = 1;
                    break;
                case SyncDirection.TransmitOnly:
                    cmbSyncDirection.SelectedIndex = 2;
                    break;
                default:
                    throw new Exception("Unknown sync direction index");
            }
        }

        #region Event Handlers

        /// <summary>
        /// Event that happens whenever the clipboard manager history gets updated.
        /// </summary>
        /// <param name="sender">The clipboard manager object.</param>
        /// <param name="e">Ignored. Always null.</param>
        private void OnClipsListUpdated(object sender, EventArgs e)
        {
            if (lstClips.InvokeRequired)
            {
                lstClips.Invoke((MethodInvoker)delegate
                {
                    if (lstClips.VirtualListSize == manager.Clips.Count)
                        lstClips.VirtualListSize = 0;
                    lstClips.VirtualListSize = manager.Clips.Count;
                    lstClips.Refresh();
                });
            }
            else
            {
                if (lstClips.VirtualListSize == manager.Clips.Count)
                    lstClips.VirtualListSize = 0;
                lstClips.VirtualListSize = manager.Clips.Count;
                lstClips.Refresh();
            }
        }

        private void OnServerStarted(object sender, EventArgs e)
        {
            btnStartServer.Enabled = false;
            btnStopServer.Enabled = true;
            lblServerStatus.Text = "Sync Server Running";
        }

        private void OnServerStopped(object sender, EventArgs e)
        {
            btnStartServer.Enabled = true;
            btnStopServer.Enabled = false;
            lblServerStatus.Text = "Sync Server Stopped";
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
            manager.StartSyncServer();
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            manager.StopSyncServer();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            CopySelectedItem();
        }

        private void lstClips_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CopySelectedItem();
        }

        private void clipboardMonitor_ClipboardChanged(object sender, ClipboardChangedEventArgs e)
        {
            manager.HandleClipboardChanged(e.DataObject);
        }

        private void cmbSyncDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbSyncDirection.SelectedIndex)
            {
                case 0:
                    Settings.SyncDirection = SyncDirection.Bidirectional;
                    break;
                case 1:
                    Settings.SyncDirection = SyncDirection.ReceiveOnly;
                    break;
                case 2:
                    Settings.SyncDirection = SyncDirection.TransmitOnly;
                    break;
                default:
                    throw new Exception("Unknown sync direction index selected");
            }
        }

        #endregion
    }
}
