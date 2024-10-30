using System.Collections.Generic;
using BimManager.Sunat.Entidad.Constantes;

namespace BimManager.Sunat.Entidad.Models
{
    [System.Serializable]
    public class ResumenDiario : DocumentoResumen
    {
        public List<GrupoResumen> Resumenes { get; set; }
        public List<GrupoResumen2018> Resumenes2018 { get; set; }

        public ResumenDiario()
        {
            Emisor =
                new Contribuyente
                {
                    TipoDocumento = Catalogo_06_TipoDocumentoIdentidad.Ruc,
                    NroDocumento = EmpresaDatos.RUC,
                    NombreLegal = EmpresaDatos.RazonSocial,
                    NombreComercial = EmpresaDatos.NombreComercial,
                    Ubigeo = EmpresaDatos.Ubigeo,
                    Departamento = EmpresaDatos.Departamento,
                    Provincia = EmpresaDatos.Provincia,
                    Distrito = EmpresaDatos.Distrito,
                    Urbanizacion = EmpresaDatos.Urbanizacion,
                    Direccion = EmpresaDatos.Direccion
                };

            Resumenes = new List<GrupoResumen>();
        }
    }
}
