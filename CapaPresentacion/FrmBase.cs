using BimManager.Entidad;
using BimManager.ILogica;
using System.Windows.Forms;

namespace BimManager.Client.WipApp
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
