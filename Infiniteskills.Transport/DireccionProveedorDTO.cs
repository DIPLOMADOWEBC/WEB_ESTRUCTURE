using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Transport
{
    public class DireccionProveedorDTO
    {
        public int DireccionId { get; set; }
        public int ProveedorId { get; set; }

        public int DistritoId { get; set; }

        public string NombreDireccion { get; set; }


        public string Referencia { get; set; }
        public string Fiscal { get; set; }

        public string Estado { get; set; }

        public int UsuarioCreacionId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuarioModificacionId { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual ProveedorDTO ProveedorDTO { get; set; }
        public virtual DistritoDTO DistritoDTO { get; set; }
    }
}
