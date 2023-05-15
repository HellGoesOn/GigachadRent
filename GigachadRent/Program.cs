using System;
using System.IO;
using System.Windows.Forms;

namespace GigachadRent
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if(File.Exists("cfg.txt")) {
                string s = File.ReadAllText("cfg.txt");
                Models.Globals.SetServer(s);
            }
            else {
                File.Create("cfg.txt").Close();
                var war = @"DESKTOP-JB2KS99\SQLEXPRESS";
                File.WriteAllText("cfg.txt", war);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AuthForm());
        }
    }
}