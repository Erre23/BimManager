using CapaEntidad;
using CapaLogica;
using CapaPresentacion.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private Usuario _usuarioActual { get; set; }
        public Usuario GetUsuarioActual { get { return _usuarioActual; } }

        private async void BnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
				if (string.IsNullOrEmpty(TbUsername.Text))
				{
                    MessageBox.Show(this, "Olvidó ingresar un Username", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (string.IsNullOrEmpty(TbPassword.Text))
                {
                    MessageBox.Show(this, "Olvidó ingresar la contraseña", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var usuarioLogin = await LogUsuario.Instancia.UsuarioLogin(TbUsername.Text.Trim(), TbPassword.Text);
                if (usuarioLogin == null)
                {
                    MessageBox.Show(this, "Contraseña incorrecta", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!usuarioLogin.Activo)
                {
                    MessageBox.Show(this, "El usuario no se encuentra activo", "Un momento por favor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                
                if (usuarioLogin.CambioContrasena)
                {
                    /* NOTA: Esta pendiente el cambio de contraseña de forma obligatoria */
                }

                MessageBox.Show(this, $"Bienvenido {usuarioLogin.ApellidosNombres}");

                _usuarioActual = usuarioLogin;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Se produjo un error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void BnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
