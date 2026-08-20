// Source - https://stackoverflow.com/a/1394225
// Posted by dbkk, modified by community. See post 'Timeline' for change history
// Retrieved 2026-08-20, License - CC BY-SA 2.5
// Modified by Nathan Campos <nathan@innoveworkshop.com>

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace CopyStand.Clipboard
{
    /// <summary>
    /// Clipboard monitor control.
    /// </summary>
    [DefaultEvent("ClipboardChanged")]
    public partial class ClipboardMonitor : Control
    {
        IntPtr nextClipboardViewer;

        /// <summary>
        /// Contructs the clipboard monitor control and sets ourselves up as a
        /// clipboard viewer.
        /// </summary>
        public ClipboardMonitor()
        {
            this.BackColor = Color.Red;
            this.Visible = false;

            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);
        }

        /// <summary>
        /// Event fired whenever the contents of the system's clipboard has changed.
        /// </summary>
        public event EventHandler<ClipboardChangedEventArgs> ClipboardChanged;

        /// <summary>
        /// Properly handles the deregistration of ourselves from the clipboard
        /// viewer chain.
        /// </summary>
        /// <param name="disposing">Are we disposing?</param>
        protected override void Dispose(bool disposing)
        {
            ChangeClipboardChain(this.Handle, nextClipboardViewer);
        }

        /// <summary>
        /// Overrides the window procedure to handle the clipboard-related events.
        /// </summary>
        /// <param name="m">Message received by the window procedure.</param>
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            // defined in winuser.h
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    OnClipboardChanged();
                    SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                case WM_CHANGECBCHAIN:
                    if (m.WParam == nextClipboardViewer)
                        nextClipboardViewer = m.LParam;
                    else
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        /// <summary>
        /// Fires the clipboard changed event to all listeners with the data
        /// object from the clipboard.
        /// </summary>
        void OnClipboardChanged()
        {
            try
            {
                IDataObject iData = System.Windows.Forms.Clipboard.GetDataObject();
                if (ClipboardChanged != null)
                {
                    ClipboardChanged(this, new ClipboardChangedEventArgs(iData));
                }

            }
            catch (Exception e)
            {
                // Swallow or pop-up, not sure
                // Trace.Write(e.ToString());
                MessageBox.Show(e.ToString());
            }
        }

        [DllImport("User32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        protected static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        protected static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
    }

    /// <summary>
    /// Event argument containing the data stored in the system's clipboard.
    /// </summary>
    public class ClipboardChangedEventArgs : EventArgs
    {
        public readonly IDataObject DataObject;

        public ClipboardChangedEventArgs(IDataObject dataObject)
        {
            DataObject = dataObject;
        }
    }
}
