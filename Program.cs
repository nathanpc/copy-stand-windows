using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CopyStand.Clipboard;

namespace CopyStand
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize the clipboard manager.
            ClipboardManager manager = new ClipboardManager();

            // Initialize the application.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(manager));
        }
    }
}
