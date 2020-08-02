using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infiniteskills.Domain
{
    [Table("sucursal")]
    public partial class Sucursal:AuditableEntity
    {
        public Sucursal()
        {
           
           // PeriodoEmpresa = new HashSet<PeriodoEmpresa>();
            Almacen = new HashSet<Almacen>();
            SucursalUsuario = new HashSet<SucursalPersonal>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("sucursal_id")]
        public int SucursalId { get; set; }


        [Column("empresa_id")]
        public int EmpresaId { get; set; }

        [Column("distrito_id")]
        public int DistritoId { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("direccion")]
        public string Direccion { get; set; }

        [Column("telefono")]
        public string Telefono { get; set; }

        [Column("capacidad")]
        public string Capacidad { get; set; }

        public virtual Distrito Distrito { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<Almacen> Almacen { get; set; }
        public virtual ICollection<SucursalPersonal> SucursalUsuario { get; set; }
        //public virtual ICollection<PeriodoEmpresa> PeriodoEmpresa { get; set; }
    }
}
