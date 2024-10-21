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

            //RemotingNet.WinApp.Form1 formRemotingNet = new RemotingNet.WinApp.Form1();
            //formRemotingNet.WindowState = FormWindowState.Minimized;
            //formRemotingNet.Show();
            //formRemotingNet.Visible = false;

            WCF.WinApp.Form1 formWCF = new WCF.WinApp.Form1();
            formWCF.WindowState = FormWindowState.Minimized;
            formWCF.Show();
            formWCF.Visible = false;

            Application.Run(new FrmMenu());
        }
    }
}
