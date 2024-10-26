using System.Windows.Forms;

namespace BimManager.Client.WipApp.Controls
{
    public class CustomTextBox : TextBox
    {
        public enum TipoInput
        {
            Todo,
            SoloNumeros,
            NumerosYLetras
        }

        private TipoInput _tipoCaracteres = TipoInput.Todo;

        public TipoInput TipoCaracteres
        {
            get { return _tipoCaracteres; }
            set { _tipoCaracteres = value; }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (!char.IsControl(e.KeyChar))
            {
                if (TipoCaracteres == TipoInput.SoloNumeros && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if (TipoCaracteres == TipoInput.NumerosYLetras && !char.IsLetterOrDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
