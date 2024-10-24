using CapaEntidad;
using CapaILogica;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmBase : Form
    {

        protected ToolStripMenuItem _menu;
        protected Usuario _usuario;

        public FrmBase()
        {
            InitializeComponent();
        }

        protected RemoteObject ObjRemoteObject
        {
            get { return new RemoteObject(); }
        }
    }
}
