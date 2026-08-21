namespace CopyStand
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lstClips = new System.Windows.Forms.ListView();
            this.colTimestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDevice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblServerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnStartServer = new System.Windows.Forms.ToolStripButton();
            this.btnStopServer = new System.Windows.Forms.ToolStripButton();
            this.cmbSyncDirection = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.clipboardMonitor = new CopyStand.Clipboard.ClipboardMonitor();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstClips
            // 
            this.lstClips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstClips.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstClips.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTimestamp,
            this.colData,
            this.colDevice});
            this.lstClips.FullRowSelect = true;
            this.lstClips.GridLines = true;
            this.lstClips.HideSelection = false;
            this.lstClips.LabelWrap = false;
            this.lstClips.Location = new System.Drawing.Point(0, 25);
            this.lstClips.Margin = new System.Windows.Forms.Padding(0);
            this.lstClips.MultiSelect = false;
            this.lstClips.Name = "lstClips";
            this.lstClips.Size = new System.Drawing.Size(604, 317);
            this.lstClips.TabIndex = 0;
            this.lstClips.UseCompatibleStateImageBehavior = false;
            this.lstClips.View = System.Windows.Forms.View.Details;
            this.lstClips.VirtualMode = true;
            this.lstClips.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lstClips_RetrieveVirtualItem);
            this.lstClips.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstClips_MouseDoubleClick);
            // 
            // colTimestamp
            // 
            this.colTimestamp.Text = "Timestamp";
            this.colTimestamp.Width = 100;
            // 
            // colData
            // 
            this.colData.Text = "Copied Data";
            this.colData.Width = 404;
            // 
            // colDevice
            // 
            this.colDevice.Text = "Device";
            this.colDevice.Width = 100;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblServerStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 342);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(604, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "Status Strip";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(74, 17);
            this.lblServerStatus.Text = "Server Status";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartServer,
            this.btnStopServer,
            this.cmbSyncDirection,
            this.toolStripSeparator1,
            this.btnCopy});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(604, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "Tool Strip";
            // 
            // btnStartServer
            // 
            this.btnStartServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStartServer.Image = ((System.Drawing.Image)(resources.GetObject("btnStartServer.Image")));
            this.btnStartServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(23, 22);
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // btnStopServer
            // 
            this.btnStopServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStopServer.Image = ((System.Drawing.Image)(resources.GetObject("btnStopServer.Image")));
            this.btnStopServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(23, 22);
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // cmbSyncDirection
            // 
            this.cmbSyncDirection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSyncDirection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSyncDirection.Items.AddRange(new object[] {
            "Bidirectional",
            "Receive Only",
            "Transmit Only"});
            this.cmbSyncDirection.Name = "cmbSyncDirection";
            this.cmbSyncDirection.Size = new System.Drawing.Size(121, 25);
            this.cmbSyncDirection.ToolTipText = "Synchronization Direction";
            this.cmbSyncDirection.SelectedIndexChanged += new System.EventHandler(this.cmbSyncDirection_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(23, 22);
            this.btnCopy.Text = "Copy to Clipboard";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // clipboardMonitor
            // 
            this.clipboardMonitor.BackColor = System.Drawing.Color.Red;
            this.clipboardMonitor.Location = new System.Drawing.Point(177, 160);
            this.clipboardMonitor.Name = "clipboardMonitor";
            this.clipboardMonitor.Size = new System.Drawing.Size(77, 60);
            this.clipboardMonitor.TabIndex = 3;
            this.clipboardMonitor.Text = "Clipboard Monitor";
            this.clipboardMonitor.Visible = false;
            this.clipboardMonitor.ClipboardChanged += new System.EventHandler<CopyStand.Clipboard.ClipboardChangedEventArgs>(this.clipboardMonitor_ClipboardChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 364);
            this.Controls.Add(this.clipboardMonitor);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.lstClips);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Copy Stand";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstClips;
        private System.Windows.Forms.ColumnHeader colTimestamp;
        private System.Windows.Forms.ColumnHeader colData;
        private System.Windows.Forms.ColumnHeader colDevice;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblServerStatus;
        private System.Windows.Forms.ToolStripButton btnStartServer;
        private System.Windows.Forms.ToolStripButton btnStopServer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private Clipboard.ClipboardMonitor clipboardMonitor;
        private System.Windows.Forms.ToolStripComboBox cmbSyncDirection;
    }
}

