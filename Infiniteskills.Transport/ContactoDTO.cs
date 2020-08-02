using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Transport
{
    public class ContactoDTO
    {
        public int ContactoId { get; set; }
        public int AreaId { get; set; }
        public int ProveedorId { get; set; }
        public string NumeroDocumentoContacto { get; set; }
        public string NombreContacto { get; set; }
        public string TelefonoContacto { get; set; }
        public string CelularContacto { get; set; }
        public string EmailContacto { get; set; }
        public string DireccionContacto { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string EditAction { get; set; }
        public virtual AreaDTO AreaDTO { get; set; }

    }
}
