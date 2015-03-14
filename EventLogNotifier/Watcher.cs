using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace EventLogNotifier
{
    /// <summary>
    /// Initializes a new instance of the EventLogNotifier.Watcher class.
    /// </summary>
    public class Watcher
    {
        /// <summary>
        /// Represents the type of event
        /// </summary>
        public enum EntryType
        {
            Error,
            Information,
            Warning
        }

        // The delegate that must be implemented
        public delegate void FilteredEntryWrittenEventHandler(string eventSource, string message, EntryType type);

        // Our event which will be fired when something we monitor is written to the Event Log
        public event FilteredEntryWrittenEventHandler EntryWritten;

        /// <summary>
        /// Construct the Watcher. Set up monitoring of the Event Log.
        /// </summary>
        public Watcher()
        {
            // For now we just monitor the Application log instance.
            EventLog eventLog = new EventLog("Application");

            // Subscribe to the EntryWritten event
            eventLog.EntryWritten += eventLog_EntryWritten;
            eventLog.EnableRaisingEvents = true;
        }

        /// <summary>
        /// An entry has been written to the Event Log.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void eventLog_EntryWritten(object sender, EntryWrittenEventArgs e)
        {
            // Translate the EntryType to something simpler.
            // The subscriber only wants to have a reference to us, not System.Diagnostics
            EntryType transformedEntryType;

            switch (e.Entry.EntryType)
            {
                case EventLogEntryType.Error:
                    transformedEntryType = EntryType.Error;
                    break;
                case EventLogEntryType.Warning:
                    transformedEntryType = EntryType.Warning;
                    break;
                default:
                    transformedEntryType = EntryType.Information;
                    break;
            }

            // Fire the event
            EntryWritten(e.Entry.Source, e.Entry.Message, transformedEntryType);
        }

    }
}
