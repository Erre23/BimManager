using System.Drawing;
using System.Runtime.Serialization;

namespace BimManager.Entidad
{
    [DataContract]
    public class PresupuestoEstado
	{
        [DataMember]
        public byte PresupuestoEstadoID { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        public Color Color
        {
            get
            {
                if (PresupuestoEstadoID == 1) return Color.SkyBlue;
                else if (PresupuestoEstadoID == 2) return Color.Red;
                else if (PresupuestoEstadoID == 3) return Color.Khaki;
                else if (PresupuestoEstadoID == 4) return Color.LightGreen;
                else return SystemColors.Control;
            }
        }
    }
}
