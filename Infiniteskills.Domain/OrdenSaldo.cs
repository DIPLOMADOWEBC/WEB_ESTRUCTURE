using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("mov_alm_saldo")]
    public partial class OrdenSaldo:AuditableEntity
    {
        public OrdenSaldo()
        {
         
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("mov_alm_saldo_id")]
        public int OrdenSaldoId { get; set; }

        [Column("almacen_id")]
        public int AlmacenId { get; set; }


        [Required]
        [Column("bien_servicio_id")]
        public int BienServicioId { get; set; }


        [Column("periodo_empresa_id")]
        public int PeriodoEmpresaId { get; set; }

        [Column("mes_contable_id")]
        public int MesContableId { get; set; }

        [Column("cant_ant")]
        public decimal CantidadAnterior { get; set; }

        [Column("valor_ant")]
        public decimal ValorAnterio { get; set; }

        [Column("valor_unit")]
        public decimal ValorUnitario{ get; set; }

        [Column("valor_unit_ant")]
        public decimal ValorUnitAnterior { get; set; }

        [Column("cant_ingr")]
        public decimal CantidadIngreso { get; set; }

        [Column("valor_ingr")]
        public decimal ValorIngreso { get; set; }

        [Column("cant_salid")]
        public decimal CantidadSalida { get; set; }

        [Column("valor_salid")]
        public decimal ValorSalida { get; set; }

        [Column("monto_sal")]
        public decimal MontoSaldo { get; set; }

        [Column("cant_reserv")]
        public decimal CantidadReserva { get; set; }

        public virtual MesContable MesContable { get; set; }
        public virtual Almacen Almacen { get; set; }
        public virtual BienServicio BienServicio { get; set; }
        public virtual PeriodoEmpresa PeriodoEmpresa { get; set; }
    }
}
