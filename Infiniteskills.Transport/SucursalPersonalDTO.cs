using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Transport
{
    public class SucursalPersonalDTO
    {
        public int SucursalPersonalId { get; set; }
        public int SucursalId { get; set; }
        public int PersonalId { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public virtual SucursalDTO SucursalDTO { get; set; }
        public virtual PersonalDTO PersonalDTO { get; set; }
    }
}
