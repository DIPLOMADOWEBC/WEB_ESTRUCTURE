using System.ComponentModel;

namespace Infiniteskills.Transport
{
    public class RolMenuDTO 
    {
        public int RolMenuId { get; set; }
        public int RolId { get; set; }
        public int MenuId { get; set; }
        public string EstadoCheck { get; set; }
        public string Lectura { get; set; }
        public string Escritura { get; set; }
        public RolDTO RolDTO { get; set; }
        public MenuDTO MenuDTO { get; set; }


    }
}
