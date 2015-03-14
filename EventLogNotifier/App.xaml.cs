using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EventLogNotifier
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon notifyIcon;
        private Watcher watcher;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Create the notifyicon (it's a resource declared in NotifyIconResources.xaml
            notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");

            // Initialize the watcher and subscribe to the EntryWritten event.
            watcher = new Watcher();
            watcher.EntryWritten += watcher_EntryWritten;
        }

        /// <summary>
        /// Handles the EntryWritten event and shows a notification on the desktop
        /// </summary>
        /// <param name="eventSource">The name of the eventsource that will be shown in the notification</param>
        /// <param name="message">The message that will be shown in the notification</param>
        /// <param name="entryType">The type of icon that will be shown in the notification</param>
        void watcher_EntryWritten(string eventSource, string message, Watcher.EntryType entryType)
        {
            BalloonIcon icon;

            switch (entryType)
            {
                case Watcher.EntryType.Error:
                    icon = BalloonIcon.Error;
                    break;
                case Watcher.EntryType.Warning:
                    icon = BalloonIcon.Warning;
                    break;
                default:
                    icon = BalloonIcon.Info;
                    break;
            }

            notifyIcon.ShowBalloonTip(eventSource, message, icon);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            notifyIcon.Dispose();
            base.OnExit(e);
        }
    }
}
