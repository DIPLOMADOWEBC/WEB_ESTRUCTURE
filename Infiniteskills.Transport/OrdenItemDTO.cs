using System;
namespace Infiniteskills.Transport
{
    public class OrdenItemDTO
    {
        public int OrdenItemId { get; set; }
        public int OrdenId { get; set; }
        public int BienServicioId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PesoNeto { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorOrden { get; set; }
        public decimal ValorPromosion { get; set; }
        public decimal ValorMovimiento { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public virtual OrdenDTO PedidoDTO { get; set; }
        public virtual BienServicioDTO BienServicioDTO { get; set; }
    }
}
