namespace CapaEntidad
{
    public class Usuario
    {
        public int UsuarioID { get; set; }

        public string Username { get; set; }

		public string HashPassword { get; set; }

		public string Nombres { get; set; }

        public string Apellido1 { get; set; }

        public string Apellido2 { get; set; }

        public bool CambioContrasena { get; set; }

        public bool Activo { get; set; }

        public string ApellidosNombres { get { return $"{Apellido1} {Apellido2} {Nombres}".Trim(); } }
    }
}
