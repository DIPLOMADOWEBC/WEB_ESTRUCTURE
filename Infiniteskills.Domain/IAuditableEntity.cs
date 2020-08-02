using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Domain
{
    public interface IAuditableEntity
    {
        string Estado { get; set; }
        int UsuarioCreacionId { get; set; }
        DateTime FechaCreacion { get; set; }
        int? UsuarioModificacionId { get; set; }
        DateTime? FechaModificacion { get; set; }
    }
}
