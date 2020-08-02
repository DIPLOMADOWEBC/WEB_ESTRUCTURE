using System;
using System.Collections.Generic;
using System.Text;

namespace Infiniteskills.Transport
{
    public class PeriodoEmpresaDTO
    {
        public int PeriodoEmpresaId { get; set; }
        public int SucursalId { get; set; }
        public int PeriodoId { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public virtual PeriodoDTO PeriodoDTO { get; set; }
        public virtual SucursalDTO SucursalDTO { get; set; }
    }

}
