using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Domain
{
    [Table("serie")]
    public partial class Serie
    {
        public Serie()
        {

        }

        [Key]
        [Column("serie_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SerieId { get; set; }

        [Column("almacen_id")]
        public int AlmacenId { get; set; }

        [Column("tipo_doc_com_id")]
        public int DocumentoComercialId { get; set; }

        [Column("num_serie")]
        public string NumeroSerie { get; set; }

        [Column("num_linea")]
        public int NumeroLinea { get; set; }

        [Column("igv_sn")]
        public string IgvSn { get; set; }

        [Column("formato_doc")]
        public string FormatoDocumento { get; set; }

        [Column("observacion")]
        public string Observacion { get; set; }

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

        public virtual Almacen Almacen { get; set; }

    }
}
