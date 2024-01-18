namespace Pause_Windows_Update
{
    internal static class Program
    {
        /// <summary>
        /// AUTHOR: FASTCHEN
        /// WEBSITE: https://fastchen.com
        /// ProjectCrateTIME: 2024-01-18
        /// GITHUB: https://github.com/FastChen/Pause-Windows-Update
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}