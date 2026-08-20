using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CopyStand.Clipboard
{
    /// <summary>
    /// Manages the clipboard and its history internally in the application.
    /// </summary>
    public class ClipboardManager
    {
        private List<Clip> _clips;

        public event EventHandler ClipsListUpdated;

        /// <summary>
        /// Initializes the clipboard manager.
        /// </summary>
        public ClipboardManager()
        {
            _clips = new List<Clip>();
        }

        /// <summary>
        /// Appends a new item to the clipboard items list.
        /// </summary>
        /// <param name="clip">Clipboard item to be added to the list.</param>
        public void AddItem(Clip clip)
        {
            Clips.Insert(0, clip);
            // TODO: Drop older items if needed.
            ClipsListUpdated(this, null);
        }

        /// <summary>
        /// Handles changes to the clipboard automatically.
        /// </summary>
        /// <param name="data">Data object from the system's clipboard.</param>
        /// <returns>True if we had text in the clipboard and it was added to our
        /// history, false otherwise.</returns>
        public bool HandleClipboardChanged(IDataObject data)
        {
            try
            {
                AddItem(Clip.FromClipboard(data));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Clipboard items in our history.
        /// </summary>
        public List<Clip> Clips
        {
            get { return this._clips; }
        }
    }
}
