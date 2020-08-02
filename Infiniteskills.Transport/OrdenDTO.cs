using System;
using System.Collections.Generic;

namespace Infiniteskills.Transport
{
    public class OrdenDTO
    {
        public int OrdenId { get; set; }
        public string Codigo { get; set; }
        public string NumeroDocumento { get; set; }
        public string Operacion { get; set; }
        public int AlmacenId { get; set; }
        public int? AlmacenDestinoId { get; set; }
        public int? TipoPrecioId { get; set; }
        public int DocumentoComercialId { get; set; }
        public int PeriodoEmpresaId { get; set; }
        public int MesContableId { get; set; }
        public int TipoOperacionId { get; set; }
        public int? ProveedorId { get; set; }
        public int? MonedaId { get; set; }
        public int? VehiculoId { get; set; }
        public int? ConductorId { get; set; }
        //public int? EmpresaId { get; set; }
        public int? ImpuestoId { get; set; }
        public string OperacionFlag { get; set; }
        public decimal Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Descuento { get; set; }
        public decimal TotalPedido { get; set; }
        public decimal TotalExonerado { get; set; }
        public decimal TotalInafecto { get; set; }
        public DateTime FechaOrden { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public int PersonalId { get; set; }
        public int? FormaPagoId { get; set; }
        public string Observacion { get; set; }
        public string Anulado { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }

        //Facturacion Datos de cliente
        public string NumeroRuc { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public virtual TipoPrecioDTO TipoPrecioDTO { get; set; }
        public virtual AlmacenDTO AlmacenDTO { get; set; }
        public virtual MesContableDTO MesContableDTO { get; set; }
        public virtual DocumentoComercialDTO DocumentoComercialDTO { get; set; }
        public virtual PersonalDTO PersonalDTO { get; set; }
        public virtual ProveedorDTO ProveedorDTO { get; set; }
        public virtual FormaPagoDTO FormaPagoDTO { get; set; }
        public virtual TipoOperacionDTO TipoOperacionDTO { get; set; }
        public virtual MonedaDTO MonedaDTO { get; set; }
        public virtual PeriodoEmpresaDTO PeriodoEmpresaDTO { get; set; }
        public virtual ConductorDTO ConductorDTO { get; set; }
        public virtual VehiculoDTO VehiculoDTO { get; set; }
       // public virtual EmpresaDTO EmpresaDTO { get; set; }
        public virtual ImpuestoDTO ImpuestoDTO { get; set; }
        public List<OrdenItemDTO> OrderItemList { get; set; }
        public string EditAction { get; set; }
    }
}
