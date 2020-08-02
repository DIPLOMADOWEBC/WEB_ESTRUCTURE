using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("pais")]
    public partial class Pais:AuditableEntity
    {
        public Pais()
        {
            Departamento = new HashSet<Departamento>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("pais_id")]
        public int PaisId { get; set; }

        [Column("pais")]
        public string Codigo { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }


        public virtual ICollection<Departamento> Departamento { get; set; }
    }
}
