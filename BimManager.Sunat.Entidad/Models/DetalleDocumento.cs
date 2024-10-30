using BimManager.Sunat.Entidad.Constantes;
using System;

namespace BimManager.Sunat.Entidad.Models
{
    [Serializable]
    public class DocumentoElectronicoDetalle
    {
        /// <summary>
        /// Numero de orden del detalle o item ancho maximo de 3 caracteres
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Codigo del item del contribuyente, no es obligatorio este campo
        /// </summary>
        public string CodigoItem { get; set; }


        /// <summary>
        /// Unidad de medida internacional del item, por defecto es NIU=UNIDAD, usar clase Ee.FacturaElectronica.Constantes.Catalogo_03_TipoUnidadDeMedida
        /// </summary>
        public string UnidadMedida { get; set; }


        /// <summary>
        /// Cantidad del item Formato Decimal (12, 3)
        /// </summary>
        public decimal Cantidad { get; set; }


        /// <summary>
        /// servicio prestado, bien vendido o cedido en uso, indicando las características, ancho maximo de 250 caracteres
        /// </summary>
        public string Descripcion { get; set; }


        /// <summary>
        /// Precio de venta unitario del item, valor no incluye igv, Fomato decimal (12,2)
        /// </summary>
        public decimal PrecioUnitario { get; set;}


        /// <summary>
        /// Precio referencial del item, se coloca lo que se debe cobrar por objeto del item (precio unitario + impuestos), Formato decimal (12,2)
        /// </summary>
        public decimal PrecioReferencial { get; set; }


        /// <summary>
        /// Monto del igv q afecta al item (precio unitario * Cantidad) * Igv
        /// </summary>
        public decimal Impuesto { get; set; }


        /// <summary>
        /// No se usa este campo
        /// </summary>
        public decimal ImpuestoSelectivo { get; set; }



        /// <summary>
        /// NO se usa este campo
        /// </summary>
        public decimal OtroImpuesto { get; set; }



        /// <summary>
        /// Monto total del Item, es el resultado de (multiplicar cantidad * precio unitario) - no incluye impuestos
        /// </summary>
        public decimal TotalVenta { get; set; }


        /// <summary>
        /// Se usa para indicar que el precio unitario esta afecto a IGV, Por Defecto es 01=PrecioUnitario_IncluyeIGV,   usar la clase Ee.FacturaElectronica.Constantes.Catalogo_16_TipoPrecioVentaUnitario.PrecioUnitario_IncluyeIGV
        /// </summary>
        public string TipoPrecio { get; set; }


        /// <summary>
        /// Sirve para indicar que el importe del item esta afecto a Igv Por Defecto es 10=Gravada_OperacionOnerosa,  usar la clase Ee.FacturaElectronica.Constantes.Catalogo_07_TipoAfectacionIgv.Gravada_OperacionOnerosa
        /// </summary>
        public string TipoAfectacionIgv { get; set; }


        /// <summary>
        /// No se usa este campo
        /// </summary>
        public decimal Suma { get; set; }



        public DocumentoElectronicoDetalle()
        {
            Id = 1;
            UnidadMedida = Catalogo_03_TipoUnidadDeMedida.Unidad;
            TipoPrecio = Catalogo_16_TipoPrecioVentaUnitario.PrecioUnitario_IncluyeIGV;
            TipoAfectacionIgv = Catalogo_07_TipoAfectacionIgv.Gravada_OperacionOnerosa;
        }
    }
}