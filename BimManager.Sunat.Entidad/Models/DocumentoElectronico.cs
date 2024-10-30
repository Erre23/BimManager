using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BimManager.Sunat.Entidad.Models
{
    [Serializable]
    public class DocumentoElectronico 
    {
        /// <summary>
        /// Tipo de documento Sunat, por defecto es Factura, usar la clase Ee.FacturaElectronica.Constantes.Catalogo_01_TipoDocumento ancho fijo de 2 caracteres
        /// </summary>
        public string TipoDocumento { get; set; }


        /// <summary>
        /// Emisor del comprobante por defecto se cargan los datos de emtrafesa
        /// </summary>
        public Contribuyente Emisor { get; set; }


        /// <summary>
        /// Receptor del comprobante
        /// </summary>
        public Contribuyente Receptor { get; set; }


        /// <summary>
        /// Serie alfanumerica del comprobante electronico ejemplo: F001, B001
        /// </summary>
        public string Serie { get; set; }


        /// <summary>
        /// Correlativo del comprobante electronico
        /// </summary>
        public long Correlativo { get; set; }


        /// <summary>
        /// Retorna Serie y numero del comprobante ancho maximo de 13 caracteres (ejemplo B123-12345678)
        /// </summary>
        public string IdDocumento
        {
            get
            {
                string IdDocumento_ = "";

                if (Serie != null && Serie.Trim() != "")
                {
                    IdDocumento_ = Serie + "-" + Correlativo.ToString().PadLeft(8, Convert.ToChar("0"));
                }

                return IdDocumento_;
            } 
        }





        /// <summary>
        /// Fecha de emision el comprobante formato YYYY-MM-DD  ancho fijo de 10 caracteres
        /// </summary>
        public string FechaEmision { get; set; }


        /// <summary>
        /// Tipo de moneda sunat, Por defecto es PEN=Soles, usar la clase Ee.FacturaElectronica.Constantes.Catalogo_02_TipoMoneda ancho fijo de 3 caracteres
        /// </summary>
        public string Moneda { get; set; }

        
        /// <summary>
        /// Para montos que esten afectos a impuestos, Formato Decimal (12,2)
        /// </summary>
        public decimal Gravadas { get; set; }


        /// <summary>
        /// Para montos referenciales Formato Decimal (12,2)
        /// </summary>
        public decimal Gratuitas { get; set; }


        /// <summary>
        /// PAra montos que esten libres de impuestos Formato Decimal (12,2)
        /// </summary>
        public decimal Inafectas { get; set; }


        /// <summary>
        /// Para montos que esten libres de impuestos Formato Decimal (12,2)
        /// </summary>
        public decimal Exoneradas { get; set; }


        /// <summary>
        /// Para monto de descuento que se aplicara al monto de Gracadas Formato Decimal (12,2)
        /// </summary>
        public decimal DescuentoGlobal { get; set; }


        /// <summary>
        /// Es el monto calculado en base al campo Gravada Formato Decimal (12, 2)
        /// </summary>
        public decimal TotalIgv { get; set; }


        /// <summary>
        /// Es el monto del Impuesto Selectivo al Consumo Formato Decimal (12,2);
        /// </summary>
        public decimal TotalIsc { get; set; }


        /// <summary>
        /// Es el monto de otros impuestos Formato Decimal (12,2);
        /// </summary>
        public decimal TotalOtrosTributos { get; set; }


        /// <summary>
        /// Es el monto total del comprobante, luego de realizar la siguiente Operacion (Gravadas + Inafectas + Exoneradas - DescuentoGlobal + TotalIgv + TotalIsc + TotalOtrosTributos)
        /// </summary>
        public decimal TotalVenta { get; set; }


        /// <summary>
        /// Es en base al monto del campo TotalVenta 
        /// </summary>
        public string MontoEnLetras { get; set; }


        /// <summary>
        /// Tipo de operacion sunat, por defecto es 01=VentaInterna, usar la clase Ee.FacturaElectronica.Constantes.Catalogo_17_TipoOperacion
        /// </summary>
        public string TipoOperacion { get; set; }


        /// <summary>
        /// Porcentaje del Valor del Igv, por defecto es 18
        /// </summary>
        public decimal CalculoIgv { get; set; }


        /// <summary>
        /// Porcentaje del Valor del ISC, por defecto es 10
        /// </summary>
        public decimal CalculoIsc { get; set; }


        /// <summary>
        /// Porcentaje del valor de la Detraccion, por defecto es 4
        /// </summary>
        public decimal CalculoDetraccion { get; set; }


        /// <summary>
        /// Campo no usado
        /// </summary>
        public decimal MontoPercepcion { get; set; }


        /// <summary>
        /// Campo no usado
        /// </summary>
        public decimal MontoDetraccion { get; set; }


        /// <summary>
        /// Campo no usado
        /// </summary>
        public string TipoDocAnticipo { get; set; }


        /// <summary>
        /// Campo no usado
        /// </summary>
        public string DocAnticipo { get; set; }


        /// <summary>
        /// Campo no usado
        /// </summary>
        public string MonedaAnticipo { get; set; }


        /// <summary>
        /// Campo no usado
        /// </summary>
        public decimal MontoAnticipo { get; set; }


        /// <summary>
        /// Esta campo se usa para agregar datos adicionales al comprobante, usar la clase Ee.FacturaElectronica.Constantes.Catalogo_15_TipoOperacion
        /// </summary>
        public List<DatoAdicional> DatoAdicionales { get; set; }


        /// <summary>
        /// Este campo se usa para agregar datos adicionales al comprobante fuera de los datos minimos exigidos al comprobante
        /// </summary>
        public List<DatoAdicional> DatoAdicionales_Internos { get; set; }


        /// <summary>
        /// Este campo se usa cuando se va a emitir nota de credito o debito, contiene la lista de boletas o facturas a los que afectará la nota de credito o debito
        /// </summary>
        public List<DocumentoRelacionado> Relacionados { get; set; }


        /// <summary>
        /// Esta campo se usa cuando se va a emitir una boleta, factura, nota de credito o debiro, contiene la lista de items o detalle del comprobante a emitir
        /// </summary>
        public List<DocumentoElectronicoDetalle> Items { get; set; }


        /// <summary>
        /// Campo no usado
        /// </summary>
        public DatosGuia DatosGuiaTransportista { get; set; }


        /// <summary>
        /// Esta campo se usa cuando se va a emitir nota de credito o debito, contiene la lista de boletas o facturas a los que afectará la nota de credito o debito
        /// </summary>
        public List<Discrepancia> Discrepancias { get; set; }


        /// <summary>
        /// Variable para indicar que el archivo xml se ha generado
        /// </summary>
        public bool Generado { get; set; } 


        /// <summary>
        /// Variable para indicar que el archivo xml se ha enviado a SUNAT
        /// </summary>
        public bool Enviado { get; set; }


        /// <summary>
        /// Variable para guardar el Hash del resumen de la firma electronica que se deberá imprimir en la representacion impresa
        /// </summary>
        public string DigestValue { get; set; }


        /// <summary>
        /// Variable para guardar el comprobante elextronico en formato xml Base64String
        /// </summary>
        public string ComprobanteXml_Base64String { get; set; }


        /// <summary>
        /// Cuando el documento es una factura,  nota de credito o nota de debito relacionada a una factura este campo esta lleno con la CDR de respuesta de la SUNAT 
        /// </summary>
        public CDR Cdr_Sunat { get; set; }


        //Constructor
        public DocumentoElectronico()
        {
            Emisor = new Contribuyente
            {
                TipoDocumento = BimManager.Sunat.Entidad.Constantes.Catalogo_06_TipoDocumentoIdentidad.Ruc,
                NroDocumento = BimManager.Sunat.Entidad.Constantes.EmpresaDatos.RUC,
                NombreLegal = BimManager.Sunat.Entidad.Constantes.EmpresaDatos.RazonSocial,
                NombreComercial = BimManager.Sunat.Entidad.Constantes.EmpresaDatos.NombreComercial,
                Direccion = BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Direccion,
                Urbanizacion = BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Urbanizacion,
                Distrito = BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Distrito,
                Provincia = BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Provincia,
                Departamento = BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Departamento,
                Ubigeo = BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Ubigeo
            };
            Receptor = new Contribuyente
            {
                TipoDocumento = BimManager.Sunat.Entidad.Constantes.Catalogo_06_TipoDocumentoIdentidad.Ruc
            };
            CalculoIgv = 0.18m;
            CalculoIsc = 0.10m;
            CalculoDetraccion = 0.04m;
            Items = new List<DocumentoElectronicoDetalle>();
            DatoAdicionales = new List<DatoAdicional>();
            DatoAdicionales_Internos = new List<DatoAdicional>();
            Relacionados = new List<DocumentoRelacionado>();
            Discrepancias = new List<Discrepancia>();
            TipoDocumento = BimManager.Sunat.Entidad.Constantes.Catalogo_01_TipoDocumento.Factura;
            TipoOperacion = BimManager.Sunat.Entidad.Constantes.Catalogo_17_TipoOperacion.VentaInterna;
            Moneda = BimManager.Sunat.Entidad.Constantes.Catalogo_02_TipoMoneda.Soles;
        }

    }

}