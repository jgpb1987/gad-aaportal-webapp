using gad.admin.app.Settings;

namespace gad.admin.app
{
    internal static class Program
    {
        public static AppSettingsRoot Settings { get; private set; } = new();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            Settings = AppSettingsLoader.Load();
            ApplicationConfiguration.Initialize();
            Application.Run(new CargaMasiva());
        }
    }
}