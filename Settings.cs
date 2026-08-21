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

        /// <summary>
        /// Initializes the settings with registry data, or defaults if registry
        /// data is not available.
        /// </summary>
        static Settings()
        {
            _historyLimit = 50;
        }

        /// <summary>
        /// Maximum number of clipboard items in our history list.
        /// </summary>
        public static int HistoryLimit
        {
            get { return _historyLimit; }
            set { _historyLimit = value; }
        }
    }
}
