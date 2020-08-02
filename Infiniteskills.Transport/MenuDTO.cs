using System.ComponentModel;

namespace Infiniteskills.Transport
{
    public class MenuDTO 
    {
        public int MenuId { get; set; }
        public string Nombre { get; set; }
        public string Area { get; set; }
        public string Url { get; set; }
        public string RutaImagen { get; set; }
        public int? MenuPadreId { get; set; }
        public int Orden { get; set; }
        public string Estado { get; set; }


    }
}
