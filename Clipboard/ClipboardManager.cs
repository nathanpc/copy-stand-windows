using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CopyStand.Clipboard
{
    /// <summary>
    /// Manages the clipboard and its history internally in the application.
    /// </summary>
    public class ClipboardManager
    {
        private List<Clip> _clips;
        private UdpClient udp;
        private Thread syncThread;

        /// <summary>
        /// Event that is fired whenever our internal history gets updated.
        /// </summary>
        public event EventHandler ClipsListUpdated;

        /// <summary>
        /// Default Copy Stand broadcast port.
        /// </summary>
        public static int ServerPort = 1288;

        /// <summary>
        /// Initializes the clipboard manager.
        /// </summary>
        public ClipboardManager()
        {
            _clips = new List<Clip>();

            // Setup the server socket.
            udp = new UdpClient();
            udp.Client.Bind(new IPEndPoint(IPAddress.Any, ServerPort));

            // Setup synchronization server thread.
            syncThread = new Thread(SynchronizationThread);
            syncThread.SetApartmentState(ApartmentState.STA);
        }

        /// <summary>
        /// Appends a new item to the clipboard items list.
        /// </summary>
        /// <param name="clip">Clipboard item to be added to the list.</param>
        /// <param name="broadcast">Should we broadcast this update over the network?</param>
        public void AddItem(Clip clip, bool broadcast)
        {
            // Update our internal history of clips.
            Clips.Insert(0, clip);
            // TODO: Drop older items if needed.
            ClipsListUpdated(this, null);

            // Broadcast the update over the network.
            if (broadcast)
                BroadcastUpdate(clip);
        }

        /// <summary>
        /// Appends a new item to the clipboard items list and broadcast the
        /// change over the network.
        /// </summary>
        /// <param name="clip">Clipboard item to be added to the list.</param>
        public void AddItem(Clip clip)
        {
            AddItem(clip, true);
        }

        /// <summary>
        /// Broadcasts an updated clipboard item over the network.
        /// </summary>
        /// <param name="clip">Clip object to be broadcast over the network.</param>
        public void BroadcastUpdate(Clip clip)
        {
            byte[] buf = Encoding.UTF8.GetBytes(clip.ToString());
            udp.Send(buf, buf.Length, "255.255.255.255", ServerPort);
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
                // Get clipboard data and check if it's something we already have.
                Clip clip = Clip.FromClipboard(data);
                if ((clip.Data.Length == 0) || (clip.Data == Clips[0].Data))
                    return false;

                // Add clip to our history.
                AddItem(clip);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Starts up the background synchronization server.
        /// </summary>
        public void StartSyncServer()
        {
            syncThread.Start();
        }

        /// <summary>
        /// Stops the background synchronization server.
        /// </summary>
        public void StopSyncServer()
        {
            syncThread.Abort();
        }

        /// <summary>
        /// Background synchronization thread function.
        /// </summary>
        private void SynchronizationThread()
        {
            IPEndPoint remote = new IPEndPoint(0, 0);
            while (true)
            {
                // Receive broadcasted clipboard data.
                byte[] recv = udp.Receive(ref remote);

                // Ignore transmissions from ourselves.
                if (!IsLocalhost(remote.Address))
                {
                    string data = Encoding.UTF8.GetString(recv);
                    System.Diagnostics.Debug.WriteLine(data);

                    // Add to our clips history and update the system's clipboard.
                    Clip clip = Clip.FromSerializedString(data);
					AddItem(clip, false);
                    System.Windows.Forms.Clipboard.SetText(clip.Data);
                }
            }
        }

        /// <summary>
        /// Checks if an IP address corresponds to ourselves.
        /// </summary>
        /// <param name="remote">IP address to be checked.</param>
        /// <returns>True if the IP address corresponds to ourselves, false otherwise.</returns>
        private static bool IsLocalhost(IPAddress remote)
        {
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork &&
                            remote.Equals(ip.Address))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
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
