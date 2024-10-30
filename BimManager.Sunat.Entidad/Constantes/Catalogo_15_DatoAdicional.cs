using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BimManager.Sunat.Entidad.Constantes
{
    /// <summary>
    /// Catalogo Nº 16 de SUNAT para Tipo de Precio de Venta Unitario
    /// </summary>
    [Serializable]
    public static class Catalogo_15_DatoAdicional
    {
        /// <summary>
        /// Retorna true o false para indicar si el codigo ingresado pertenece al catálogo
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public static bool Validar_Codigo(string Codigo)
        {
            bool Valido = false;

            if (Codigo == Leyenda_MontoEnLetras ||
                Codigo == Leyenda_TransferenciaGratuitaDeUnBienServicioPrestadoGratuitamente ||
                Codigo == Leyenda_ComprobantePercepcion ||
                Codigo == Leyenda_BienesTransferidosEnLaAmazonia ||
                Codigo == Leyenda_ServiciosTransferidosEnLaAmazonia ||
                Codigo == Leyenda_ContratosDeConstruccionEjcutadosEnLaAmazonia ||
                Codigo == Leyenda_AgenciaDeViaje_PaqueteTuristico ||
                Codigo == Leyenda_VentaRealizadaPorEmisorItinerante ||
                Codigo == Leyenda_OperacionSujetaDetraccion ||
                Codigo == Detraccion_CodigoBbySsSujetosADetraccion ||
                Codigo == Detraccion_NumeroCuentraEnElBancoDeLaNacion ||
                Codigo == Detraccion_RecursosHidrobiologicos_NombreMatriculaEmbarcacion ||
                Codigo == Detraccion_RecursusHidrobiologicos_TipoCantidadDeEspecieVendida ||
                Codigo == Detraccion_RecursosHidrobiologicos_LugarDeDescarga ||
                Codigo == Detraccion_RecursosHidrobiologicos_FechaDeDescarga ||
                Codigo == Detraccion_TransporteBienesViaTerrestre_NumeroRegistroMTC ||
                Codigo == Detraccion_TransporteBienesViaTerrestre_ConfiguracionVehicular ||
                Codigo == Detraccion_TransporteBienesViaTerrestre_PuntoDeOrigen ||
                Codigo == Detraccion_TransporteBienesViaTerrestre_PuntoDeDestino ||
                Codigo == Detraccion_TransporteBienesViaTerrestre_ValorReferencialPreliminar ||
                Codigo == BeneficioHospedaje_CodigoPaisDeEmisionDelPasaporte ||
                Codigo == BeneficioHospedaje_CodigoPaisDeResidenciaDelSujetoNoDomiciliado ||
                Codigo == BeneficioHospedaje_FechaIngresoAlPais ||
                Codigo == BeneficioHospedaje_FechaDeIngresoAlEstablecimiento ||
                Codigo == BeneficioHospedaje_FechaDeSalidaDelEstablecimiento ||
                Codigo == BeneficioHospedaje_NumeroDeDiasDePermanencia ||
                Codigo == BeneficioHospedaje_FechaDeConsumo ||
                Codigo == BeneficioHospedaje_PaqueteTuristico_NombresApellidosDelHuesped ||
                Codigo == BeneficioHospedaje_PaqueteTuristico_TipoDocumentoIdentidadDelHuesped ||
                Codigo == BeneficioHospedaje_PaqueteTuristico_NumeroDeDocumentoIdentidadDeHuesped ||
                Codigo == ProveedorEstado_NumeroDeExpediente ||
                Codigo == ProveedorEstado_CodigoDeUnidadEjecutora ||
                Codigo == ProveedorEstado_NumeroDeProcesoDeSeleccion ||
                Codigo == ProveedorEstado_NumeroDeContrato ||
                Codigo == ComercializacionDeOro_CodigoUnicoConcesionMinera ||
                Codigo == ComercializacionDeOro_NumeroDeclaracionCompromiso ||
                Codigo == ComercializacionDeOro_NumeroRegistroEspecialComercioOro ||
                Codigo == ComercializacionDeOro_NumeroResolucionQueAutorizaPlantaDeBeneficio ||
                Codigo == ComercializacionDeOro_LeyMineralPorcentajeConcentracionDeOro)
            {
                Valido = true;
            }

            return Valido;
        }

        /// <summary>
        /// Retorna código 1000, Leyenda "MONTO EN LETRAS"
        /// </summary>
        public static string Leyenda_MontoEnLetras { get { return "1000"; } }


        /// <summary>
        /// Retorna código 1002, Leyenda "TRANSFERENCIA GRATUITA DE UN BIEN Y/O SERVICIO PRESTADO GRATUITAMENTE"
        /// </summary>
        public static string Leyenda_TransferenciaGratuitaDeUnBienServicioPrestadoGratuitamente { get { return "1002"; } }


        /// <summary>
        /// Retorna código 2000, Leyenda “COMPROBANTE DE PERCEPCIÓN”
        /// </summary>
        public static string Leyenda_ComprobantePercepcion { get { return "2000"; } }


        /// <summary>
        /// Retorna código 2001, Leyenda “BIENES TRANSFERIDOS EN LA AMAZONÍA REGIÓN SELVA PARA SER CONSUMIDOS EN LA MISMA" 
        /// </summary>
        public static string Leyenda_BienesTransferidosEnLaAmazonia { get { return "2001"; } }


        /// <summary>
        /// Retorna código 2002, Leyenda “SERVICIOS PRESTADOS EN LA AMAZONÍA REGIÓN SELVA PARA SER CONSUMIDOS EN LA MISMA” 
        /// </summary>
        public static string Leyenda_ServiciosTransferidosEnLaAmazonia { get { return "2002"; } }


        /// <summary>
        /// Retorna código 2003, Leyenda “CONTRATOS DE CONSTRUCCIÓN EJECUTADOS EN LA AMAZONÍA REGIÓN SELVA”
        /// </summary>
        public static string Leyenda_ContratosDeConstruccionEjcutadosEnLaAmazonia { get { return "2003"; } }


        /// <summary>
        /// Retorna código 2004, Leyenda “Agencia de Viaje - Paquete turístico”
        /// </summary>
        public static string Leyenda_AgenciaDeViaje_PaqueteTuristico { get { return "2004"; } }


        /// <summary>º
        /// Retorna código 2005, Leyenda “Venta realizada por emisor itinerante”
        /// </summary>
        public static string Leyenda_VentaRealizadaPorEmisorItinerante { get { return "2005"; } }


        /// <summary>
        /// Retorna código 2006, Leyenda: Operación sujeta a detracción
        /// </summary>
        public static string Leyenda_OperacionSujetaDetraccion { get { return "2006"; } }


        /// <summary>
        /// Retorna código 3000, Detracciones: CODIGO DE BB Y SS SUJETOS A DETRACCION
        /// </summary>
        public static string Detraccion_CodigoBbySsSujetosADetraccion { get { return "3000"; } }


        /// <summary>
        /// Retorna código 3001, Detracciones: NUMERO DE CTA EN EL BN
        /// </summary>
        public static string Detraccion_NumeroCuentraEnElBancoDeLaNacion { get { return "3001"; } }


        /// <summary>
        /// Retorna código 3002, Detracciones: Recursos Hidrobiológicos-Nombre y matrícula de la embarcación
        /// </summary>
        public static string Detraccion_RecursosHidrobiologicos_NombreMatriculaEmbarcacion { get { return "3002"; } }


        /// <summary>
        /// Retorna código 3003, Detracciones: Recursos Hidrobiológicos-Tipo y cantidad de especie vendida
        /// </summary>
        public static string Detraccion_RecursusHidrobiologicos_TipoCantidadDeEspecieVendida { get { return "3003"; } }


        /// <summary>
        /// Retorna código 3004, Detracciones: Recursos Hidrobiológicos -Lugar de descarga
        /// </summary>
        public static string Detraccion_RecursosHidrobiologicos_LugarDeDescarga { get { return "3004"; } }


        /// <summary>
        /// Retorna código 3005, Detracciones: Recursos Hidrobiológicos -Fecha de descarga
        /// </summary>
        public static string Detraccion_RecursosHidrobiologicos_FechaDeDescarga { get { return "3005"; } }


        /// <summary>
        /// Retorna código 3006, Detracciones: Transporte Bienes vía terrestre – Numero Registro MTC
        /// </summary>
        public static string Detraccion_TransporteBienesViaTerrestre_NumeroRegistroMTC { get { return "3006"; } }


        /// <summary>
        /// Retorna código 3007, Detracciones: Transporte Bienes vía terrestre – configuración vehicular
        /// </summary>
        public static string Detraccion_TransporteBienesViaTerrestre_ConfiguracionVehicular { get { return "3007"; } }


        /// <summary>
        /// Retorna código 3008, Detracciones: Transporte Bienes vía terrestre – punto de origen
        /// </summary>
        public static string Detraccion_TransporteBienesViaTerrestre_PuntoDeOrigen { get { return "3008"; } }


        /// <summary>
        /// Retorna código 3009, Detracciones: Transporte Bienes vía terrestre – punto destino
        /// </summary>
        public static string Detraccion_TransporteBienesViaTerrestre_PuntoDeDestino { get { return "3009"; } }


        /// <summary>
        /// Retorna código 3010, Detracciones: Transporte Bienes vía terrestre – valor referencial preliminar
        /// </summary>
        public static string Detraccion_TransporteBienesViaTerrestre_ValorReferencialPreliminar { get { return "3010"; } }


        /// <summary>
        /// Retorna código 4000, Beneficio hospedajes: Código País de emisión del pasaporte
        /// </summary>
        public static string BeneficioHospedaje_CodigoPaisDeEmisionDelPasaporte { get { return "4000"; } }


        /// <summary>
        /// Retorna código 4001, Beneficio hospedajes: Código País de residencia del sujeto no domiciliado
        /// </summary>
        public static string BeneficioHospedaje_CodigoPaisDeResidenciaDelSujetoNoDomiciliado { get { return "4001"; } }


        /// <summary>
        /// Retorna código 4002, Beneficio Hospedajes: Fecha de ingreso al país
        /// </summary>
        public static string BeneficioHospedaje_FechaIngresoAlPais { get { return "4002"; } }


        /// <summary>
        /// Retorna código 4003, Beneficio Hospedajes: Fecha de ingreso al establecimiento
        /// </summary>
        public static string BeneficioHospedaje_FechaDeIngresoAlEstablecimiento { get { return "4003"; } }


        /// <summary>
        /// Retorna código 4004, Beneficio Hospedajes: Fecha de salida del establecimiento
        /// </summary>
        public static string BeneficioHospedaje_FechaDeSalidaDelEstablecimiento { get { return "4004"; } }


        /// <summary>
        /// Retorna código 4005, Beneficio Hospedajes: Número de días de permanencia
        /// </summary>
        public static string BeneficioHospedaje_NumeroDeDiasDePermanencia { get { return "4005"; } }


        /// <summary>
        /// Retorna código 4006, Beneficio Hospedajes: Fecha de consumo
        /// </summary>
        public static string BeneficioHospedaje_FechaDeConsumo { get { return "4006"; } }


        /// <summary>
        /// Retorna código 4007, Beneficio Hospedajes: Paquete turístico - Nombres y Apellidos del Huésped
        /// </summary>
        public static string BeneficioHospedaje_PaqueteTuristico_NombresApellidosDelHuesped { get { return "4007"; } }


        /// <summary>
        /// Retorna código 4008, Beneficio Hospedajes: Paquete turístico – Tipo documento identidad del huésped
        /// </summary>
        public static string BeneficioHospedaje_PaqueteTuristico_TipoDocumentoIdentidadDelHuesped { get { return "4008"; } }


        /// <summary>
        /// Retorna código 4009, Beneficio Hospedajes: Paquete turístico – Numero de documento identidad de huésped
        /// </summary>
        public static string BeneficioHospedaje_PaqueteTuristico_NumeroDeDocumentoIdentidadDeHuesped { get { return "4009"; } }


        /// <summary>
        /// Retorna código 5000, Proveedores Estado: Número de Expediente
        /// </summary>
        public static string ProveedorEstado_NumeroDeExpediente { get { return "5000"; } }


        /// <summary>
        /// Retorna código 5001, Proveedores Estado : Código de unidad ejecutora
        /// </summary>
        public static string ProveedorEstado_CodigoDeUnidadEjecutora { get { return "5001"; } }


        /// <summary>
        /// Retorna código 5002, Proveedores Estado : N° de proceso de selección
        /// </summary>
        public static string ProveedorEstado_NumeroDeProcesoDeSeleccion { get { return "5002"; } }


        /// <summary>
        /// Retorna código 5003, Proveedores Estado : N° de contrato
        /// </summary>
        public static string ProveedorEstado_NumeroDeContrato { get { return "5003"; } }


        /// <summary>
        /// Retorna código 6000, Comercialización de Oro : Código Único Concesión Minera
        /// </summary>
        public static string ComercializacionDeOro_CodigoUnicoConcesionMinera { get { return "6000"; } }


        /// <summary>
        /// Retorna código 6001, Comercialización de Oro : N° declaración compromiso
        public static string ComercializacionDeOro_NumeroDeclaracionCompromiso { get { return "6001"; } }


        /// <summary>
        /// Retorna código 6002, Comercialización de Oro : N° Reg.Especial.Comerci.Oro
        /// </summary>
        public static string ComercializacionDeOro_NumeroRegistroEspecialComercioOro { get { return "6002"; } }


        /// <summary>
        /// Retorna código 6003, Comercialización de Oro : N° Resolución que autoriza Planta de Beneficio
        /// </summary>
        public static string ComercializacionDeOro_NumeroResolucionQueAutorizaPlantaDeBeneficio { get { return "6003"; } }


        /// <summary>
        /// Retorna código 6004, Comercialización de Oro : Ley Mineral(% concent.oro)
        /// </summary>
        public static string ComercializacionDeOro_LeyMineralPorcentajeConcentracionDeOro { get { return "6004"; } }
    }
}
