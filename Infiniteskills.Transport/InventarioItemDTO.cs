using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Transport
{
    public class InventarioItemDTO
    {
        public int ItemInventarioId { get; set; }
        public int ProductoId { get; set; }
        public int UnidadMedidaId { get; set; }
        public int InventarioId { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Importe { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public virtual InventarioDTO InventarioDTO { get; set; }
        public virtual BienServicioDTO ProductoDTO { get; set; }
        public virtual UnidadMedidaDTO UnidadMedidaDTO { get; set; }
    }
}
