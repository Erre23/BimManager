using System.Collections.Generic;

namespace BimManager.Sunat.Entidad.Models
{
    [System.Serializable]
    public class ComunicacionBaja : DocumentoResumen
    {
        public List<DocumentoBaja> Bajas { get; set; }

        public ComunicacionBaja()
        {
            Emisor =
                new BimManager.Sunat.Entidad.Models.Contribuyente
                {
                    TipoDocumento = BimManager.Sunat.Entidad.Constantes.Catalogo_06_TipoDocumentoIdentidad.Ruc,
                    NroDocumento = BimManager.Sunat.Entidad.Constantes.EmpresaDatos.RUC,
                    NombreLegal = BimManager.Sunat.Entidad.Constantes.EmpresaDatos.RazonSocial,
                    NombreComercial = BimManager.Sunat.Entidad.Constantes.EmpresaDatos.NombreComercial,
                    Ubigeo = BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Ubigeo,
                    Departamento = BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Departamento,
                    Provincia = BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Provincia,
                    Distrito = BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Distrito,
                    Urbanizacion = BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Urbanizacion,
                    Direccion = BimManager.Sunat.Entidad.Constantes.EmpresaDatos.Direccion
                };


            Bajas = new List<DocumentoBaja>();
        }
    }
}
