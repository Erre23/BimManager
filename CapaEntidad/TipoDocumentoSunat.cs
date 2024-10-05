namespace CapaEntidad
{
    public class TipoDocumentoSunat
	{
		public short TipoDocumentoSunatID { get; set; }

        public string Nombre { get; set; }

        public string CodigoSunat { get; set; }

        public bool Activo { get; set; } = true;
    }
}
