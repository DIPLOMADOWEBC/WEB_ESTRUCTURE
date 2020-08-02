using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("bien_servicio")]
    public partial class BienServicio : AuditableEntity
    {
        public BienServicio()
        {
            PedidoItem = new HashSet<OrdenItem>();
            OrdenSaldo = new HashSet<OrdenSaldo>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("bien_servicio_id")]
        public int BienServicioId { get; set; }

        [Required]
        [Column("bien_servicio")]
        public string Codigo { get; set; }

        [Column("linea_id")]
        public int LineaId { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Column("codigo_com")]
        public string CodigoComercial { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("categoria_id")]
        public int CategoriaId { get; set; }

        [Required]
        [Column("moneda_id")]
        public int MonedaId { get; set; }

        [Column("tipo_existencia_id")]
        public int TipoExistenciaId { get; set; }


        [Column("proveedor_id")]
        public int? ProveedorId { get; set; }

        [Column("stock_minimo")]
        public decimal StockMinimo { get; set; }

        [Column("stock_maximo")]
        public decimal StockMaximo { get; set; }

        [Column("existencia")]
        public decimal Existencias { get; set; }

        [Column("modelo")]
        public string Modelo { get; set; }

        [Column("marca_id")]
        public int MarcaId { get; set; }

        [Column("tipo_bien_id")]
        public int TipoBienId { get; set; }

        [Column("almacen_id")]
        public int? AlmacenId { get; set; }


        [Column("unidad_medida_id")]
        public int UnidadMedidaId { get; set; }

        [Column("precio_unitario")]
        public decimal PrecioUnitario { get; set; }


        [Column("precio_venta")]
        public decimal? PrecioVenta { get; set; }


        [Column("observacion")]
        public string Observacion { get; set; }

        [Column("procedencia")]
        public string Procedencia { get; set; }

        public virtual TipoExistencia TipoExistencia { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual UnidadMedida UnidadMedida { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual Moneda Moneda { get; set; }
        public virtual TipoBien TipoBien { get; set; }
        public virtual Linea Linea { get; set; }
        public virtual ICollection<OrdenItem> PedidoItem { get; set; }
        public virtual ICollection<OrdenSaldo> OrdenSaldo { get; set; }
    }
}
