using ColorsChanger.ChangerApp;

namespace ColorsChanger
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var changerApp = new App(new Form1());
            changerApp.Run();
            Application.Run(changerApp.GetForm());
        }
    }
}