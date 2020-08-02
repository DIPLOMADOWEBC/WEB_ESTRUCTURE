using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{

    [Table("orden")]
    public partial class Orden:AuditableEntity
    {
        public Orden()
        {
            OrdenItem = new HashSet<OrdenItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("orden_id")]
        public int OrdenId { get; set; }

        [Required]
        [Column("orden")]
        public string Codigo { get; set; }


        [Required(AllowEmptyStrings = true)]
        [Column("num_doc_co")]
        public string NumeroDocumento { get; set; }

        [Column("operacion")]
        [Required(AllowEmptyStrings = true)]
        public string Operacion { get; set; }

        [Required]
        [Column("tipo_doc_com_id")]
        public int DocumentoComercialId { get; set; }

        [Required]
        [Column("tipo_operacion_id")]
        public int TipoOperacionId { get; set; }

        [NotMapped]
        public string OperacionFlag { get; set; }

        [Required]
        [Column("fecha_orden")]
        public DateTime FechaOrden { get; set; }


        [Column("forma_pago_id")]
        public int? FormaPagoId { get; set; }

        [Column("moneda_id")]
        public int? MonedaId { get; set; }

        [Column("periodo_empresa_id")]
        public int PeriodoEmpresaId { get; set; }

        [Column("mes_contable_id")]
        public int MesContableId { get; set; }

        [Column("almacen_id")]
        public int AlmacenId { get; set; }

        [Column("almacen_dest_id")]
        public int? AlmacenDestinoId { get; set; }

        [Column("vehiculo_id")]
        public int? VehiculoId { get; set; }

        [Column("conductor_id")]
        public int? ConductorId { get; set; }

        //[Column("empresa_id")]
        //public int? EmpresaId { get; set; }

        [Column("tipo_precio_id")]
        public int? TipoPrecioId { get; set; }

        [Column("impuesto_id")]
        public int? ImpuestoId { get; set; }


        [Column("fecha_entrega")]
        public DateTime? FechaEntrega { get; set; }


        [Required]
        [Column("cantidad")]
        public decimal Cantidad { get; set; }

        [Required]
        [Column("sub_total")]
        public decimal SubTotal { get; set; }

        [Column("descuento")]
        public decimal Descuento { get; set; }

        [Required]
        [Column("impuesto")]
        public decimal Impuesto { get; set; }

        [Required]
        [Column("total_pedido")]
        public decimal TotalPedido { get; set; }

        [Column("total_exone")]
        public decimal TotalExonerado { get; set; }

        [Column("total_inafec")]
        public decimal TotalInafecto { get; set; }

        [Required]
        [Column("personal_id")]
        public int PersonalId { get; set; }

        [Column("proveedor_id")]
        public int? ProveedorId { get; set; }

        [Column("observacion")]
        public string Observacion { get; set; }

        [Required]
        [StringLength(1)]
        [Column("anulado")]
        public string Anulado { get; set; }

        public virtual MesContable MesContable { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual DocumentoComercial DocumentoComercial { get; set; }
        public virtual Personal Personal { get; set; }
        public virtual FormaPago FormaPago { get; set; }
        public virtual TipoPrecio TipoPrecio { get; set; }
        public virtual Moneda Moneda { get; set; }
        public virtual TipoOperacion TipoOperacion { get; set; }
        public virtual Almacen Almacen { get; set; }
        public virtual Conductor Conductor { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
        //public virtual Empresa Empresa { get; set; }
        public virtual PeriodoEmpresa PeriodoEmpresa { get; set; }
        public virtual ICollection<OrdenItem> OrdenItem { get; set; }
    }
}
