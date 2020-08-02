using System;
namespace Infiniteskills.Transport
{
    public class UnidadMedidaDTO
    {
        public int UnidadMedidaId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Abreaviatura { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
