using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BimManager.Sunat.Entidad.Constantes
{
    /// <summary>
    /// Catalogo Nº 3 de SUNAT para unidades de medida
    /// </summary>
    [Serializable]
    public static class Catalogo_03_TipoUnidadDeMedida
    {
        /// <summary>
        /// Retorna la Abreviatura o simbolo del codigo de la unidad de medida que enviemos, Ejemplo NIU retorna und
        /// </summary>
        /// <param name="Codigo">Codigo del Catalogo 03 Tipo de Unidad de medida</param>
        /// <returns></returns>
        public static string Abreviatura (string Codigo)
        {
            string Abreviatura_ = "";
            switch (Codigo)
            {
                case "NIU": //Para Unidad
                case "ZZ": //Para Servicios
                    Abreviatura_ = "und";
                    break;

                case "KGM": //Para Kilogramo
                    Abreviatura_ = "kg";
                    break;

                case "GRM": //Para gramo
                    Abreviatura_ = "g";
                    break;

                case "GLL": //Para Galon
                    Abreviatura_ = "gal";
                    break;

                case "MTR": //Para metro
                    Abreviatura_ = "mts";
                    break;

                case "MTQ": //Para metro cubico
                    Abreviatura_ = "m3";
                    break;

                case "INH": //Para pulgada
                    Abreviatura_ = "plg";
                    break;

                case "LTR": //Para Litro
                    Abreviatura_ = "L";
                    break;

                case "LBR": //Para Libra
                    Abreviatura_ = "lb";
                    break;

                case "BX": //Para Caja
                    Abreviatura_ = "caj";
                    break;

                case "MIL": //Para Millar
                    Abreviatura_ = "M";
                    break;

                case "ONZ": //Para Onza
                    Abreviatura_ = "oz";
                    break;
            }

            return Abreviatura_;
        }

        /// <summary>
        /// Retorna NIU para la Unidad de medida internacional y que usaremos como medida fija como venta de servicios
        /// </summary>
        public static string Unidad { get{ return "NIU"; } }

        /// <summary>
        /// Retorna NIU para la Unidad de medida internacional y que usaremos como medida fija como venta de servicios
        /// </summary>
        public static string UnidadServicios { get { return "ZZ"; } }

        /// <summary>
        /// Retorna KGM para Kilogramo 
        /// </summary>
        public static string Kilogramo { get { return "KGM"; } }

        /// <summary>
        /// Retorna GRM para Gramo
        /// </summary>
        public static string Gramo { get { return "GRM"; } }

        /// <summary>
        /// Retorna GLL para Galon (US)
        /// </summary>
        public static string Galon { get { return "GLL"; } }

        /// <summary>
        /// Retorna MTR para Metro
        /// </summary>
        public static string Metro { get { return "MTR"; } }

        /// <summary>
        /// Retorna MTQ para Metro Cubico
        /// </summary>
        public static string MetroCubico { get { return "MTQ"; } }

        /// <summary>
        /// Retorna INH para Pulgada
        /// </summary>
        public static string Pulgada { get { return "INH"; } }

        /// <summary>
        /// Retorna LTR para Litro
        /// </summary>
        public static string Litro { get { return "LTR"; } }

        /// <summary>
        /// Retorna LBR para Libra
        /// </summary>
        public static string Libra { get { return "LBR"; } }

        /// <summary>
        /// Retorna BX para Caja
        /// </summary>
        public static string Caja { get { return "BX"; } }

        /// <summary>
        /// Retorna MIL para Millar
        /// </summary>
        public static string Millar { get { return "MIL"; } }
        
        /// <summary>
        /// Retorna ONZ para Onza
        /// </summary>
        public static string Onza { get { return "ONZ"; } }
    }
}
