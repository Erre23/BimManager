using System.Runtime.Serialization;

namespace CapaEntidad
{
    [DataContract]
    public class Plan
    {
        [DataMember]
        public byte PlanID { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public decimal CostoPorM2 { get; set; }

        [DataMember]
        public byte PlazoDiasMinimo { get; set; }

        [DataMember]
        public byte PlazoDiasMaximo { get; set; }

        [DataMember]
        public bool Activo { get; set; }

        public string PlazoRango
        {
            get { return $"{PlazoDiasMinimo} - {PlazoDiasMaximo}"; }
        }
    }
}
