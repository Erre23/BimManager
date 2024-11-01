using System;

namespace BimManager.Sunat.Entidad.RepresentacionImpresa
{
    [Serializable]
    public class ComprobanteElectronico_Detalle
    {
        public int Item { get; set; }


        public string Codigo { get; set; }


        public string Descripcion { get; set; }


        public string UnidadDeMedida { get; set; }


        public decimal Cantidad { get; set; }


        public decimal PrecioUnitario { get; set; }


        public decimal Importe { get; set; }
    }
}
