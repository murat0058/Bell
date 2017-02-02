namespace Bell.Common.Logging
{
    /// <summary>
    /// Represents the importance of the log message
    /// </summary>
    public enum LogLevel
    {
        // Tracing information and debugging minutiae; generally only switched on in unusual situations
        Verbose = 0,

        // Internal control flow and diagnostic state dumps to facilitate pinpointing of recognised problems
        Debug,

        // Events of interest or that have relevance to outside observers; the default enabled minimum logging level
        Information,

        // Indicators of possible issues or service/functionality degradation
        Warning,

        // Indicating a failure within the application or connected system
        Error,

        // Critical errors causing complete failure of the application
        Fatal
    }
}
