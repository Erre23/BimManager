using System;

namespace BimManager.Sunat.Entidad.Models
{
    [Serializable]
    public class Contribuyente
    {
        /// <summary>
        /// Numero de documento de identidad ancho maximo 15 caracteres
        /// </summary>
        public string NroDocumento { get; set; }

        /// <summary>
        /// Tipo de documento de identidad usar la clase Ee.FacturaElectronica.Constantes.Catalogo_06_TipoDocumentoIdentidad ancho fijo de 2 caracteres
        /// </summary>
        public string TipoDocumento { get; set; }

        /// <summary>
        /// Para el caso de Juridico es la razon social y en el caso de un natural los Apellidos y nombre ancho maximo 100 caracteres
        /// </summary>
        public string NombreLegal { get; set; }

        /// <summary>
        /// Solo Para el caso de Juridico es el nombre comercial ancho maximo 100 caracteres
        /// </summary>
        public string NombreComercial { get; set; }

        /// <summary>
        /// Código del ubigeo que se encuentra en el catalogo 13 de Sunat, esta conformada por 6 digitos los cuales el primer y segundo digito pertenece al departamento, el tercer y cuarto digito a la provincia y el quinto y sexto digito al distrito
        /// </summary>
        public string Ubigeo { get; set; }


        /// <summary>
        /// Direccion de la empresa ancho máximo de 100 caracteres
        /// </summary>
        public string Direccion { get; set; }


        /// <summary>
        /// Nombre de la urbanizacion ancho m$ximo de 25 caracteres
        /// </summary>
        public string Urbanizacion { get; set; }


        /// <summary>
        /// Nombre del departamento ancho maximo de 30 caracteres
        /// </summary>
        public string Departamento { get; set; }


        /// <summary>
        /// Nombre de la provincia ancho maximo de 30 caracteres
        /// </summary>
        public string Provincia { get; set; }


        /// <summary>
        /// Nombre del distrito ancho maximo de 30 caracteres
        /// </summary>
        public string Distrito { get; set; }
    }
}