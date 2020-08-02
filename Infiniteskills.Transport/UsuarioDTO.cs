using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Transport
{
    public class UsuarioDTO
    {
        public int UsuarioId { get; set; }
        public int PersonalId { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public virtual PersonalDTO PersonalDTO { get; set; }
        public  virtual SucursalDTO SucursalDTO { get; set; }
    }
}
