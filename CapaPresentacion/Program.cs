using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            WCF.WinApp.Form1 formWCF = new WCF.WinApp.Form1();
            formWCF.WindowState = FormWindowState.Minimized;
            formWCF.Show();
            formWCF.Visible = true;

            Application.Run(new FrmMenu());
        }
    }
}
