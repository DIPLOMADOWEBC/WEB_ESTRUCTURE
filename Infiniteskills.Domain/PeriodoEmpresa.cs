using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("periodo_empresa")]
    public partial class PeriodoEmpresa:AuditableEntity
    {
        public PeriodoEmpresa()
        {
            PeriodoCorrelativo = new HashSet<PeriodoCorrelativo>();
            Orden = new HashSet<Orden>();
            OrdenSaldo = new HashSet<OrdenSaldo>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("periodo_empresa_id")]
        public int PeriodoEmpresaId { get; set; }

        [Column("sucursal_id")]
        public int SucursalId { get; set; }

        [Column("periodo_id")]
        public int PeriodoId { get; set; }

  
        public virtual Periodo Periodo { get; set; }
       // public virtual Sucursal Sucursal { get; set; }
        public virtual ICollection<PeriodoCorrelativo> PeriodoCorrelativo { get; set; }
        public virtual ICollection<Orden> Orden { get; set; }
        public virtual ICollection<OrdenSaldo> OrdenSaldo { get; set; }
    }
}
