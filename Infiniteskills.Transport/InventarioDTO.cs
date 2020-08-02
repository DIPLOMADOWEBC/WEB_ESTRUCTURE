using System;

namespace Infiniteskills.Transport
{
    public class InventarioDTO
    {
        public int InventarioId { get; set; }
        public int PersonalId { get; set; }
        public string Codigo { get; set; }
        public int DocumentoComercialId { get; set; }
        public int TipoOperacionId { get; set; }
        public int ProveedorId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaCompra { get; set; }
        public int SucursalId { get; set; }
        public decimal Cantidad { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string EditAction { get; set; }
        public virtual SucursalDTO SucursalDTO { get; set; }
        public virtual PersonalDTO PersonalDTO { get; set; }
        public virtual ProveedorDTO ProveedorDTO { get; set; }
        public virtual TipoOperacionDTO TipoOperacionDTO { get; set; }
        public virtual DocumentoComercialDTO DocumentoComercialDTO { get; set; }
    }
}
