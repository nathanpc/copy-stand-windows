using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CopyStand.Clipboard
{
    /// <summary>
    /// Data object containing an instance of a clipboard data copied event.
    /// </summary>
    public class Clip
    {
        private DateTime _timestamp;
        private string _data;
        private string _device;

        /// <summary>
        /// Constructs a brand new clipboard data object with all parameters.
        /// </summary>
        /// <param name="timestamp">Timestamp of when the copy happened.</param>
        /// <param name="data">Data that was copied to the clipboard.</param>
        /// <param name="device">The device that originally copied the data to its clipboard.</param>
        public Clip(DateTime timestamp, string data, string device)
        {
            this._timestamp = timestamp;
            this._data = data;
            this._device = device;
        }

        /// <summary>
        /// Constructs a brand new clipboard data object that was copied by ourselves, right now.
        /// </summary>
        /// <param name="data">Data that was copied to the clipboard.</param>
        public Clip(string data) : this(DateTime.Now, data, "localhost") {}

        /// <summary>
        /// Creates a new clipboard data object from data contained within the system's clipboard.
        /// </summary>
        /// <returns>Clip object with data from clipboard.</returns>
        public static Clip FromClipboard()
        {
            if (!System.Windows.Forms.Clipboard.ContainsText())
                throw new Exception("Data in clipboard does not contain text");

            return new Clip(System.Windows.Forms.Clipboard.GetText());
        }

        /// <summary>
        /// Creates a new clipboard data object from data contained within the system's clipboard.
        /// </summary>
        /// <returns>Clip object with data from clipboard.</returns>
        public static Clip FromClipboard(IDataObject data)
        {
            if (!data.GetDataPresent("System.String"))
                throw new Exception("No textual data available in clipboard");

            return new Clip((string)data.GetData("System.String"));
        }

        /// <summary>
        /// Converts the cliboard data object into a ListView item.
        /// </summary>
        /// <returns>ListViewItem representing this clipboard item.</returns>
        public ListViewItem ToListViewItem()
        {
            return new ListViewItem(new string[] { Timestamp.ToLongTimeString(), Data, Device });
        }

        /// <summary>
        /// When the clipboard event happened.
        /// </summary>
        public DateTime Timestamp
        {
            get { return this._timestamp; }
            set { this._timestamp = value; }
        }

        /// <summary>
        /// Data that was copied to the clipboard.
        /// </summary>
        public string Data
        {
            get { return this._data; }
            set { this._data = value; }
        }

        /// <summary>
        /// Device that originally copied the data to its clipboard.
        /// </summary>
        public string Device
        {
            get { return this._device; }
            set { this._device = value; }
        }
    }
}
