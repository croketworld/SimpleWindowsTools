namespace DummyExe
{
    /// <summary>
    /// This is a simple console application that logs the current timestamp and the path of the executing assembly to a log file in the user's Downloads folder, then exits the application. 
    /// </summary>
    internal sealed class Program
    {

#pragma warning disable IDE0044 // Agregar modificador de solo lectura
        private static string logPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\log.txt";

        private static string logEntryTemplate = "Timestamp: {0}, Path: {1}";

#pragma warning restore IDE0044 // Agregar modificador de solo lectura


        /// <summary>
        /// The main entry point of the application. It logs the current timestamp and the path of the executing assembly to a log file in the user's Downloads folder, then exits the application.  
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            string path = Environment.ProcessPath ?? System.Reflection.Assembly.GetExecutingAssembly().Location;
#pragma warning disable CA1863 // Use "CompositeFormat"
            string logEntry = string.Format(System.Globalization.CultureInfo.InvariantCulture, logEntryTemplate, DateTime.Now, path);
#pragma warning restore CA1863 // Use "CompositeFormat"
            File.AppendAllText(logPath, logEntry + Environment.NewLine);        
            Environment.Exit(0);
        }
    }
}