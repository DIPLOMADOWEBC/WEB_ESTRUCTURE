using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Infiniteskills.Domain
{
    [Table("periodo")]
    public partial class Periodo :AuditableEntity
    {
        public Periodo()
        {
            PeriodoEmpresa = new HashSet<PeriodoEmpresa>();
        }

        [Key]
        [Column("periodo_id", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PeriodoId { get; set; }

        [Required]
        [Column("periodo")]
        public int PeriodoEjucion { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Column("nombre")]
        public string Nombre { get; set; }

      

        public virtual ICollection<PeriodoEmpresa> PeriodoEmpresa { get; set; }
    }
}
