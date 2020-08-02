using System;
namespace Infiniteskills.Transport
{
    public class BienServicioDTO
    {
        public int BienServicioId { get; set; }
        public string Codigo { get; set; }
        public string CodigoComercial { get; set; }
        public string Descripcion { get; set; }
        public int LineaId { get; set; }
        public int CategoriaId { get; set; }
        public int? ProveedorId { get; set; }
        public int TipoExistenciaId { get; set; }
        public int MonedaId { get; set; }
        public int MarcaId { get; set; }
        public decimal StockMinimo { get; set; }
        public decimal StockMaximo { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal? PrecioVenta { get; set; }
        public decimal Existencias { get; set; }
        public string Procedencia { get; set; }
        public string Modelo { get; set; }
        public int? AlmacenId { get; set; }
        public int UnidadMedidaId { get; set; }
        public int TipoBienId { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string EditAction { get; set; }
        public virtual CategoriaDTO CategoriaDTO { get; set; }
        public virtual ProveedorDTO ProveedorDTO { get; set; }
        //public virtual TipoProductoDTO TipoProductoDTO { get; set; }
        public virtual UnidadMedidaDTO UnidadMedidaDTO { get; set; }
        public virtual MarcaDTO MarcaDTO { get; set; }
        public virtual MonedaDTO MonedaDTO { get; set; }
        public virtual TipoBienDTO TipoBienDTO { get; set; }
        public virtual LineaDTO LineaDTO { get; set; }
    }
}
