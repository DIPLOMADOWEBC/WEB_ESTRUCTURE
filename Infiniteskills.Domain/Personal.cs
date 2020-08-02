using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("personal")]
    public partial class Personal:AuditableEntity
    {
        public Personal()
        {
            Pedido = new HashSet<Orden>();
            Usuario = new HashSet<Usuario>();
            Proveedor = new HashSet<Proveedor>();
            SucursalUsuario = new HashSet<SucursalPersonal>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("personal_id")]
        public int PersonalId { get; set; }


        [Column("num_doc")]
        public string NumeroDocumento { get; set; }

        [Column("nombres")]
        public string Nombres { get; set; }


        [Column("apellidos")]
        public string Apellidos { get; set; }


        [Column("fecha_nac")]
        public DateTime FechaNacimiento { get; set; }

        [Column("telefono")]
        public string Telefono { get; set; }


        [Column("celular")]
        public string Celular { get; set; }

        [Column("email")]
        public string Correo { get; set; }

        public virtual ICollection<SucursalPersonal> SucursalUsuario { get; set; }
        public virtual ICollection<Orden> Pedido { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual ICollection<Proveedor> Proveedor { get; set; }

    }
}
