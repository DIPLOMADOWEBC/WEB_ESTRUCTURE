using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Transport
{
    public class SerieDTO
    {
        public int SerieId { get; set; }
        public int AlmacenId { get; set; }
        public int DocumentoComercialId { get; set; }
        public string NumeroSerie { get; set; }
        public int NumeroLinea { get; set; }
        public string IgvSn { get; set; }
        public string FormatoDocumento { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public virtual AlmacenDTO AlmacenDTO { get; set; }
    }
}
