using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infiniteskills.Domain
{
    [Table("proveedor")]
    public partial class Proveedor:AuditableEntity
    {
        public Proveedor()
        {
            Producto = new HashSet<BienServicio>();
            Orden = new HashSet<Orden>();
            //Direccion = new HashSet<DireccionProveedor>();
            ProveedorContacto = new HashSet<ProveedorContacto>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("proveedor_id")]
        public int ProveedorId { get; set; }

        [Column("moneda_id")]
        public int? MonedaId { get; set; }


        [Column("personal_id")]
        public int PersonalId { get; set; }

        [Required]
        [Column("razon_social")]
        public string RazonSocial { get; set; }

        [Required]
        [Column("tipo_proveedor_id")]
        public int TipoProveedorId { get; set; }

        [Column("nombres")]
        public string Nombres { get; set; }


        [Column("doc_identidad_id")]
        public int DocumentoIdentidadId { get; set; }

        [Column("num_doc_ident")]
        public string NumeroDocumento { get; set; }

        [Column("tipo_cliente")]
        public string TipoCliente { get; set; }

        [Column("forma_venta_id")]
        public int? FormaVentaId { get; set; }

        [Column("tipo_precio_id")]
        public int? TipoPrecioId { get; set; }



        [Column("distrito_id")]
        public int DistritoId { get; set; }

        [StringLength(20)]
        [Column("telefono")]
        public string Telefono { get; set; }


        [StringLength(20)]
        [Column("celular")]
        public string Celular { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(70)]
        [Column("email")]
        public string CorreoUno { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(120)]
        [Column("email_dos")]
        public string CorreoDos { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(150)]
        [Column("pagina_web")]
        public string PaginaWeb { get; set; }

        [Column("direccion")]
        public string NombreDireccion { get; set; }

     
        public virtual FormaVenta FormaVenta { get; set; }
        public virtual Moneda Moneda { get; set; }
        public virtual TipoPrecio TipoPrecio { get; set; }
        public virtual DocumentoIdentidad DocumentoIdentidad { get; set; }
        public virtual TipoProveedor TipoProveedor { get; set; }
        public virtual Distrito Distrito { get; set; }
        public virtual Personal Personal { get; set; }
        public virtual ICollection<BienServicio> Producto { get; set; }
        public virtual ICollection<Orden> Orden { get; set; }
        //public virtual ICollection<DireccionProveedor> Direccion { get; set; }
        public virtual ICollection<ProveedorContacto> ProveedorContacto { get; set; }
    }
}
