using System;
using System.Collections.Generic;
using System.Text;

namespace Infiniteskills.Transport
{
    public class PeriodoDTO
    {
        public int PeriodoId { get; set; }
        public int PeriodoEjucion { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
