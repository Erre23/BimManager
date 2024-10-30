using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BimManager.Sunat.Entidad.Constantes
{
    /// <summary>
    /// Catalogo Nº 6 de SUNAT para tipos de documento de identidad
    /// </summary>
    [Serializable]
    public static class Catalogo_06_TipoDocumentoIdentidad
    {
        /// <summary>
        /// Retorna 0
        /// </summary>
        public static string NoDomiciliadoSinRuc { get { return "0"; } }

        /// <summary>
        /// Retorna 1
        /// </summary>
        public static string Dni { get { return "1"; } }


        /// <summary>
        /// Retorna 4
        /// </summary>
        public static string CarnetExtranjeria { get { return "4"; } }

        /// <summary>
        /// Retorna 6
        /// </summary>
        public static string Ruc { get { return "6"; } }

        /// <summary>
        /// Retorna 7
        /// </summary>
        public static string Pasaporte { get { return "7"; } }


        /// <summary>
        /// Retorna A
        /// </summary>
        public static string CedDiplomaticaDeIdentidad { get { return "A"; } }


        /// <summary>
        /// Retorna true o false para indicar que el codigo pertenece a un elemento del catálogo
        /// </summary>
        /// <param name="TipoDocumentoIdentidad_Codigo"></param>
        /// <returns></returns>
        public static bool EsValido (string TipoDocumentoIdentidad_Codigo)
        {
            bool EsValido = false;

            if (TipoDocumentoIdentidad_Codigo != null)
            {
                if (TipoDocumentoIdentidad_Codigo == NoDomiciliadoSinRuc) EsValido = true;
                else if (TipoDocumentoIdentidad_Codigo == Dni) EsValido = true;
                else if (TipoDocumentoIdentidad_Codigo == CarnetExtranjeria) EsValido = true;
                else if (TipoDocumentoIdentidad_Codigo == Ruc) EsValido = true;
                else if (TipoDocumentoIdentidad_Codigo == Pasaporte) EsValido = true;
                else if (TipoDocumentoIdentidad_Codigo == CedDiplomaticaDeIdentidad) EsValido = true;
            }

            return EsValido;
        }
    }
}
