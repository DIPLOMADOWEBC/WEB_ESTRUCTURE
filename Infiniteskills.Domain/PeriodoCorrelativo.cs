using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("periodo_corre")]
    public partial class PeriodoCorrelativo:AuditableEntity
    {
        public PeriodoCorrelativo()
        {

        }

        [Key]
        [Column("periodo_corre_id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PeriodoCorrelativoId { get; set; }

        [Column("tabla_id")]
        public int TablaId { get; set; }

        [Column("periodo_empresa_id")]
        public int PeriodoEmpresaId { get; set; }

        [Column("correlativo")]
        public int Correlativo { get; set; }

     
        public virtual Tabla Tabla { get; set; }
        public virtual PeriodoEmpresa PeriodoEmpresa { get; set; }
    }
}