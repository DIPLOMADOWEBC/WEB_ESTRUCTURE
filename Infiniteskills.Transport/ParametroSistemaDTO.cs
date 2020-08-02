using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Transport
{
    public class ParametroSistemaDTO
    {
        public int ParametroSistemaId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string ValorCadena { get; set; }
        public decimal ValorNumerico { get; set; }
        public DateTime? ValorFecha { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public string EditAction { get; set; }

    }
}
