using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Transport
{
    public class ProveedorContactoDTO
    {
        public int ProveedorContactoId { get; set; }
        public int ContactoId { get; set; }
        public int ProveedorId { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }

        public int? UsuarioModificacionId { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual ContactoDTO ContactoDTO { get; set; }

        public virtual ProveedorDTO ProveedorDTO { get; set; }
    }
}
