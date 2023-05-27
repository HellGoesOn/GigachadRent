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
                string[] s = File.ReadAllText("cfg.txt").Split(Environment.NewLine);
                Models.Globals.SetServer(s[0].Replace(Environment.NewLine, ""));
                Models.Globals.BackupPath = s[1].Replace(Environment.NewLine, "");

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