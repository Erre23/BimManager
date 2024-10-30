using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BimManager.Sunat.Entidad.Constantes
{
    /// <summary>
    /// Catalogo Nº 7 de SUNAT para tipo de afectacion del IGV
    /// </summary>
    [Serializable]
    public static class Catalogo_07_TipoAfectacionIgv
    {
        /// <summary>
        /// Retorna 10 para montos gravados - operación onerosa
        /// </summary>
        public static string Gravada_OperacionOnerosa { get { return "10"; } }

        /// <summary>
        /// Retorna 11 para montos gravados - retiro por premio
        /// </summary>
        public static string Gravada_RetiroPorPremio { get { return "11"; } }

        /// <summary>
        /// Retorna 12 para montos gravados - retiro por donación
        /// </summary>
        public static string Gravada_RetiroPorDonacion { get { return "12"; } }

        /// <summary>
        /// Retorna 13 para montos gravados - retiro
        /// </summary>
        public static string Gravada_Retiro { get { return "13"; } }

        /// <summary>
        /// Retorna 14 para montos gravados - retiro por publicidad
        /// </summary>
        public static string Gravada_RetiroPorPublicidad { get { return "14"; } }

        /// <summary>
        /// Retorna 15 para montos gravados - Bonificaciones
        /// </summary>
        public static string Gravada_Bonificaciones { get { return "15"; } }

        /// <summary>
        /// Retorna 16 para montos gravados - Retiro por entrega a trabajadores
        /// </summary>
        public static string Gravada_RetiroEntregaTrabajador { get { return "16"; } }

        /// <summary>
        /// Retorna 17 para montos gravados - IVAP
        /// </summary>
        public static string Gravada_IVAP { get { return "17"; } }

        /// <summary>
        /// Retorna 20 para montos exonerados - operación onerosa
        /// </summary>
        public static string Exonerada_OperacionOnerosa { get { return "20"; } }

        /// <summary>
        /// Retorna 21 para montos exonerados - Transferencia gratuita
        /// </summary>
        public static string Exonerada_TransferenciaGratuita { get { return "21"; } }

        /// <summary>
        /// Retorna 30 para montos inafectos - operación onerosa
        /// </summary>
        public static string Inafecta_OperacionOnerosa { get { return "30"; } }

        /// <summary>
        /// Retorna 31 para montos inafectos - Retiro por bonificación
        /// </summary>
        public static string Inafecta_RetiroPorBonificacion { get { return "31"; } }

        /// <summary>
        /// Retorna 32 para montos inafectos - Retiro 
        /// </summary>
        public static string Inafecta_Retiro { get { return "32"; } }

        /// <summary>
        /// Retorna 33 para montos inafectos - Retiro por Muestras Médicas
        /// </summary>
        public static string Inafecta_RetiroMuestrasMedicas { get { return "33"; } }

        /// <summary>
        /// Retorna 34 para montos inafectos - Retiro por convenio colectivo
        /// </summary>
        public static string Inafecta_RetiroConvenioColectivo { get { return "34"; } }

        /// <summary>
        /// Retorna 35 para montos inafectos - Retiro por premio
        /// </summary>
        public static string Inafecta_RetiroPorPremio { get { return "35"; } }

        /// <summary>
        /// Retorna 36 para montos inafectos - Retiro por publicidad
        /// </summary>
        public static string Inafecta_RetiroPorPublicidad { get { return "36"; } }

        /// <summary>
        /// Retorna 40 para exportación
        /// </summary>
        public static string Exportacion { get { return "40"; } }
    }
}
