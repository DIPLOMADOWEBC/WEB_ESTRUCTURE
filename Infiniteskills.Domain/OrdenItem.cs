using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("orden_item")]
    public partial class OrdenItem:AuditableEntity
    {
        public OrdenItem()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("orden_item_id")]
        public int OrdenItemId { get; set; }

        [Required]
        [Column("orden_id")]
        public int OrdenId { get; set; }


        [Required]
        [Column("bien_servicio_id")]
        public int BienServicioId { get; set; }


        [Required]
        [Column("cantidad")]
        public decimal Cantidad { get; set; }

        [Column("peso_neto")]
        public decimal PesoNeto { get; set; }

        [Required]
        [Column("peso_bruto")]
        public decimal PesoBruto { get; set; }

        [Column("valor_unit")]
        public decimal ValorUnitario { get; set; }

        [Column("valor_orden")]
        public decimal ValorOrden { get; set; }

        [Column("valor_promo")]
        public decimal ValorPromosion { get; set; }

        [DataType(DataType.Currency)]
        [Column("valor_mov")]
        public decimal ValorMovimiento { get; set; }

        public virtual Orden Orden { get; set; }
        public virtual BienServicio BienServicio { get; set; }
    }
}
