using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace Infiniteskills.Domain
{
   

    [Table("param_sistema")]
    public partial class ParametroSistema:AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("param_sistema_id")]
        public int ParametroSistemaId { get; set; }

        [Required]
        [Column("param_sistema")]
        public string Codigo { get; set; }



        [StringLength(70)]
        [Column("nombre")]
        public string Nombre { get; set; }


        [Column("valor_cadena")]
        public string ValorCadena { get; set; }


        [Column("valor_numerico")]
        public decimal? ValorNumerico { get; set; }

        [Column("valor_fecha")]
        public DateTime? ValorFecha { get; set; }

      

    }
}
