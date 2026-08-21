using System;
using System.Collections.Generic;
using System.Text;

namespace CopyStand
{
    /// <summary>
    /// Handles the application's global settings.
    /// </summary>
    public static class Settings
    {
        private static int _historyLimit;
        private static SyncDirection _syncDirection;

        /// <summary>
        /// Initializes the settings with registry data, or defaults if registry
        /// data is not available.
        /// </summary>
        static Settings()
        {
            _historyLimit = 50;
            _syncDirection = SyncDirection.Bidirectional;
        }

        /// <summary>
        /// Maximum number of clipboard items in our history list.
        /// </summary>
        public static int HistoryLimit
        {
            get { return _historyLimit; }
            set { _historyLimit = value; }
        }

        /// <summary>
        /// Synchronization direction for the background synchronization server.
        /// </summary>
        public static SyncDirection SyncDirection
        {
            get { return _syncDirection; }
            set { _syncDirection = value; }
        }
    }

    /// <summary>
    /// Synchronization direction for the background synchronization server.
    /// </summary>
    public enum SyncDirection
    {
        Bidirectional = 0,
        ReceiveOnly = 1,
        TransmitOnly = 2
    }
}
