using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Cryptography;
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
        public Clip(string data) : this(DateTime.Now, data, Environment.MachineName) { }

        /// <summary>
        /// Creates a new clipboard data object from data contained within the system's clipboard.
        /// </summary>
        /// <returns>Clip object with data from clipboard.</returns>
        public static Clip FromClipboard()
        {
            return FromClipboard(System.Windows.Forms.Clipboard.GetDataObject());
        }

        /// <summary>
        /// Creates a new clipboard data object from data contained within the system's clipboard.
        /// </summary>
        /// <returns>Clip object with data from clipboard.</returns>
        public static Clip FromClipboard(IDataObject data)
        {
            // Do we have textual data available?
            if (!data.GetDataPresent("System.String"))
                throw new Exception("No textual data available in the clipboard");

            // Get the string from the data and ensure there is something there for us.
            string str = (string)data.GetData("System.String");
            if ((str == null) || (str.Length == 0))
                throw new Exception("No text contained in the data from the clipboard");

            return new Clip(str);
        }

        /// <summary>
        /// Creates a Clip object from a previous object that was turned into a
        /// serialized string.
        /// </summary>
        /// <param name="serialized">Clip object represented as a string.</param>
        /// <returns>Clip object representing the original string.</returns>
        public static Clip FromSerializedString(string serialized)
        {
            // Split the serialized string into its parts.
            string[] parts = serialized.Split('\t');

            // Convert the UNIX timestamp to a DateTime object.
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(double.Parse(parts[0])).ToLocalTime();

            return new Clip(dt, parts[3], parts[1]);
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
        /// Encodes the object into a string that can be used to serialize and
        /// deserialize this object.
        /// </summary>
        /// <returns>String-encoded version of this object.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append((int)Timestamp.ToUniversalTime().Subtract(
                new DateTime(1970, 1, 1)).TotalSeconds);
            sb.Append("\t");
            sb.Append(Device);
            sb.Append("\t");
            sb.Append(Encoding.UTF8.GetByteCount(Data));
            sb.Append("\t");
            sb.Append(Data);

            return sb.ToString();
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
