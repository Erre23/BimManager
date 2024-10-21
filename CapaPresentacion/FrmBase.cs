using CapaILogica;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmBase : Form
    {
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
