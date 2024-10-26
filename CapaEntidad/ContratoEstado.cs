using System.Drawing;
using System.Runtime.Serialization;

namespace BimManager.Entidad
{
    [DataContract]
    public class ContratoEstado
	{
        [DataMember]
        public byte ContratoEstadoID { get; set; }
        
        [DataMember]
        public string Nombre { get; set; }

        public Color Color
        {
            get
            {
                if (ContratoEstadoID == 1) return Color.SkyBlue;
                else if (ContratoEstadoID == 2) return Color.Red;
                else if (ContratoEstadoID == 3) return Color.Khaki;
                else if (ContratoEstadoID == 4) return Color.LightGreen;
                else return SystemColors.Control;
            }
        }
    }
}
