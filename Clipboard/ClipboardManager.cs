using System;
using System.Collections.Generic;
using System.Text;

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
        public void Append(Clip clip)
        {
            Clips.Add(clip);
            ClipsListUpdated(this, null);
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
