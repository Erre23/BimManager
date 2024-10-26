using BimManager.Entidad;
using System;
using System.Windows.Forms;

namespace WCF.WinApp
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
                new WCF.Publicador().publicar(Convert.ToInt32(Configuracion.Puerto));
                LbWCF.Text = $"WCF Puerto: {Configuracion.Puerto}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
