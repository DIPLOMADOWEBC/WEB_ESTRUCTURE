using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infiniteskills.Domain
{
    [Table("empresa")]
    public partial class Empresa:AuditableEntity
    {
        public Empresa()
        {
            Sucursal = new HashSet<Sucursal>();
            //Orden = new HashSet<Orden>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("empresa_id")]
        public int EmpresaId { get; set; }



        [Required]
        [Column("razon_social")]
        public string RazonSocial { get; set; }

        [Required]
        [Column("numero_ruc")]
        public string NumeroRuc { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("direccion")]
        public string Direccion { get; set; }


        [Column("telefono")]
        public string Telefono { get; set; }

        [Column("email")]
        [Required(AllowEmptyStrings = true)]
        public string Email { get; set; }

        [Column("igv_sn")]
        public string Igv { get; set; }


        [Column("renta")]
        public decimal Renta { get; set; }

        [Column("logo")]
        public byte[] Logo { get; set; }

        [Column("ruta_xml")]
        public string RutaXml { get; set; }

        [Column("ruta_pdf")]
        public string RutaPdf { get; set; }


        [Column("ruta_cdr")]
        public string RutaCrd { get; set; }

        [Column("ruta_firma")]
        public string RutaFirma { get; set; }

        [Column("contrasena_firma")]
        public string ContrasenaFirma { get; set; }

        [Column("usuario_correo")]
        public string UsuarioCorreo { get; set; }

        [Column("alias_correo")]
        public string AliasCorreo { get; set; }

        [Column("correo")]
        public string Correo { get; set; }

        [Column("contrasena_correo")]
        public string ContrasenaCorreo { get; set; }

        [Column("server_smtp")]
        public string ServerSmtp { get; set; }

        [Column("puerto_smtp")]
        public string PuertoSmtp { get; set; }

        [Column("seguridad_ssl")]
        public bool SeguridadSsl { get; set; }

        [Column("usuario_sunat")]
        public string UsuarioSunat { get; set; }

        [Column("contrasena_sunat")]
        public string ContrasenaSunat { get; set; }

        //public virtual ICollection<Orden> Orden { get; set; }
        public virtual ICollection<Sucursal> Sucursal { get; set; }
    }
}
