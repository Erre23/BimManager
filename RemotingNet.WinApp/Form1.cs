using CapaEntidad;
using System;
using System.Windows.Forms;

namespace RemotingNet.WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                new RemotingNet.Publicador().publicar(Convert.ToInt32(Configuracion.Puerto));
                LbRemoting.Text = $"Remoting Net Puerto: {Configuracion.Puerto}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
