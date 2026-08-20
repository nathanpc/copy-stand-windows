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
        private Thread watcherThread;

        public event EventHandler ClipsListUpdated;

        /// <summary>
        /// Initializes the clipboard manager.
        /// </summary>
        public ClipboardManager()
        {
            _clips = new List<Clip>();
            watcherThread = new Thread(ClipboardWatcherThread);
        }

        /// <summary>
        /// Checks if the clipboard has a new item for us.
        /// </summary>
        /// <returns>True if the clipboard has been updated, false otherwise.</returns>
        public bool ClipboardWasUpdated()
        {
            // Do we have any piece of text to check for?
            if (!System.Windows.Forms.Clipboard.ContainsText())
                return false;

            // Check if the current text in the clipboard is the same that we have.
            return System.Windows.Forms.Clipboard.GetText() != Clips[0].Data;
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
        /// Starts the clipboard watcher thread.
        /// </summary>
        public void StartWatcher()
        {
            watcherThread.Start();
        }

        /// <summary>
        /// Stops the clipboard watcher thread.
        /// </summary>
        public void StopWatcher()
        {
            watcherThread.Abort();
        }

        /// <summary>
        /// Thread function responsible for monitoring the system clipboard for changes.
        /// </summary>
        /// <param name="obj">Ignored.</param>
        private void ClipboardWatcherThread(object obj) {
            while (true)
            {
                if (ClipboardWasUpdated())
                    AddItem(Clip.FromClipboard());

                Thread.Sleep(1000);
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
