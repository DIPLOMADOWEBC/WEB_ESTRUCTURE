using System;
namespace Infiniteskills.Transport
{
    public class PersonalDTO
    {
        public int PersonalId { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string Estado { get; set; }

        //Usuario
        public string Usuario { get; set; }
        public string Password { get; set; }
        public int SucursalId { get; set; }

        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public string EditAction { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public UsuarioDTO UsuarioDTO { get; set; }
    }
}
