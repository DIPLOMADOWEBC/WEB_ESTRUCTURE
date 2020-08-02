using System;
using System.Collections.Generic;
using System.Text;

namespace Infiniteskills.Transport
{
   public class PeriodoCorrelativoDTO
    {
        public int PeriodoCorrelativoId { get; set; }
        public int TablaId { get; set; }
        public int PeriodoEmpresaId { get; set; }
        public int Correlativo { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual TablaDTO TablaDTO { get; set; }
        public virtual PeriodoEmpresaDTO PeriodoEmpresaDTO { get; set; }
    }
}
