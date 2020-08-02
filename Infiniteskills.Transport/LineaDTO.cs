using System;

namespace Infiniteskills.Transport
{
    public class LineaDTO
    {
        public int LineaId { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}