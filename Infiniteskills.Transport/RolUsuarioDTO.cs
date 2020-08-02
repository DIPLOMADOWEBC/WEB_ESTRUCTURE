using System;
using System.ComponentModel;

namespace Infiniteskills.Transport
{
    public class RolUsuarioDTO 
    {
        public int RolUsuarioId { get; set; }
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
        public RolDTO RolDTO { get; set; }
        public UsuarioDTO UsuarioDTO { get; set; }

    }
}
