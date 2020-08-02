using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("departamento")]
    public partial class Departamento
    {
        public Departamento()
        {
            Provincia = new HashSet<Provincia>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("departamento_id")]
        public int DepartamentoId { get; set; }

        [Required]
        [Column("departamento")]
        public string Codigo { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Required]
        [Column("pais_id")]
        public int PaisId { get; set; }

        [Required]
        [StringLength(1)]
        [Column("estado")]
        public string Estado { get; set; }

        [Required]
        [Column("usuario_creacion_id")]
        public int UsuarioCreacionId { get; set; }

        [Required]
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("usuario_modifica_id")]
        public int? UsuarioModificacionId { get; set; }

        [Column("fecha_modifica")]
        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<Provincia> Provincia { get; set; }
        public virtual Pais Pais { get; set; }
    }
}
